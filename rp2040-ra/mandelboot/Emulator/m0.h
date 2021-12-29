
#define DBUGFETCH   0
#define DBUGRAM     0
#define DBUGRAMW    0
#define DBUGREG     0
#define DBUG        0
#define DISS        0

#define CPSR_N (1<<31)
#define CPSR_Z (1<<30)
#define CPSR_C (1<<29)
#define CPSR_V (1<<28)
#define CPSR_Q (1<<27)

//-------------------------------------------------------------------
void do_zflag ( unsigned int x )
{
   if(x==0) cpsr|=CPSR_Z; else cpsr&=~CPSR_Z;
}
//-------------------------------------------------------------------
void do_nflag ( unsigned int x )
{
   if(x&0x80000000) cpsr|=CPSR_N; else cpsr&=~CPSR_N;
}
//-------------------------------------------------------------------
void do_cflag ( unsigned int a, unsigned int b, unsigned int c )
{
   unsigned int rc;

   cpsr&=~CPSR_C;
   rc=(a&0x7FFFFFFF)+(b&0x7FFFFFFF)+c; //carry in
   rc = (rc>>31)+(a>>31)+(b>>31);  //carry out
   if(rc&2) cpsr|=CPSR_C;
}
//-------------------------------------------------------------------
void do_vflag ( unsigned int a, unsigned int b, unsigned int c )
{
   unsigned int rc;
   unsigned int rd;

   cpsr&=~CPSR_V;
   rc=(a&0x7FFFFFFF)+(b&0x7FFFFFFF)+c; //carry in
   rc>>=31; //carry in in lsbit
   rd=(rc&1)+((a>>31)&1)+((b>>31)&1); //carry out
   rd>>=1; //carry out in lsbit
   rc=(rc^rd)&1; //if carry in != carry out then signed overflow
   if(rc) cpsr|=CPSR_V;
}
//-------------------------------------------------------------------
void do_cflag_bit ( unsigned int x )
{
  if(x) cpsr|=CPSR_C; else cpsr&=~CPSR_C;
}
//-------------------------------------------------------------------
void do_vflag_bit ( unsigned int x )
{
  if(x) cpsr|=CPSR_V; else cpsr&=~CPSR_V;
}
//-------------------------------------------------------------------


int execute ( void )
{
   unsigned int pc;
   unsigned int sp;
   unsigned int inst;

   unsigned int ra,rb,rc;
   unsigned int rm,rd,rn,rs;
   unsigned int op;

   pc=read_register(15);

   inst=fetch16(pc-2);
   pc+=2;
   write_register(15,pc);
if(DISS) fprintf(stderr,"--- 0x%08X: 0x%04X ",(pc-4),inst);


   //ADC
   if((inst&0xFFC0)==0x4140)
   {
       rd=(inst>>0)&0x07;
       rm=(inst>>3)&0x07;
if(DISS) fprintf(stderr,"adc r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra+rb;
       if(cpsr&CPSR_C) rc++;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       if(cpsr&CPSR_C) { do_cflag(ra,rb,1); do_vflag(ra,rb,1); }
       else            { do_cflag(ra,rb,0); do_vflag(ra,rb,0); }
       return(0);
   }

   //ADD(1) small immediate two registers
   if((inst&0xFE00)==0x1C00)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rb=(inst>>6)&0x7;
       if(rb)
       {
if(DISS) fprintf(stderr,"adds r%u,r%u,#0x%X\n",rd,rn,rb);
           ra=read_register(rn);
           rc=ra+rb;
//fprintf(stderr,"0x%08X = 0x%08X + 0x%08X\n",rc,ra,rb);
           write_register(rd,rc);
           do_nflag(rc);
           do_zflag(rc);
           do_cflag(ra,rb,0);
           do_vflag(ra,rb,0);
           return(0);
       }
       else
       {
           //this is a mov
       }
   }

   //ADD(2) big immediate one register
   if((inst&0xF800)==0x3000)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x7;
if(DISS) fprintf(stderr,"adds r%u,#0x%02X\n",rd,rb);
       ra=read_register(rd);
       rc=ra+rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,rb,0);
       do_vflag(ra,rb,0);
       return(0);
   }

   //ADD(3) three registers
   if((inst&0xFE00)==0x1800)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"adds r%u,r%u,r%u\n",rd,rn,rm);
       ra=read_register(rn);
       rb=read_register(rm);
       rc=ra+rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,rb,0);
       do_vflag(ra,rb,0);
       return(0);
   }

   //ADD(4) two registers one or both high no flags
   if((inst&0xFF00)==0x4400)
   {
       if((inst>>6)&3)
       {
           //UNPREDICTABLE
       }
       rd=(inst>>0)&0x7;
       rd|=(inst>>4)&0x8;
       rm=(inst>>3)&0xF;
if(DISS) fprintf(stderr,"add r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra+rb;
       if(rd==15)
       {
           if((rc&1)==0)
           {
               fprintf(stderr,"add pc,... produced an arm address 0x%08X 0x%08X\n",pc,rc);
               exit(1);
           }
           rc&=~1; //write_register may do this as well
           rc+=2; //The program counter is special
       }
//fprintf(stderr,"0x%08X = 0x%08X + 0x%08X\n",rc,ra,rb);
       write_register(rd,rc);
       return(0);
   }

   //ADD(5) rd = pc plus immediate
   if((inst&0xF800)==0xA000)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x7;
       rb<<=2;
if(DISS) fprintf(stderr,"add r%u,PC,#0x%02X\n",rd,rb);
       ra=read_register(15);
       rc=(ra&(~3))+rb;
       write_register(rd,rc);
       return(0);
   }

   //ADD(6) rd = sp plus immediate
   if((inst&0xF800)==0xA800)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x7;
       rb<<=2;
if(DISS) fprintf(stderr,"add r%u,SP,#0x%02X\n",rd,rb);
       ra=read_register(13);
       rc=ra+rb;
       write_register(rd,rc);
       return(0);
   }

   //ADD(7) sp plus immediate
   if((inst&0xFF80)==0xB000)
   {
       rb=(inst>>0)&0x7F;
       rb<<=2;
if(DISS) fprintf(stderr,"add SP,#0x%02X\n",rb);
       ra=read_register(13);
       rc=ra+rb;
       write_register(13,rc);
       return(0);
   }

   //AND
   if((inst&0xFFC0)==0x4000)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"ands r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra&rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //ASR(1) two register immediate
   if((inst&0xF800)==0x1000)
   {
       rd=(inst>>0)&0x07;
       rm=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
if(DISS) fprintf(stderr,"asrs r%u,r%u,#0x%X\n",rd,rm,rb);
       rc=read_register(rm);
       if(rb==0)
       {
           if(rc&0x80000000)
           {
               do_cflag_bit(1);
               rc=~0;
           }
           else
           {
               do_cflag_bit(0);
               rc=0;
           }
       }
       else
       {
           do_cflag_bit(rc&(1<<(rb-1)));
           ra=rc&0x80000000;
           rc>>=rb;
           if(ra) //asr, sign is shifted in
           {
               rc|=(~0)<<(32-rb);
           }
       }
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //ASR(2) two register
   if((inst&0xFFC0)==0x4100)
   {
       rd=(inst>>0)&0x07;
       rs=(inst>>3)&0x07;
if(DISS) fprintf(stderr,"asrs r%u,r%u\n",rd,rs);
       rc=read_register(rd);
       rb=read_register(rs);
       rb&=0xFF;
       if(rb==0)
       {
       }
       else if(rb<32)
       {
           do_cflag_bit(rc&(1<<(rb-1)));
           ra=rc&0x80000000;
           rc>>=rb;
           if(ra) //asr, sign is shifted in
           {
               rc|=(~0)<<(32-rb);
           }
       }
       else
       {
           if(rc&0x80000000)
           {
               do_cflag_bit(1);
               rc=(~0);
           }
           else
           {
               do_cflag_bit(0);
               rc=0;
           }
       }
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //B(1) conditional branch
   if((inst&0xF000)==0xD000)
   {
       rb=(inst>>0)&0xFF;
       if(rb&0x80) rb|=(unsigned)(~0)<<8;
       op=(inst>>8)&0xF;
       rb<<=1;
       rb+=pc;
       rb+=2;
       switch(op)
       {
           case 0x0: //b eq  z set
if(DISS) fprintf(stderr,"beq 0x%08X\n",rb-3);
               if(cpsr&CPSR_Z)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0x1: //b ne  z clear
if(DISS) fprintf(stderr,"bne 0x%08X\n",rb-3);
               if(!(cpsr&CPSR_Z))
               {
                   write_register(15,rb);
               }
               return(0);

           case 0x2: //b cs c set
if(DISS) fprintf(stderr,"bcs 0x%08X\n",rb-3);
               if(cpsr&CPSR_C)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0x3: //b cc c clear
if(DISS) fprintf(stderr,"bcc 0x%08X\n",rb-3);
               if(!(cpsr&CPSR_C))
               {
                   write_register(15,rb);
               }
               return(0);

           case 0x4: //b mi n set
if(DISS) fprintf(stderr,"bmi 0x%08X\n",rb-3);
               if(cpsr&CPSR_N)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0x5: //b pl n clear
if(DISS) fprintf(stderr,"bpl 0x%08X\n",rb-3);
               if(!(cpsr&CPSR_N))
               {
                   write_register(15,rb);
               }
               return(0);


           case 0x6: //b vs v set
if(DISS) fprintf(stderr,"bvs 0x%08X\n",rb-3);
               if(cpsr&CPSR_V)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0x7: //b vc v clear
if(DISS) fprintf(stderr,"bvc 0x%08X\n",rb-3);
               if(!(cpsr&CPSR_V))
               {
                   write_register(15,rb);
               }
               return(0);


           case 0x8: //b hi c set z clear
if(DISS) fprintf(stderr,"bhi 0x%08X\n",rb-3);
               if((cpsr&CPSR_C)&&(!(cpsr&CPSR_Z)))
               {
                   write_register(15,rb);
               }
               return(0);

           case 0x9: //b ls c clear or z set
if(DISS) fprintf(stderr,"bls 0x%08X\n",rb-3);
               if((cpsr&CPSR_Z)||(!(cpsr&CPSR_C)))
               {
                   write_register(15,rb);
               }
               return(0);

           case 0xA: //b ge N == V
if(DISS) fprintf(stderr,"bge 0x%08X\n",rb-3);
               ra=0;
               if(  (cpsr&CPSR_N) &&  (cpsr&CPSR_V) ) ra++;
               if((!(cpsr&CPSR_N))&&(!(cpsr&CPSR_V))) ra++;
               if(ra)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0xB: //b lt N != V
if(DISS) fprintf(stderr,"blt 0x%08X\n",rb-3);
               ra=0;
               if((!(cpsr&CPSR_N))&&(cpsr&CPSR_V)) ra++;
               if((!(cpsr&CPSR_V))&&(cpsr&CPSR_N)) ra++;
               if(ra)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0xC: //b gt Z==0 and N == V
if(DISS) fprintf(stderr,"bgt 0x%08X\n",rb-3);
               ra=0;
               if(  (cpsr&CPSR_N) &&  (cpsr&CPSR_V) ) ra++;
               if((!(cpsr&CPSR_N))&&(!(cpsr&CPSR_V))) ra++;
               if(cpsr&CPSR_Z) ra=0;
               if(ra)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0xD: //b le Z==1 or N != V
if(DISS) fprintf(stderr,"ble 0x%08X\n",rb-3);
               ra=0;
               if((!(cpsr&CPSR_N))&&(cpsr&CPSR_V)) ra++;
               if((!(cpsr&CPSR_V))&&(cpsr&CPSR_N)) ra++;
               if(cpsr&CPSR_Z) ra++;
               if(ra)
               {
                   write_register(15,rb);
               }
               return(0);

           case 0xE:
               //undefined instruction
               break;
           case 0xF:
               //swi
               break;
       }
   }

   //B(2) unconditional branch
   if((inst&0xF800)==0xE000)
   {
       rb=(inst>>0)&0x7FF;
       if(rb&(1<<10)) rb|=(unsigned)(~0)<<11;
       rb<<=1;
       rb+=pc;
       rb+=2;
if(DISS) fprintf(stderr,"B 0x%08X\n",rb-3);
       write_register(15,rb);
       return(0);
   }

   //BIC
   if((inst&0xFFC0)==0x4380)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"bics r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra&(~rb);
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //BKPT
   if((inst&0xFF00)==0xBE00)
   {
       rb=(inst>>0)&0xFF;
       fprintf(stderr,"bkpt 0x%02X\n",rb);
       return(1);
   }

   //BL/BLX(1)
   if((inst&0xE000)==0xE000) //BL,BLX
   {
       if((inst&0x1800)==0x1000) //H=b10
       {
if(DISS) fprintf(stderr,"\n");
           rb=inst&((1<<11)-1);
           if(rb&1<<10) rb|=(~((1<<11)-1)); //sign extend
           rb<<=12;
           rb+=pc;
           write_register(14,rb);
           return(0);
       }
       else
       if((inst&0x1800)==0x1800) //H=b11
       {
           //branch to thumb
           rb=read_register(14);
           rb+=(inst&((1<<11)-1))<<1;;
           rb+=2;

if(DISS) fprintf(stderr,"bl 0x%08X\n",rb-3);
           write_register(14,(pc-2)|1);
           write_register(15,rb);
           return(0);
       }
       else
       if((inst&0x1800)==0x0800) //H=b01
       {
           //fprintf(stderr,"cannot branch to arm 0x%08X 0x%04X\n",pc,inst);
           //return(1);
           //branch to thumb
           rb=read_register(14);
           rb+=(inst&((1<<11)-1))<<1;;
           rb&=0xFFFFFFFC;
           rb+=2;

printf("hello\n");

if(DISS) fprintf(stderr,"bl 0x%08X\n",rb-3);
           write_register(14,(pc-2)|1);
           write_register(15,rb);
           return(0);



       }
   }

   //BLX(2)
   if((inst&0xFF87)==0x4780)
   {
       rm=(inst>>3)&0xF;
if(DISS) fprintf(stderr,"blx r%u\n",rm);
       rc=read_register(rm);
//fprintf(stderr,"blx r%u 0x%X 0x%X\n",rm,rc,pc);
       rc+=2;
       if(rc&1)
       {
           write_register(14,(pc-2)|1);
           rc&=~1;
           write_register(15,rc);
           return(0);
       }
       else
       {
           fprintf(stderr,"cannot branch to arm 0x%08X 0x%04X\n",pc,inst);
           return(1);
       }
   }

   //BX
   if((inst&0xFF87)==0x4700)
   {
       rm=(inst>>3)&0xF;
if(DISS) fprintf(stderr,"bx r%u\n",rm);
       rc=read_register(rm);
       rc+=2;
//fprintf(stderr,"bx r%u 0x%X 0x%X\n",rm,rc,pc);
       if(rc&1)
       {
           rc&=~1;
           write_register(15,rc);
           return(0);
       }
       else
       {
           fprintf(stderr,"cannot branch to arm 0x%08X 0x%04X\n",pc,inst);
           return(1);
       }
   }

   //CMN
   if((inst&0xFFC0)==0x42C0)
   {
       rn=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"cmns r%u,r%u\n",rn,rm);
       ra=read_register(rn);
       rb=read_register(rm);
       rc=ra+rb;
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,rb,0);
       do_vflag(ra,rb,0);
       return(0);
   }

   //CMP(1) compare immediate
   if((inst&0xF800)==0x2800)
   {
       rb=(inst>>0)&0xFF;
       rn=(inst>>8)&0x07;
if(DISS) fprintf(stderr,"cmp r%u,#0x%02X\n",rn,rb);
       ra=read_register(rn);
       rc=ra-rb;
//fprintf(stderr,"0x%08X 0x%08X\n",ra,rb);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,~rb,1);
       do_vflag(ra,~rb,1);
       return(0);
   }

   //CMP(2) compare register
   if((inst&0xFFC0)==0x4280)
   {
       rn=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"cmps r%u,r%u\n",rn,rm);
       ra=read_register(rn);
       rb=read_register(rm);
       rc=ra-rb;
//fprintf(stderr,"0x%08X 0x%08X\n",ra,rb);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,~rb,1);
       do_vflag(ra,~rb,1);
       return(0);
   }

   //CMP(3) compare high register
   if((inst&0xFF00)==0x4500)
   {
       if(((inst>>6)&3)==0x0)
       {
           //UNPREDICTABLE
       }
       rn=(inst>>0)&0x7;
       rn|=(inst>>4)&0x8;
       if(rn==0xF)
       {
           //UNPREDICTABLE
       }
       rm=(inst>>3)&0xF;
if(DISS) fprintf(stderr,"cmps r%u,r%u\n",rn,rm);
       ra=read_register(rn);
       rb=read_register(rm);
       rc=ra-rb;
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,~rb,1);
       do_vflag(ra,~rb,1);
       return(0);
   }

   //CPS
   if((inst&0xFFE8)==0xB660)
   {
if(DISS) fprintf(stderr,"cps TODO\n");
       return(1);
   }

   //CPY copy high register
   if((inst&0xFFC0)==0x4600)
   {
       //same as mov except you can use both low registers
       //going to let mov handle high registers
       rd=(inst>>0)&0x7; //mov handles the high registers
       rm=(inst>>3)&0x7; //mov handles the high registers
if(DISS) fprintf(stderr,"cpy r%u,r%u\n",rd,rm);
       rc=read_register(rm);
       //if(rd==15) //mov handles the high registers like r15
       //{
           //rc&=~1;
           //rc+=2; //The program counter is special
       //}
       write_register(rd,rc);
       return(0);
   }

   //EOR
   if((inst&0xFFC0)==0x4040)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"eors r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra^rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //LDMIA
   if((inst&0xF800)==0xC800)
   {
       rn=(inst>>8)&0x7;
if(DISS)
{
   fprintf(stderr,"ldmia r%u!,{",rn);
   for(ra=0,rb=0x01,rc=0;rb;rb=(rb<<1)&0xFF,ra++)
   {
       if(inst&rb)
       {
           if(rc) fprintf(stderr,",");
           fprintf(stderr,"r%u",ra);
           rc++;
       }
   }
   fprintf(stderr,"}\n");
}
       sp=read_register(rn);
       for(ra=0,rb=0x01;rb;rb=(rb<<1)&0xFF,ra++)
       {
           if(inst&rb)
           {
               write_register(ra,read32(sp));
               sp+=4;
           }
       }
       write_register(rn,sp);
       return(0);
   }

   //LDR(1) two register immediate
   if((inst&0xF800)==0x6800)
   {
       rd=(inst>>0)&0x07;
       rn=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
       rb<<=2;
if(DISS) fprintf(stderr,"ldr r%u,[r%u,#0x%X]\n",rd,rn,rb);
       rb=read_register(rn)+rb;
       rc=read32(rb);
       write_register(rd,rc);
       return(0);
   }

   //LDR(2) three register
   if((inst&0xFE00)==0x5800)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"ldr r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read32(rb);
       write_register(rd,rc);
       return(0);
   }

   //LDR(3)
   if((inst&0xF800)==0x4800)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x07;
       rb<<=2;
if(DISS) fprintf(stderr,"ldr r%u,[PC+#0x%X] ",rd,rb);
       ra=read_register(15);
       ra&=~3;
       rb+=ra;
if(DISS) fprintf(stderr,";@ 0x%X\n",rb);
       rc=read32(rb);
       write_register(rd,rc);
       return(0);
   }

   //LDR(4)
   if((inst&0xF800)==0x9800)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x07;
       rb<<=2;
if(DISS) fprintf(stderr,"ldr r%u,[SP+#0x%X]\n",rd,rb);
       ra=read_register(13);
       //ra&=~3;
       rb+=ra;
       rc=read32(rb);
       write_register(rd,rc);
       return(0);
   }

   //LDRB(1)
   if((inst&0xF800)==0x7800)
   {
       rd=(inst>>0)&0x07;
       rn=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
if(DISS) fprintf(stderr,"ldrb r%u,[r%u,#0x%X]\n",rd,rn,rb);
       rb=read_register(rn)+rb;
       rc=read8(rb);
       write_register(rd,rc&0xFF);
       return(0);
   }

   //LDRB(2)
   if((inst&0xFE00)==0x5C00)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"ldrb r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read8(rb);
       write_register(rd,rc&0xFF);
       return(0);
   }

   //LDRH(1)
   if((inst&0xF800)==0x8800)
   {
       rd=(inst>>0)&0x07;
       rn=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
       rb<<=1;
if(DISS) fprintf(stderr,"ldrh r%u,[r%u,#0x%X]\n",rd,rn,rb);
       rb=read_register(rn)+rb;
       rc=read16(rb);
       write_register(rd,rc&0xFFFF);
       return(0);
   }

   //LDRH(2)
   if((inst&0xFE00)==0x5A00)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"ldrh r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read16(rb);
       write_register(rd,rc&0xFFFF);
       return(0);
   }

   //LDRSB
   if((inst&0xFE00)==0x5600)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"ldrsb r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read16(rb&(~1));
       if(rb&1)
       {
           rc>>=8;
       }
       else
       {
       }
       rc&=0xFF;
       if(rc&0x80) rc|=((unsigned)(~0)<<8);
       write_register(rd,rc);
       return(0);
   }

   //LDRSH
   if((inst&0xFE00)==0x5E00)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"ldrsh r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read16(rb);
       rc&=0xFFFF;
       if(rc&0x8000) rc|=((unsigned)(~0)<<16);
       write_register(rd,rc);
       return(0);
   }

   //LSL(1)
   if((inst&0xF800)==0x0000)
   {
       rd=(inst>>0)&0x07;
       rm=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
if(DISS) fprintf(stderr,"lsls r%u,r%u,#0x%X\n",rd,rm,rb);
       rc=read_register(rm);
       if(rb==0)
       {
           //if immed_5 == 0
           //C unnaffected
           //result not shifted
       }
       else
       {
           //else immed_5 > 0
           do_cflag_bit(rc&(1<<(32-rb)));
           rc<<=rb;
       }
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //LSL(2) two register
   if((inst&0xFFC0)==0x4080)
   {
       rd=(inst>>0)&0x07;
       rs=(inst>>3)&0x07;
if(DISS) fprintf(stderr,"lsls r%u,r%u\n",rd,rs);
       rc=read_register(rd);
       rb=read_register(rs);
       rb&=0xFF;
       if(rb==0)
       {
       }
       else if(rb<32)
       {
           do_cflag_bit(rc&(1<<(32-rb)));
           rc<<=rb;
       }
       else if(rb==32)
       {
           do_cflag_bit(rc&1);
           rc=0;
       }
       else
       {
           do_cflag_bit(0);
           rc=0;
       }
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //LSR(1) two register immediate
   if((inst&0xF800)==0x0800)
   {
       rd=(inst>>0)&0x07;
       rm=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
if(DISS) fprintf(stderr,"lsrs r%u,r%u,#0x%X\n",rd,rm,rb);
       rc=read_register(rm);
       if(rb==0)
       {
           do_cflag_bit(rc&0x80000000);
           rc=0;
       }
       else
       {
           do_cflag_bit(rc&(1<<(rb-1)));
           rc>>=rb;
       }
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //LSR(2) two register
   if((inst&0xFFC0)==0x40C0)
   {
       rd=(inst>>0)&0x07;
       rs=(inst>>3)&0x07;
if(DISS) fprintf(stderr,"lsrs r%u,r%u\n",rd,rs);
       rc=read_register(rd);
       rb=read_register(rs);
       rb&=0xFF;
       if(rb==0)
       {
       }
       else if(rb<32)
       {
           do_cflag_bit(rc&(1<<(rb-1)));
           rc>>=rb;
       }
       else if(rb==32)
       {
           do_cflag_bit(rc&0x80000000);
           rc=0;
       }
       else
       {
           do_cflag_bit(0);
           rc=0;
       }
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //MOV(1) immediate
   if((inst&0xF800)==0x2000)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x07;
if(DISS) fprintf(stderr,"movs r%u,#0x%02X\n",rd,rb);
       write_register(rd,rb);
       do_nflag(rb);
       do_zflag(rb);
       return(0);
   }

   //MOV(2) two low registers
   if((inst&0xFFC0)==0x1C00)
   {
       rd=(inst>>0)&7;
       rn=(inst>>3)&7;
if(DISS) fprintf(stderr,"movs r%u,r%u\n",rd,rn);
       rc=read_register(rn);
//fprintf(stderr,"0x%08X\n",rc);
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag_bit(0);
       do_vflag_bit(0);
       return(0);
   }

   //MOV(3)
   if((inst&0xFF00)==0x4600)
   {
       rd=(inst>>0)&0x7;
       rd|=(inst>>4)&0x8;
       rm=(inst>>3)&0xF;
if(DISS) fprintf(stderr,"mov r%u,r%u\n",rd,rm);
       rc=read_register(rm);
       if((rd==14)&&(rm==15))
       {
           //printf("mov lr,pc warning 0x%08X\n",pc-2);
           //rc|=1;
       }
       if(rd==15)
       {
           //if((rc&1)==0)
           //{
               //fprintf(stderr,"cpy or mov pc,... produced an ARM address 0x%08X 0x%08X\n",pc,rc);
               //exit(1);
           //}
           rc&=~1; //write_register may do this as well
           rc+=2; //The program counter is special
       }
       write_register(rd,rc);
       return(0);
   }

   //MUL
   if((inst&0xFFC0)==0x4340)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"muls r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra*rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //MVN
   if((inst&0xFFC0)==0x43C0)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"mvns r%u,r%u\n",rd,rm);
       ra=read_register(rm);
       rc=(~ra);
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //NEG
   if((inst&0xFFC0)==0x4240)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"negs r%u,r%u\n",rd,rm);
       ra=read_register(rm);
       rc=0-ra;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(0,~ra,1);
       do_vflag(0,~ra,1);
       return(0);
   }

   //ORR
   if((inst&0xFFC0)==0x4300)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"orrs r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra|rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }


   //POP
   if((inst&0xFE00)==0xBC00)
   {
if(DISS)
{
   fprintf(stderr,"pop {");
   for(ra=0,rb=0x01,rc=0;rb;rb=(rb<<1)&0xFF,ra++)
   {
       if(inst&rb)
       {
           if(rc) fprintf(stderr,",");
           fprintf(stderr,"r%u",ra);
           rc++;
       }
   }
   if(inst&0x100)
   {
       if(rc) fprintf(stderr,",");
       fprintf(stderr,"pc");
   }
   fprintf(stderr,"}\n");
}

       sp=read_register(13);
       for(ra=0,rb=0x01;rb;rb=(rb<<1)&0xFF,ra++)
       {
           if(inst&rb)
           {
               write_register(ra,read32(sp));
               sp+=4;
           }
       }
       if(inst&0x100)
       {
           rc=read32(sp);
           if((rc&1)==0)
           {
               fprintf(stderr,"pop {rc} with an ARM address pc 0x%08X popped 0x%08X\n",pc,rc);
               //exit(1);
               rc&=~1;
           }
           rc+=2;
           write_register(15,rc);
           sp+=4;
       }
       write_register(13,sp);
       return(0);
   }

   //PUSH
   if((inst&0xFE00)==0xB400)
   {

if(DISS)
{
   fprintf(stderr,"push {");
   for(ra=0,rb=0x01,rc=0;rb;rb=(rb<<1)&0xFF,ra++)
   {
       if(inst&rb)
       {
           if(rc) fprintf(stderr,",");
           fprintf(stderr,"r%u",ra);
           rc++;
       }
   }
   if(inst&0x100)
   {
       if(rc) fprintf(stderr,",");
       fprintf(stderr,"lr");
   }
   fprintf(stderr,"}\n");
}

       sp=read_register(13);
//fprintf(stderr,"sp 0x%08X\n",sp);
       for(ra=0,rb=0x01,rc=0;rb;rb=(rb<<1)&0xFF,ra++)
       {
           if(inst&rb)
           {
               rc++;
           }
       }
       if(inst&0x100) rc++;
       rc<<=2;
       sp-=rc;
       rd=sp;
       for(ra=0,rb=0x01;rb;rb=(rb<<1)&0xFF,ra++)
       {
           if(inst&rb)
           {
               write32(rd,read_register(ra));
               rd+=4;
           }
       }
       if(inst&0x100)
       {
           rc=read_register(14);
           write32(rd,rc); //read_register(14));

           if((rc&1)==0)
           {
               fprintf(stderr,"push {lr} with an ARM address pc 0x%08X popped 0x%08X\n",pc,rc);
//                exit(1);
           }


       }
       write_register(13,sp);
       return(0);
   }

   //REV
   if((inst&0xFFC0)==0xBA00)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"rev r%u,r%u\n",rd,rn);
       ra=read_register(rn);
       rc =((ra>> 0)&0xFF)<<24;
       rc|=((ra>> 8)&0xFF)<<16;
       rc|=((ra>>16)&0xFF)<< 8;
       rc|=((ra>>24)&0xFF)<< 0;
       write_register(rd,rc);
       return(0);
   }

   //REV16
   if((inst&0xFFC0)==0xBA40)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"rev16 r%u,r%u\n",rd,rn);
       ra=read_register(rn);
       rc =((ra>> 0)&0xFF)<< 8;
       rc|=((ra>> 8)&0xFF)<< 0;
       rc|=((ra>>16)&0xFF)<<24;
       rc|=((ra>>24)&0xFF)<<16;
       write_register(rd,rc);
       return(0);
   }

   //REVSH
   if((inst&0xFFC0)==0xBAC0)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"revsh r%u,r%u\n",rd,rn);
       ra=read_register(rn);
       rc =((ra>> 0)&0xFF)<< 8;
       rc|=((ra>> 8)&0xFF)<< 0;
       if(rc&0x8000) rc|=0xFFFF0000;
       else          rc&=0x0000FFFF;
       write_register(rd,rc);
       return(0);
   }

   //ROR
   if((inst&0xFFC0)==0x41C0)
   {
       rd=(inst>>0)&0x7;
       rs=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"rors r%u,r%u\n",rd,rs);
       rc=read_register(rd);
       ra=read_register(rs);
       ra&=0xFF;
       if(ra==0)
       {
       }
       else
       {
           ra&=0x1F;
           if(ra==0)
           {
               do_cflag_bit(rc&0x80000000);
           }
           else
           {
               do_cflag_bit(rc&(1<<(ra-1)));
               rb=rc<<(32-ra);
               rc>>=ra;
               rc|=rb;
           }
       }
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //SBC
   if((inst&0xFFC0)==0x4180)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"sbc r%u,r%u\n",rd,rm);
       ra=read_register(rd);
       rb=read_register(rm);
       rc=ra-rb;
       if(!(cpsr&CPSR_C)) rc--;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       if(cpsr&CPSR_C)
       {
           do_cflag(ra,~rb,1);
           do_vflag(ra,~rb,1);
       }
       else
       {
           do_cflag(ra,~rb,0);
           do_vflag(ra,~rb,0);
       }
       return(0);
   }

   //SETEND
   if((inst&0xFFF7)==0xB650)
   {
       fprintf(stderr,"setend not implemented\n");
       return(1);
   }

   //STMIA
   if((inst&0xF800)==0xC000)
   {
       rn=(inst>>8)&0x7;

if(DISS)
{
   fprintf(stderr,"stmia r%u!,{",rn);
   for(ra=0,rb=0x01,rc=0;rb;rb=(rb<<1)&0xFF,ra++)
   {
       if(inst&rb)
       {
           if(rc) fprintf(stderr,",");
           fprintf(stderr,"r%u",ra);
           rc++;
       }
   }
   fprintf(stderr,"}\n");
}
       sp=read_register(rn);
       for(ra=0,rb=0x01;rb;rb=(rb<<1)&0xFF,ra++)
       {
           if(inst&rb)
           {
               write32(sp,read_register(ra));
               sp+=4;
           }
       }
       write_register(rn,sp);
       return(0);
   }

   //STR(1)
   if((inst&0xF800)==0x6000)
   {
       rd=(inst>>0)&0x07;
       rn=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
       rb<<=2;
if(DISS) fprintf(stderr,"str r%u,[r%u,#0x%X]\n",rd,rn,rb);
       rb=read_register(rn)+rb;
       rc=read_register(rd);
       write32(rb,rc);
       return(0);
   }

   //STR(2)
   if((inst&0xFE00)==0x5000)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"str r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read_register(rd);
       write32(rb,rc);
       return(0);
   }

   //STR(3)
   if((inst&0xF800)==0x9000)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x07;
       rb<<=2;
if(DISS) fprintf(stderr,"str r%u,[SP,#0x%X]\n",rd,rb);
       rb=read_register(13)+rb;
//fprintf(stderr,"0x%08X\n",rb);
       rc=read_register(rd);
       write32(rb,rc);
       return(0);
   }

   //STRB(1)
   if((inst&0xF800)==0x7000)
   {
       rd=(inst>>0)&0x07;
       rn=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
if(DISS) fprintf(stderr,"strb r%u,[r%u,#0x%X]\n",rd,rn,rb);
       rb=read_register(rn)+rb;
       rc=read_register(rd);
       write8(rb, rc);
       return(0);
   }

   //STRB(2)
   if((inst&0xFE00)==0x5400)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"strb r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read_register(rd);
       write8(rb, rc);
       return(0);
   }

   //STRH(1)
   if((inst&0xF800)==0x8000)
   {
       rd=(inst>>0)&0x07;
       rn=(inst>>3)&0x07;
       rb=(inst>>6)&0x1F;
       rb<<=1;
if(DISS) fprintf(stderr,"strh r%u,[r%u,#0x%X]\n",rd,rn,rb);
       rb=read_register(rn)+rb;
       rc=read_register(rd);
       write16(rb,rc&0xFFFF);
       return(0);
   }

   //STRH(2)
   if((inst&0xFE00)==0x5200)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"strh r%u,[r%u,r%u]\n",rd,rn,rm);
       rb=read_register(rn)+read_register(rm);
       rc=read_register(rd);
       write16(rb,rc&0xFFFF);
       return(0);
   }

   //SUB(1)
   if((inst&0xFE00)==0x1E00)
   {
       rd=(inst>>0)&7;
       rn=(inst>>3)&7;
       rb=(inst>>6)&7;
if(DISS) fprintf(stderr,"subs r%u,r%u,#0x%X\n",rd,rn,rb);
       ra=read_register(rn);
       rc=ra-rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,~rb,1);
       do_vflag(ra,~rb,1);
       return(0);
   }

   //SUB(2)
   if((inst&0xF800)==0x3800)
   {
       rb=(inst>>0)&0xFF;
       rd=(inst>>8)&0x07;
if(DISS) fprintf(stderr,"subs r%u,#0x%02X\n",rd,rb);
       ra=read_register(rd);
       rc=ra-rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,~rb,1);
       do_vflag(ra,~rb,1);
       return(0);
   }

   //SUB(3)
   if((inst&0xFE00)==0x1A00)
   {
       rd=(inst>>0)&0x7;
       rn=(inst>>3)&0x7;
       rm=(inst>>6)&0x7;
if(DISS) fprintf(stderr,"subs r%u,r%u,r%u\n",rd,rn,rm);
       ra=read_register(rn);
       rb=read_register(rm);
       rc=ra-rb;
       write_register(rd,rc);
       do_nflag(rc);
       do_zflag(rc);
       do_cflag(ra,~rb,1);
       do_vflag(ra,~rb,1);
       return(0);
   }

   //SUB(4)
   if((inst&0xFF80)==0xB080)
   {
       rb=inst&0x7F;
       rb<<=2;
if(DISS) fprintf(stderr,"sub SP,#0x%02X\n",rb);
       ra=read_register(13);
       ra-=rb;
       write_register(13,ra);
       return(0);
   }

   //SWI
   if((inst&0xFF00)==0xDF00)
   {
       rb=inst&0xFF;
if(DISS) fprintf(stderr,"swi 0x%02X\n",rb);

       if((inst&0xFF)==0xCC)
       {
           write_register(0,cpsr);
           return(0);
       }
       else
       {
           fprintf(stderr,"\n\nswi 0x%02X\n",rb);
           return(1);
       }
   }

   //SXTB
   if((inst&0xFFC0)==0xB240)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"sxtb r%u,r%u\n",rd,rm);
       ra=read_register(rm);
       rc=ra&0xFF;
       if(rc&0x80) rc|=(unsigned)(~0)<<8;
       write_register(rd,rc);
       return(0);
   }

   //SXTH
   if((inst&0xFFC0)==0xB200)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"sxth r%u,r%u\n",rd,rm);
       ra=read_register(rm);
       rc=ra&0xFFFF;
       if(rc&0x8000) rc|=(unsigned)(~0)<<16;
       write_register(rd,rc);
       return(0);
   }

   //TST
   if((inst&0xFFC0)==0x4200)
   {
       rn=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"tst r%u,r%u\n",rn,rm);
       ra=read_register(rn);
       rb=read_register(rm);
       rc=ra&rb;
       do_nflag(rc);
       do_zflag(rc);
       return(0);
   }

   //UXTB
   if((inst&0xFFC0)==0xB2C0)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"uxtb r%u,r%u\n",rd,rm);
       ra=read_register(rm);
       rc=ra&0xFF;
       write_register(rd,rc);
       return(0);
   }

   //UXTH
   if((inst&0xFFC0)==0xB280)
   {
       rd=(inst>>0)&0x7;
       rm=(inst>>3)&0x7;
if(DISS) fprintf(stderr,"uxth r%u,r%u\n",rd,rm);
       ra=read_register(rm);
       rc=ra&0xFFFF;
       write_register(rd,rc);
       return(0);
   }


   // Spezielle Opcodes vom Palanqin:

   if (inst == 0xB700) // Bye
   {
     exit(0);
   }

   if (inst == 0xB701) // Debug
   {

     fprintf ( stdout, "R0  %08X  R1  %08X  R2  %08X  R3  %08X\nR4  %08X  R5  %08X  R6  %08X  R7  %08X\nR8  %08X  R9  %08X  R10 %08X  R11 %08X\nR12 %08X  SP  %08X  LR  %08X  PC  %08X\nNZCV  ",
               read_register(0),
               read_register(1),
               read_register(2),
               read_register(3),
               read_register(4),
               read_register(5),
               read_register(6),
               read_register(7),
               read_register(8),
               read_register(9),
               read_register(10),
               read_register(11),
               read_register(12),
               read_register(13),
               read_register(14),
               read_register(15) - 1
             );

     if (cpsr & CPSR_N) { fprintf (stdout, "N"); } else { fprintf (stdout, "-"); }
     if (cpsr & CPSR_Z) { fprintf (stdout, "Z"); } else { fprintf (stdout, "-"); }
     if (cpsr & CPSR_C) { fprintf (stdout, "C"); } else { fprintf (stdout, "-"); }
     if (cpsr & CPSR_V) { fprintf (stdout, "V"); } else { fprintf (stdout, "-"); }
     fprintf (stdout, "\n");

     return(0);
   }

   if (inst == 0xB702)  // Emit
   {
     putchar(read_register(0) & 0xFF);
     fflush(stdout);
     return(0);
   }

   if (inst == 0xB703)  // Key
   {
     int data=getchar();
     if (data==127) { data=8; } // Replace DEL with Backspace
     write_register(0, data);
     return(0);
   }

   fprintf(stderr,"invalid instruction 0x%08X 0x%04X\n",pc-4,inst);
   return(1);
}

int run ( void )
{
   while(1)
   {
       // fprintf(stderr,"PC: 0x%08X\n", reg_norm[15]);
       if(execute()) break;
   }
   return(0);
}
