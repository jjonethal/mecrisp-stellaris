//-------------------------------------------------------------------
//
//   Thumbulator by dwelch67
//   https://github.com/dwelch67/thumbulator
//
//   Changelog:
//
//   30.09.2013, Matthias Koch:
//   Adapted for use with Freescale Freedom KL25Z128 images
//   to have an emulator for Mecrisp-Stellaris M0
//
//   05.02.2014, Matthias Koch:
//   Simple flash write emulation
//
//   27.10.2017, Matthias Koch:
//   Pruned code for grafting with Pinkysim and changed target to STM32F051
//
//-------------------------------------------------------------------

#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <termios.h>
#include <stdint.h>

    /* Use this variable to remember original terminal attributes. */

    struct termios saved_attributes;

    void
    reset_input_mode (void)
    {
      tcsetattr (STDIN_FILENO, TCSANOW, &saved_attributes);
    }

    void
    set_input_mode (void)
    {
      struct termios tattr;
      char *name;

      /* Make sure stdin is a terminal. */
      if (!isatty (STDIN_FILENO))
        {
          fprintf (stderr, "Not a terminal.\n");
          exit (EXIT_FAILURE);
        }

      /* Save the terminal attributes so we can restore them later. */
      tcgetattr (STDIN_FILENO, &saved_attributes);
      atexit (reset_input_mode);

      /* Set the funny terminal modes. */
      tcgetattr (STDIN_FILENO, &tattr);
      tattr.c_lflag &= ~(ICANON|ECHO); /* Clear ICANON and ECHO. */
      tattr.c_cc[VMIN] = 1;
      tattr.c_cc[VTIME] = 0;
      tcsetattr (STDIN_FILENO, TCSAFLUSH, &tattr);
    }

#define ROMADDMASK 0xFFFFF
#define RAMADDMASK 0xFFFFF

#define ROMSIZE (ROMADDMASK+1)
#define RAMSIZE (RAMADDMASK+1)

unsigned short rom[ROMSIZE>>1];
unsigned short ram[RAMSIZE>>1];

//-------------------------------------------------------------------

void write16 ( unsigned int addr, unsigned int data )
{
   switch(addr) // Special peripheral registers
   {

     case 0x4000C000: // USART1_TDR
       putchar(data&0xFF);
       fflush(stdout);
       return;
   }

   switch(addr&0xF0000000)
   {
       case 0x00000000: // Flash
           addr&=ROMADDMASK;      // Flash is mirrored in STM32, but this mask will remove the 0x08000000 bit anyway.
           addr>>=1;
           rom[addr]=data&0xFFFF;
           return;

       case 0x20000000: //RAM
           addr&=RAMADDMASK;
           addr>>=1;
           ram[addr]=data&0xFFFF;
           return;
   }
}

//-----------------------------------------------------------------

unsigned int read16 ( unsigned int addr )
{
   unsigned int data;

   switch(addr) // Special peripheral registers
   {
     case 0x400FD008: // FLASH_FMC
       data=0x00;  // Never busy.
       return(data);

     case 0x4000C018: // UARTFR
       data=0x00;  // Never busy.
       return(data);

     case 0x4000C000: // USART1_TDR
       data=getchar();
       if (data==127) { data=8; } // Replace DEL with Backspace
       return(data);

     // USART1_ISR is not handled, as default value for all memory access into void is $FF: Always be prepared to receive and transmit.
   }

   switch(addr&0xF0000000)
   {
       case 0x00000000: // Flash
           addr&=ROMADDMASK;      // Flash is mirrored in STM32, but this mask will remove the 0x08000000 bit anyway.
           addr>>=1;
           data=rom[addr];
           return(data);

       case 0x20000000: // RAM
           addr&=RAMADDMASK;
           addr>>=1;
           data=ram[addr];
           return(data);

       default:
           data=0xFFFF;
           return(data);
   }
}

unsigned int fetch16 ( unsigned int addr ) { return(read16(addr)); }

//-------------------------------------------------------------------

uint32_t flash_address, flash_data;

void write32 ( unsigned int addr, unsigned int data )
{

  FILE *coredump;
  unsigned int rc;

  switch(addr)
  {

   case 0x400FD000: // FLASH_FMA
     flash_address = data;
     return;

   case 0x400FD004: // FLASH_FMD
     flash_data = data;
     return;

   case 0x400FD008: // FLASH_FMC
     if (data == 0xA4420001) { write32(flash_address, flash_data); }
     return;


    case 0xDABBAD00: // C0DEBA5E:
      coredump = fopen("coredump.bin", "w");
      rc = fwrite(rom, 1, data, coredump);
      fclose(coredump);
      exit(0);
    return;

    default:
      write16(addr+0,(data>> 0)&0xFFFF);
      write16(addr+2,(data>>16)&0xFFFF);
  }
}

//-------------------------------------------------------------------

unsigned int read32 ( unsigned int addr )
{
   unsigned int data;

   data =read16(addr+0);
   data|=((unsigned int)read16(addr+2))<<16;
   return(data);
}

unsigned int fetch32 ( unsigned int addr ) { return(read32(addr)); }

//-------------------------------------------------------------------

void write8 ( unsigned int addr, unsigned int data )
{
 unsigned int content;
 content=read16(addr&(~1));  // Take care, this read may trigger some emulated peripheral action.

 if(addr&1)
 {
   content&=0x00FF;
   content|=data<<8;
 }
 else
 {
   content&=0xFF00;
   content|=data&0x00FF;
 }
 write16(addr&(~1),content&0xFFFF);
}

//-------------------------------------------------------------------

unsigned int read8 ( unsigned int addr )
{
 unsigned int data;
 data=read16(addr&(~1));
 if (addr&1) { data>>=8; }
 return(data&0xFF);
}

//-------------------------------------------------------------------

unsigned int cpsr;
unsigned int reg_norm[16]; // Normal execution mode, do not have a thread mode

unsigned int read_register ( unsigned int reg )
{
   unsigned int data;

   reg&=0xF;
   data=reg_norm[reg];
   if(reg==15)
   {
       if(data&1)
       {
           fprintf(stderr,"pc has lsbit set 0x%08X\n",data);
       }
       data&=~1;
   }

   return(data);
}

void write_register ( unsigned int reg, unsigned int data )
{
   reg&=0xF;
   if(reg==15) data&=~1;
   reg_norm[reg]=data;

}

//-------------------------------------------------------------------

#include "m3partial.h"

//-------------------------------------------------------------------
int reset ( void )
{
   cpsr=0;
   reg_norm[13]=fetch32(0x00000000); // Return stack pointer
   reg_norm[14]=0xFFFFFFFF;          // Link register
   reg_norm[15]=(fetch32(0x00000004) + 2) & ~1; // Reset vector

   return(0);
}
//-------------------------------------------------------------------
int main ( int argc, char *argv[] )
{
   // set_input_mode ();

   memset(ram,0xFF,sizeof(ram));
   memset(rom,0xFF,sizeof(rom));

   FILE *fp;

   unsigned int ra;

   fp=fopen(argv[1],"rb");
   ra=fread(rom,1,sizeof(rom),fp);
   fclose(fp);

   reset();
   run();

   return(0);
}
//-------------------------------------------------------------------
