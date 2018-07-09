/*  Copyright (C) 2014  Adam Green (https://github.com/adamgreen)

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    This code was ripped out of https://github.com/adamgreen/pinkySim and then
    heavily modified, but no living organism has been harmed in the process.

    -jcw, 2017-10-31
*/

#define IMemory_Read8(m,a)      read8(a)
#define IMemory_Read16(m,a)     read16(a)
#define IMemory_Read32(m,a)     read32(a)

#define IMemory_Write8(m,a,d)   write8(a,d)
#define IMemory_Write16(m,a,d)  write16(a,d)
#define IMemory_Write32(m,a,d)  write32(a,d)

#define __try               if (1)
#define __catch             if (0)
#define __throw(x)          { printf("e%d\n", x); exit(x); }
#define getExceptionCode()  0

// from try_catch.h
#define noException                         0
#define bufferOverrunException              1
#define invalidHexDigitException            2
#define invalidValueException               3
#define invalidArgumentException            4
#define timeoutException                    5
#define invalidIndexException               6
#define notFoundException                   7
#define exceededHardwareResourcesException  8
#define invalidDecDigitException            9
#define memFaultException                   10
#define mriMaxException                     15

#define undefinedException                  (mriMaxException + 1)
#define unpredictableException              (mriMaxException + 2)
#define outOfMemoryException                (mriMaxException + 3)
#define busErrorException                   (mriMaxException + 4)
#define alignmentException                  (mriMaxException + 5)
#define bkptException                       (mriMaxException + 6)
#define badResponseException                (mriMaxException + 7)
#define serialException                     (mriMaxException + 8)
#define hardwareBreakpointException         (mriMaxException + 9)
#define hardwareWatchpointException         (mriMaxException + 10)
#define socketException                     (mriMaxException + 11)
#define fileException                       (mriMaxException + 12)
#define coverageException                   (mriMaxException + 13)

//#include <assert.h>
#define assert(x)

//#include <common.h>
#define FALSE 0
#define TRUE  1

//#include <pinkySim.h>
/* Bits in PinkySimContext::xPSR */
#define APSR_N      (1U << 31U) /* Negative flag */
#define APSR_Z      (1 << 30)   /* Zero flag */
#define APSR_C      (1 << 29)   /* Carry flag */
#define APSR_V      (1 << 28)   /* Overflow flag */
#define IPSR_MASK   0x3F        /* Mask for exception number */
#define EPSR_T      (1 << 24)   /* Thumb mode flag */

/* Useful xPSR flag combinations for masking off at runtime. */
#define APSR_NZCV   (APSR_N | APSR_Z | APSR_C | APSR_V)
#define APSR_NZC    (APSR_N | APSR_Z | APSR_C)
#define APSR_NZ     (APSR_N | APSR_Z)
#define APSR_NC     (APSR_N | APSR_C)
#define APSR_ZC     (APSR_Z | APSR_C)

/* Bits in PinkySimContext::PRIMASK */
#define PRIMASK_PM (1 << 0)

/* Condition codes */
#define COND_EQ 0x0
#define COND_NE (COND_EQ | 1)
#define COND_CS 0x2
#define COND_CC (COND_CS | 1)
#define COND_MI 0x4
#define COND_PL (COND_MI | 1)
#define COND_VS 0x6
#define COND_VC (COND_VS | 1)
#define COND_HI 0x8
#define COND_LS (COND_HI | 1)
#define COND_GE 0xA
#define COND_LT (COND_GE | 1)
#define COND_GT 0xC
#define COND_LE (COND_GT | 1)
#define COND_AL 0xE

/* SYSm field values for MSR and MRS instructions. */
#define SYS_APSR    0
#define SYS_IAPSR   1
#define SYS_EAPSR   2
#define SYS_XPSR    3
#define SYS_IPSR    5
#define SYS_EPSR    6
#define SYS_IEPSR   7
#define SYS_MSP     8
#define SYS_PSP     9
#define SYS_PRIMASK 16
#define SYS_CONTROL 20

/* Register names / indices into PinkySimContext::R array for first 13 registers. */
#define R0  0
#define R1  1
#define R2  2
#define R3  3
#define R4  4
#define R5  5
#define R6  6
#define R7  7
#define R8  8
#define R9  9
#define R10 10
#define R11 11
#define R12 12
#define SP  13
#define LR  14
#define PC  15

typedef struct PinkySimContext
{
    void* pMemory;
    uint32_t R[13];
    uint32_t spMain;
    uint32_t lr;
    uint32_t pc;
    uint32_t xPSR;
    uint32_t newPC;
    uint32_t PRIMASK;
    uint32_t CONTROL;
} PinkySimContext;

static PinkySimContext context, *pContext = &context;

/* Values that can be returned from the pinkySimStep() or pinkySimRun() function. */
#define PINKYSIM_STEP_OK            0   /* Executed instruction successfully. */
#define PINKYSIM_STEP_UNDEFINED     1   /* Encountered undefined instruction. */
#define PINKYSIM_STEP_UNPREDICTABLE 2   /* Encountered instruction with unpredictable behaviour. */
#define PINKYSIM_STEP_HARDFAULT     3   /* Encountered instruction which generates hard fault. */
#define PINKYSIM_STEP_BKPT          4   /* Encountered BKPT instruction or other debug event. */
#define PINKYSIM_STEP_UNSUPPORTED   5   /* Encountered instruction not supported by simulator. */
#define PINKYSIM_STEP_SVC           6   /* Encountered SVC instruction. */
#define PINKYSIM_RUN_INTERRUPT      7   /* pinkySimRun() callback signalled interrupt. */
#define PINKYSIM_RUN_WATCHPOINT     8   /* pinkySimRun() callback signalled watchpoint event. */
#define PINKYSIM_RUN_SINGLESTEP     9   /* pinkySimRun() callback signalled single step. */
// end of #include <pinkySim.h>

/* Fields decoded from instructions. */
typedef struct Fields
{
    uint32_t imm;
    uint32_t d;
    uint32_t m;
    uint32_t n;
    uint32_t t;
    uint32_t registers;
} Fields;

/* Types of shift/rotate operations. */
typedef enum SRType
{
    SRType_LSL,
    SRType_LSR,
    SRType_ASR,
    // NOTE: ARMv6-M doesn't use the RRX type.
    //SRType_RRX,
    SRType_ROR
} SRType;

/* Decoded shift/rotate operation. */
typedef struct DecodedImmShift
{
    SRType   type;
    uint32_t n;
} DecodedImmShift;

/* Shift operation results. */
typedef struct ShiftResults
{
    uint32_t result;
    uint32_t carryOut;
} ShiftResults;

/* Results from addition/subtraction. */
typedef struct AddResults
{
    uint32_t result;
    int      carryOut;
    int      overflow;
} AddResults;

/* Function Prototypes */
static int executeInstruction16(PinkySimContext* pContext, uint16_t instr);
static int shiftAddSubtractMoveCompare(PinkySimContext* pContext, uint16_t instr);
static int lslImmediate(PinkySimContext* pContext, uint16_t instr);
static Fields decodeImm10to6_Rm5to3_Rd2to0(uint32_t instr);
static DecodedImmShift decodeImmshift(uint32_t typeBits, uint32_t imm5);
static ShiftResults shift_C(uint32_t value, SRType type, uint32_t amount, uint32_t carryIn);
static ShiftResults LSL_C(uint32_t x, uint32_t shift);
static ShiftResults LSR_C(uint32_t x, uint32_t shift);
static ShiftResults ASR_C(uint32_t x, uint32_t shift);
static ShiftResults ROR_C(uint32_t x, uint32_t shift);
static uint32_t LSR(uint32_t x, uint32_t shift);
static uint32_t LSL(uint32_t x, uint32_t shift);
static uint32_t getReg(const PinkySimContext* pContext, uint32_t reg);
static void setReg(PinkySimContext* pContext, uint32_t reg, uint32_t value);
static void updateRdAndNZC(PinkySimContext* pContext, Fields* pFields, const ShiftResults* pShiftResults);
static int lsrImmediate(PinkySimContext* pContext, uint16_t instr);
static int asrImmediate(PinkySimContext* pContext, uint16_t instr);
static int addRegisterT1(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRm8to6_Rn5to3_Rd2to0(uint32_t instr);
static AddResults addWithCarry(uint32_t x, uint32_t y, uint32_t carryInAsBit);
static void updateRdAndNZCV(PinkySimContext* pContext, Fields* pFields, const AddResults* pAddResults);
static void updateNZCV(PinkySimContext* pContext, Fields* pFields, const AddResults* pAddResults);
static int subRegister(PinkySimContext* pContext, uint16_t instr);
static int addImmediateT1(PinkySimContext* pContext, uint16_t instr);
static Fields decodeImm8to6_Rn5to3_Rd2to0(uint32_t instr);
static int subImmediateT1(PinkySimContext* pContext, uint16_t instr);
static int movImmediate(PinkySimContext* pContext, uint16_t instr);
static void updateRdAndNZ(PinkySimContext* pContext, Fields* pFields, uint32_t results);
static void updateNZ(PinkySimContext* pContext, Fields* pFields, uint32_t results);
static Fields decodeRd10to8_Imm7to0(uint32_t instr);
static int cmpImmediate(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRn10to8_Imm7to0(uint32_t instr);
static int addImmediateT2(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRdn10to8_Imm7to0(uint32_t instr);
static int subImmediateT2(PinkySimContext* pContext, uint16_t instr);
static int dataProcessing(PinkySimContext* pContext, uint16_t instr);
static int andRegister(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRm5to3_Rdn2to0(uint32_t instr);
static int eorRegister(PinkySimContext* pContext, uint16_t instr);
static int lslRegister(PinkySimContext* pContext, uint16_t instr);
static int lsrRegister(PinkySimContext* pContext, uint16_t instr);
static int asrRegister(PinkySimContext* pContext, uint16_t instr);
static int adcRegister(PinkySimContext* pContext, uint16_t instr);
static int sbcRegister(PinkySimContext* pContext, uint16_t instr);
static int rorRegister(PinkySimContext* pContext, uint16_t instr);
static int tstRegister(PinkySimContext* pContext, uint16_t instr);
static int rsbRegister(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRn5to3_Rd2to0(uint32_t instr);
static int cmpRegisterT1(PinkySimContext* pContext, uint16_t instr);
static int cmnRegister(PinkySimContext* pContext, uint16_t instr);
static int orrRegister(PinkySimContext* pContext, uint16_t instr);
static int mulRegister(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRn5to3_Rdm2to0(uint32_t instr);
static int bicRegister(PinkySimContext* pContext, uint16_t instr);
static int mvnRegister(PinkySimContext* pContext, uint16_t instr);
static int specialDataAndBranchExchange(PinkySimContext* pContext, uint16_t instr);
static int addRegisterT2(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRdn7and2to0_Rm6to3(uint32_t instr);
static void aluWritePC(PinkySimContext* pContext, uint32_t address);
static void branchWritePC(PinkySimContext* pContext, uint32_t address);
static void branchTo(PinkySimContext* pContext, uint32_t address);
static int cmpRegisterT2(PinkySimContext* pContext, uint16_t instr);
static int movRegister(PinkySimContext* pContext, uint16_t instr);
static int bx(PinkySimContext* pContext, uint16_t instr);
static void bxWritePC(PinkySimContext* pContext, uint32_t address);
static int blx(PinkySimContext* pContext, uint16_t instr);
static void blxWritePC(PinkySimContext* pContext, uint32_t address);
static int ldrLiteral(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRt10to8_Imm7to0Shift2(uint32_t instr);
static uint32_t align(uint32_t value, uint32_t alignment);
static uint32_t unalignedMemRead(PinkySimContext* pContext, uint32_t address, uint32_t size);
static uint32_t alignedMemRead(PinkySimContext* pContext, uint32_t address, uint32_t size);
static int isAligned(uint32_t address, uint32_t size);
static int loadStoreSingleDataItem(PinkySimContext* pContext, uint16_t instr);
static int strRegister(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRm8to6_Rn5to3_Rt2to0(uint32_t instr);
static void unalignedMemWrite(PinkySimContext* pContext, uint32_t address, uint32_t size, uint32_t value);
static void alignedMemWrite(PinkySimContext* pContext, uint32_t address, uint32_t size, uint32_t value);
static int strhRegister(PinkySimContext* pContext, uint16_t instr);
static int strbRegister(PinkySimContext* pContext, uint16_t instr);
static int ldrsbRegister(PinkySimContext* pContext, uint16_t instr);
static uint32_t signExtend8(uint32_t valueToExtend);
static int ldrRegister(PinkySimContext* pContext, uint16_t instr);
static int ldrhRegister(PinkySimContext* pContext, uint16_t instr);
static uint32_t zeroExtend16(uint32_t value);
static int ldrbRegister(PinkySimContext* pContext, uint16_t instr);
static uint32_t zeroExtend8(uint32_t value);
static int ldrshRegister(PinkySimContext* pContext, uint16_t instr);
static uint32_t signExtend16(uint32_t valueToExtend);
static int strImmediateT1(PinkySimContext* pContext, uint16_t instr);
static Fields decodeImm10to6_Rn5to3_Rt2to0(uint32_t instr);
static int ldrImmediateT1(PinkySimContext* pContext, uint16_t instr);
static int strbImmediate(PinkySimContext* pContext, uint16_t instr);
static int ldrbImmediate(PinkySimContext* pContext, uint16_t instr);
static int strhImmediate(PinkySimContext* pContext, uint16_t instr);
static int ldrhImmediate(PinkySimContext* pContext, uint16_t instr);
static int strImmediateT2(PinkySimContext* pContext, uint16_t instr);
static int ldrImmediateT2(PinkySimContext* pContext, uint16_t instr);
static int adr(PinkySimContext* pContext, uint16_t instr);
static int addSPT1(PinkySimContext* pContext, uint16_t instr);
static int misc16BitInstructions(PinkySimContext* pContext, uint16_t instr);
static int addSPT2(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRdisSP_Imm6to0Shift2(uint32_t instr);
static int subSP(PinkySimContext* pContext, uint16_t instr);
static int sxth(PinkySimContext* pContext, uint16_t instr);
static int sxtb(PinkySimContext* pContext, uint16_t instr);
static int uxth(PinkySimContext* pContext, uint16_t instr);
static int uxtb(PinkySimContext* pContext, uint16_t instr);
static int push(PinkySimContext* pContext, uint16_t instr);
static uint32_t bitCount(uint32_t value);
static int cps(PinkySimContext* pContext, uint16_t instr);
static int currentModeIsPrivileged(PinkySimContext* pContext);
static int rev(PinkySimContext* pContext, uint16_t instr);
static int rev16(PinkySimContext* pContext, uint16_t instr);
static int revsh(PinkySimContext* pContext, uint16_t instr);
static int pop(PinkySimContext* pContext, uint16_t instr);
static void loadWritePC(PinkySimContext* pContext, uint32_t address);
static int hints(PinkySimContext* pContext, uint16_t instr);
static int nop(PinkySimContext* pContext, uint16_t instr);
static int yield(PinkySimContext* pContext, uint16_t instr);
static int wfe(PinkySimContext* pContext, uint16_t instr);
static int wfi(PinkySimContext* pContext, uint16_t instr);
static int sev(PinkySimContext* pContext, uint16_t instr);
static int treatAsNop(PinkySimContext* pContext, uint16_t instr);
static int stm(PinkySimContext* pContext, uint16_t instr);
static Fields decodeRn10to8RegisterList7to0(uint32_t instr);
static int isNotLowestBitSet(uint32_t bits, uint32_t i);
static int ldm(PinkySimContext* pContext, uint16_t instr);
static int conditionalBranchAndSupervisor(PinkySimContext* pContext, uint16_t instr);
static int svc(PinkySimContext* pContext, uint16_t instr);
static int conditionalBranch(PinkySimContext* pContext, uint16_t instr);
static int conditionPassedForBranchInstr(PinkySimContext* pContext, uint16_t instr);
static int unconditionalBranch(PinkySimContext* pContext, uint16_t instr);
static int executeInstruction32(PinkySimContext* pContext, uint16_t instr1);
static int branchAndMiscellaneousControl(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);
static int msr(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);
static int miscellaneousControl(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);
static int dsb(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);
static int dmb(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);
static int isb(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);
static int mrs(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);
static int bl(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2);


int execute ()
{
    int      result = PINKYSIM_STEP_UNDEFINED;

    if (!(pContext->xPSR & EPSR_T))
        return PINKYSIM_STEP_HARDFAULT;

    __try
    {
        uint16_t instr =  IMemory_Read16(pContext->pMemory, pContext->pc);
        //printf("pc %04x : %04x\n", pContext->pc, instr);

        if ((instr & 0xF800) == 0xE800 ||
            (instr & 0xF800) == 0xF000 ||
            (instr & 0xF800) == 0xF800)
            result = executeInstruction32(pContext, instr);
        else
            result = executeInstruction16(pContext, instr);
        pContext->pc = pContext->newPC;
    }
    __catch
    {
        switch (getExceptionCode())
        {
        case bkptException:
        case hardwareBreakpointException:
            return PINKYSIM_STEP_BKPT;
        case undefinedException:
            return PINKYSIM_STEP_UNDEFINED;
        case unpredictableException:
            return PINKYSIM_STEP_UNPREDICTABLE;
        default:
            return PINKYSIM_STEP_HARDFAULT;
        }
    }

    return result;
}

int run ( void )
{
    pContext->pc = read_register(15);
    printf("r%x\n", pContext->pc);

    pContext->xPSR = EPSR_T;

    while (!execute())
        ;

    write_register(15, pContext->pc);
    return(0);
}

static int executeInstruction16(PinkySimContext* pContext, uint16_t instr)
{
    int result = PINKYSIM_STEP_UNDEFINED;

    pContext->newPC = pContext->pc + 2;
    if ((instr & 0xC000) == 0x0000)
        result = shiftAddSubtractMoveCompare(pContext, instr);
    else if ((instr & 0xFC00) == 0x4000)
        result = dataProcessing(pContext, instr);
    else if ((instr & 0xFC00) == 0x4400)
        result = specialDataAndBranchExchange(pContext, instr);
    else if ((instr & 0xF800) == 0x4800)
        result = ldrLiteral(pContext, instr);
    else if (((instr & 0xF000) == 0x5000) || ((instr & 0xE000) == 0x6000) || ((instr & 0xE000) == 0x8000))
        result = loadStoreSingleDataItem(pContext, instr);
    else if ((instr & 0xF800) == 0xA000)
        result = adr(pContext, instr);
    else if ((instr & 0xF800) == 0xA800)
        result = addSPT1(pContext, instr);
    else if ((instr & 0xF000) == 0xB000)
        result = misc16BitInstructions(pContext, instr);
    else if ((instr & 0xF800) == 0xC000)
        result = stm(pContext, instr);
    else if ((instr & 0xF800) == 0xC800)
        result = ldm(pContext, instr);
    else if ((instr & 0xF000) == 0xD000)
        result = conditionalBranchAndSupervisor(pContext, instr);
    else if ((instr & 0xF800) == 0xE000)
        result = unconditionalBranch(pContext, instr);
    return result;
}

static int shiftAddSubtractMoveCompare(PinkySimContext* pContext, uint16_t instr)
{
    int result = PINKYSIM_STEP_UNDEFINED;

    if ((instr & 0x3800) == 0x0000)
        result = lslImmediate(pContext, instr);
    else if ((instr & 0x3800) == 0x0800)
        result = lsrImmediate(pContext, instr);
    else if ((instr & 0x3800) == 0x1000)
        result = asrImmediate(pContext, instr);
    else if ((instr & 0x3E00) == 0x1800)
        result = addRegisterT1(pContext, instr);
    else if ((instr & 0x3E00) == 0x1A00)
        result = subRegister(pContext, instr);
    else if ((instr & 0x3E00) == 0x1C00)
        result = addImmediateT1(pContext, instr);
    else if ((instr & 0x3E00) == 0x1E00)
        result = subImmediateT1(pContext, instr);
    else if ((instr & 0x3800) == 0x2000)
        result = movImmediate(pContext, instr);
    else if ((instr & 0x3800) == 0x2800)
        result = cmpImmediate(pContext, instr);
    else if ((instr & 0x3800) == 0x3000)
        result = addImmediateT2(pContext, instr);
    else if ((instr & 0x3800) == 0x3800)
        result = subImmediateT2(pContext, instr);
    return result;
}

static int lslImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields          fields = decodeImm10to6_Rm5to3_Rd2to0(instr);
    DecodedImmShift decodedShift = decodeImmshift(0x0, fields.imm);
    ShiftResults    shiftResults;

    shiftResults = shift_C(getReg(pContext, fields.m), SRType_LSL, decodedShift.n, pContext->xPSR & APSR_C);
    updateRdAndNZC(pContext, &fields, &shiftResults);
    return PINKYSIM_STEP_OK;
}

static Fields decodeImm10to6_Rm5to3_Rd2to0(uint32_t instr)
{
    Fields fields;

    fields.imm = (instr & (0x1F << 6)) >> 6;
    fields.d = instr & 0x7;
    fields.m = (instr & (0x7 << 3)) >> 3;
    return fields;
}

static DecodedImmShift decodeImmshift(uint32_t typeBits, uint32_t imm5)
{
    DecodedImmShift results;

    assert ((typeBits & 0x3) == typeBits);
    switch (typeBits)
    {
    case 0x0:
        results.type = SRType_LSL;
        results.n = imm5;
        break;
    case 0x1:
        results.type = SRType_LSR;
        results.n = (imm5 == 0) ? 32 : imm5;
        break;
    // NOTE: ARMv6-M only uses the first 3 decodings.
    //case 0x2:
    default:
        results.type = SRType_ASR;
        results.n = (imm5 == 0) ? 32 : imm5;
        break;
    }
    return results;
}

static ShiftResults shift_C(uint32_t value, SRType type, uint32_t amount, uint32_t carryIn)
{
    ShiftResults results = {value, carryIn};

    // NOTE: ARMv6-M doesn't use the RRX type.
    if (amount != 0)
    {
        switch (type)
        {
        case SRType_LSL:
            results = LSL_C(value, amount);
            break;
        case SRType_LSR:
            results = LSR_C(value, amount);
            break;
        case SRType_ASR:
            results = ASR_C(value, amount);
            break;
        case SRType_ROR:
            results = ROR_C(value, amount);
            break;
        }
    }
    return results;
}

static ShiftResults LSL_C(uint32_t x, uint32_t shift)
{
    ShiftResults results;

    results.carryOut = (shift > 32) ? 0 : x & (1 << (32 - shift));
    results.result = (shift > 31) ? 0 : x << shift;
    return results;
}

static ShiftResults LSR_C(uint32_t x, uint32_t shift)
{
    ShiftResults results;

    assert (shift > 0);

    results.carryOut = (shift > 32) ? 0 : (x & (1 << (shift - 1)));
    results.result = (shift > 31) ? 0 : x >> shift;
    return results;
}

static ShiftResults ASR_C(uint32_t x, uint32_t shift)
{
    ShiftResults results;

    assert (shift > 0);

    if (shift > 32)
    {
        if (x & 0x80000000)
            results.carryOut = 1;
        else
            results.carryOut = 0;
    }
    else
    {
        results.carryOut = (x & (1 << (shift - 1)));
    }
    if (shift > 31)
    {
        if (x & 0x80000000)
            results.result = 0xFFFFFFFF;
        else
            results.result = 0x00000000;
    }
    else
    {
        results.result = (uint32_t)((int32_t)x >> shift);
    }
    return results;
}

static ShiftResults ROR_C(uint32_t x, uint32_t shift)
{
    uint32_t     m;
    ShiftResults results;

    assert (shift != 0);

    m = shift & 31U;
    results.result = LSR(x, m) | LSL(x, 32-m);
    results.carryOut = results.result & (1 << 31);
    return results;
}

static uint32_t LSR(uint32_t x, uint32_t shift)
{
    ShiftResults results = {0, 0};

    assert (shift >= 0);

    if (shift == 0)
        results.result = x;
    else
        results = LSR_C(x, shift);
    return results.result;
}

static uint32_t LSL(uint32_t x, uint32_t shift)
{
    ShiftResults results = {x, 0};

    assert (shift >= 0);

    if (shift != 0)
        results = LSL_C(x, shift);
    return results.result;
}

static uint32_t getReg(const PinkySimContext* pContext, uint32_t reg)
{
    assert (reg <= PC);

    if (reg == PC)
        return pContext->pc + 4;
    else if (reg == LR)
        return pContext->lr;
    else if (reg == SP)
        // NOTE: Simulator only supports main handler mode.
        return pContext->spMain;
    else
        return pContext->R[reg];
}

static void setReg(PinkySimContext* pContext, uint32_t reg, uint32_t value)
{
    assert (reg < PC);

    if (reg == LR)
        pContext->lr = value;
    else if (reg == SP)
        // NOTE: Simulator only supports main handler mode.
        pContext->spMain = value;
    else
        pContext->R[reg] = value;
}

static void updateRdAndNZC(PinkySimContext* pContext, Fields* pFields, const ShiftResults* pShiftResults)
{
    setReg(pContext, pFields->d, pShiftResults->result);
    pContext->xPSR &= ~APSR_NZC;
    if (pShiftResults->result & (1 << 31))
        pContext->xPSR |= APSR_N;
    if (pShiftResults->result == 0)
        pContext->xPSR |= APSR_Z;
    if (pShiftResults->carryOut)
        pContext->xPSR |= APSR_C;
}

static int lsrImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields          fields = decodeImm10to6_Rm5to3_Rd2to0(instr);
    DecodedImmShift decodedShift = decodeImmshift(0x1, fields.imm);
    ShiftResults    shiftResults;

    shiftResults = shift_C(getReg(pContext, fields.m), SRType_LSR, decodedShift.n, pContext->xPSR & APSR_C);
    updateRdAndNZC(pContext, &fields, &shiftResults);
    return PINKYSIM_STEP_OK;
}

static int asrImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields          fields = decodeImm10to6_Rm5to3_Rd2to0(instr);
    DecodedImmShift decodedShift = decodeImmshift(0x2, fields.imm);
    ShiftResults    shiftResults;

    shiftResults = shift_C(getReg(pContext, fields.m), SRType_ASR, decodedShift.n, pContext->xPSR & APSR_C);
    updateRdAndNZC(pContext, &fields, &shiftResults);
    return PINKYSIM_STEP_OK;
}

static int addRegisterT1(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRm8to6_Rn5to3_Rd2to0(instr);
    AddResults      addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), getReg(pContext, fields.m), 0);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRm8to6_Rn5to3_Rd2to0(uint32_t instr)
{
    Fields fields;

    fields.d = instr & 0x7;
    fields.n = (instr & (0x7 << 3)) >> 3;
    fields.m = (instr & (0x7 << 6)) >> 6;
    return fields;
}

static AddResults addWithCarry(uint32_t x, uint32_t y, uint32_t carryInAsBit)
{
    int        carryIn = carryInAsBit ? 1 : 0;
    uint64_t   unsignedSum = (uint64_t)x + (uint64_t)y + (uint64_t)carryIn;
    int64_t    signedSum = (int64_t)(int32_t)x + (int64_t)(int32_t)y + (int64_t)carryIn;
    uint32_t   result = (uint32_t)unsignedSum;
    AddResults results;

    results.result = result;
    results.carryOut = ((uint64_t)result == unsignedSum) ? 0 : 1;
    results.overflow = ((int64_t)(int32_t)result == signedSum) ? 0 : 1;
    return results;
}

static void updateRdAndNZCV(PinkySimContext* pContext, Fields* pFields, const AddResults* pAddResults)
{
    setReg(pContext, pFields->d, pAddResults->result);
    updateNZCV(pContext, pFields, pAddResults);
}

static void updateNZCV(PinkySimContext* pContext, Fields* pFields, const AddResults* pAddResults)
{
    pContext->xPSR &= ~APSR_NZCV;
    if (pAddResults->result & (1 << 31))
        pContext->xPSR |= APSR_N;
    if (pAddResults->result == 0)
        pContext->xPSR |= APSR_Z;
    if (pAddResults->carryOut)
        pContext->xPSR |= APSR_C;
    if (pAddResults->overflow)
        pContext->xPSR |= APSR_V;
}

static int subRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRm8to6_Rn5to3_Rd2to0(instr);
    AddResults      addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), ~getReg(pContext, fields.m), 1);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int addImmediateT1(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeImm8to6_Rn5to3_Rd2to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), fields.imm, 0);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static Fields decodeImm8to6_Rn5to3_Rd2to0(uint32_t instr)
{
    Fields fields;

    fields.d = instr & 0x7;
    fields.n = (instr & (0x7 << 3)) >> 3;
    fields.imm = (instr & (0x7 << 6)) >> 6;
    return fields;
}

static int subImmediateT1(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeImm8to6_Rn5to3_Rd2to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), ~fields.imm, 1);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int movImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRd10to8_Imm7to0(instr);
    uint32_t result = fields.imm;

    updateRdAndNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static void updateRdAndNZ(PinkySimContext* pContext, Fields* pFields, uint32_t results)
{
    setReg(pContext, pFields->d, results);
    updateNZ(pContext, pFields, results);
}

static void updateNZ(PinkySimContext* pContext, Fields* pFields, uint32_t results)
{
    pContext->xPSR &= ~APSR_NZ;
    if (results & (1 << 31))
        pContext->xPSR |= APSR_N;
    if (results == 0)
        pContext->xPSR |= APSR_Z;
}

static Fields decodeRd10to8_Imm7to0(uint32_t instr)
{
    Fields fields;

    fields.d = (instr & (0x7 << 8)) >> 8;
    fields.imm = instr & 0xFF;
    return fields;
}

static int cmpImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRn10to8_Imm7to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), ~fields.imm, 1);
    updateNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRn10to8_Imm7to0(uint32_t instr)
{
    Fields fields;

    fields.n = (instr & (0x7 << 8)) >> 8;
    fields.imm = instr & 0xFF;
    return fields;
}

static int addImmediateT2(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRdn10to8_Imm7to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), fields.imm, 0);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRdn10to8_Imm7to0(uint32_t instr)
{
    Fields fields;

    fields.d = (instr & (0x7 << 8)) >> 8;
    fields.n = fields.d;
    fields.imm = instr & 0xFF;
    return fields;
}

static int subImmediateT2(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRdn10to8_Imm7to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), ~fields.imm, 1);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int dataProcessing(PinkySimContext* pContext, uint16_t instr)
{
    int result = PINKYSIM_STEP_UNDEFINED;

    switch ((instr & 0x03C0) >> 6)
    {
    case 0:
        result = andRegister(pContext, instr);
        break;
    case 1:
        result = eorRegister(pContext, instr);
        break;
    case 2:
        result = lslRegister(pContext, instr);
        break;
    case 3:
        result = lsrRegister(pContext, instr);
        break;
    case 4:
        result = asrRegister(pContext, instr);
        break;
    case 5:
        result = adcRegister(pContext, instr);
        break;
    case 6:
        result = sbcRegister(pContext, instr);
        break;
    case 7:
        result = rorRegister(pContext, instr);
        break;
    case 8:
        result = tstRegister(pContext, instr);
        break;
    case 9:
        result = rsbRegister(pContext, instr);
        break;
    case 10:
        result = cmpRegisterT1(pContext, instr);
        break;
    case 11:
        result = cmnRegister(pContext, instr);
        break;
    case 12:
        result = orrRegister(pContext, instr);
        break;
    case 13:
        result = mulRegister(pContext, instr);
        break;
    case 14:
        result = bicRegister(pContext, instr);
        break;
    case 15:
        result = mvnRegister(pContext, instr);
        break;
    }
    return result;
}

static int andRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t result;

    result = getReg(pContext, fields.n) & getReg(pContext, fields.m);
    updateRdAndNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRm5to3_Rdn2to0(uint32_t instr)
{
    Fields fields;

    fields.d = instr & 0x7;
    fields.n = fields.d;
    fields.m = (instr & (0x7 << 3)) >> 3;
    return fields;
}

static int eorRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t result;

    result = getReg(pContext, fields.n) ^ getReg(pContext, fields.m);
    updateRdAndNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static int lslRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields       fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t     shiftN;
    ShiftResults shiftResults;

    shiftN = getReg(pContext, fields.m) & 0xFF;
    shiftResults = shift_C(getReg(pContext, fields.n), SRType_LSL, shiftN, pContext->xPSR & APSR_C);
    updateRdAndNZC(pContext, &fields, &shiftResults);
    return PINKYSIM_STEP_OK;
}

static int lsrRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields       fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t     shiftN;
    ShiftResults shiftResults;

    shiftN = getReg(pContext, fields.m) & 0xFF;
    shiftResults = shift_C(getReg(pContext, fields.n), SRType_LSR, shiftN, pContext->xPSR & APSR_C);
    updateRdAndNZC(pContext, &fields, &shiftResults);
    return PINKYSIM_STEP_OK;
}

static int asrRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields       fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t     shiftN;
    ShiftResults shiftResults;

    shiftN = getReg(pContext, fields.m) & 0xFF;
    shiftResults = shift_C(getReg(pContext, fields.n), SRType_ASR, shiftN, pContext->xPSR & APSR_C);
    updateRdAndNZC(pContext, &fields, &shiftResults);
    return PINKYSIM_STEP_OK;
}

static int adcRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRm5to3_Rdn2to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), getReg(pContext, fields.m), pContext->xPSR & APSR_C);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int sbcRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields      fields = decodeRm5to3_Rdn2to0(instr);
    AddResults  addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), ~getReg(pContext, fields.m), pContext->xPSR & APSR_C);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int rorRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields       fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t     shiftN;
    ShiftResults shiftResults;

    shiftN = getReg(pContext, fields.m) & 0xFF;
    shiftResults = shift_C(getReg(pContext, fields.n), SRType_ROR, shiftN, pContext->xPSR & APSR_C);
    updateRdAndNZC(pContext, &fields, &shiftResults);
    return PINKYSIM_STEP_OK;
}

static int tstRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t result;

    result = getReg(pContext, fields.n) & getReg(pContext, fields.m);
    updateNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static int rsbRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields      fields = decodeRn5to3_Rd2to0(instr);
    uint32_t    imm32 = 0;
    AddResults  addResults;

    addResults = addWithCarry(~getReg(pContext, fields.n), imm32, 1);
    updateRdAndNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRn5to3_Rd2to0(uint32_t instr)
{
    Fields fields;

    fields.d = instr & 0x7;
    fields.n = (instr & (0x7 << 3)) >> 3;
    return fields;
}

static int cmpRegisterT1(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRm5to3_Rdn2to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), ~getReg(pContext, fields.m), 1);
    updateNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int cmnRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRm5to3_Rdn2to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, fields.n), getReg(pContext, fields.m), 0);
    updateNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int orrRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t   result;

    result = getReg(pContext, fields.n) | getReg(pContext, fields.m);
    updateRdAndNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static int mulRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields    fields = decodeRn5to3_Rdm2to0(instr);
    uint32_t  operand1 = getReg(pContext, fields.n);
    uint32_t  operand2 = getReg(pContext, fields.m);
    uint32_t  result = operand1 * operand2;

    updateRdAndNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRn5to3_Rdm2to0(uint32_t instr)
{
    Fields fields;

    fields.d = instr & 0x7;
    fields.m = fields.d;
    fields.n = (instr & (0x7 << 3)) >> 3;
    return fields;
}

static int bicRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t result;

    result = getReg(pContext, fields.n) & ~getReg(pContext, fields.m);
    updateRdAndNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static int mvnRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t result;

    result = ~getReg(pContext, fields.m);
    updateRdAndNZ(pContext, &fields, result);
    return PINKYSIM_STEP_OK;
}

static int specialDataAndBranchExchange(PinkySimContext* pContext, uint16_t instr)
{
    int result = PINKYSIM_STEP_UNDEFINED;

    if ((instr & 0x0300) == 0x0000)
        result = addRegisterT2(pContext, instr);
    else if ((instr & 0x03C0) == 0x0100)
        __throw(unpredictableException)
    else if (((instr & 0x03C0) == 0x0140) || ((instr & 0x0380) == 0x0180))
        result = cmpRegisterT2(pContext, instr);
    else if ((instr & 0x0300) == 0x0200)
        result = movRegister(pContext, instr);
    else if ((instr & 0x0380) == 0x0300)
        result = bx(pContext, instr);
    else if ((instr & 0x0380) == 0x0380)
        result = blx(pContext, instr);
    return result;
}

static int addRegisterT2(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRdn7and2to0_Rm6to3(instr);
    AddResults      addResults;

    if (fields.d == 15 && fields.m == 15)
        __throw(unpredictableException);

    addResults = addWithCarry(getReg(pContext, fields.n), getReg(pContext, fields.m), 0);
    if (fields.d == 15)
        aluWritePC(pContext, addResults.result);
    else
        setReg(pContext, fields.d, addResults.result);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRdn7and2to0_Rm6to3(uint32_t instr)
{
    Fields fields;

    fields.d = ((instr & (1 << 7)) >> 4) | (instr & 0x7);
    fields.n = fields.d;
    fields.m = (instr & (0xF << 3)) >> 3;
    return fields;
}

static void aluWritePC(PinkySimContext* pContext, uint32_t address)
{
    branchWritePC(pContext, address);
}

static void branchWritePC(PinkySimContext* pContext, uint32_t address)
{
    branchTo(pContext, address & 0xFFFFFFFE);
}

static void branchTo(PinkySimContext* pContext, uint32_t address)
{
    pContext->newPC = address;
}

static int cmpRegisterT2(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRdn7and2to0_Rm6to3(instr);
    AddResults      addResults;

    if (fields.n == 15 || fields.m == 15)
        __throw(unpredictableException);

    addResults = addWithCarry(getReg(pContext, fields.n), ~getReg(pContext, fields.m), 1);
    updateNZCV(pContext, &fields, &addResults);
    return PINKYSIM_STEP_OK;
}

static int movRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRdn7and2to0_Rm6to3(instr);
    uint32_t        result;

    result = getReg(pContext, fields.m);
    if (fields.d == 15)
        aluWritePC(pContext, result);
    else
        setReg(pContext, fields.d, result);
    return PINKYSIM_STEP_OK;
}

static int bx(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRdn7and2to0_Rm6to3(instr);

    if ((instr & 0x7) != 0x0)
        __throw(unpredictableException);
    if (fields.m == 15)
        __throw(unpredictableException);

    bxWritePC(pContext, getReg(pContext, fields.m));
    return PINKYSIM_STEP_OK;
}

static void bxWritePC(PinkySimContext* pContext, uint32_t address)
{
    // NOTE: Don't support exception handlers in this simulator so no need to check for return from exception handler.
    //if (pContext->currentMode == modeHandler && (address & 0xF000) == 0xF000)
    //    ExceptionReturn(pContext, address & ((1 << 27) - 1));
    // else
    pContext->xPSR &= ~EPSR_T;
    if (address & 1)
        pContext->xPSR |= EPSR_T;
    branchTo(pContext, address & 0xFFFFFFFE);
}

static int blx(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRdn7and2to0_Rm6to3(instr);
    uint32_t target;
    uint32_t nextInstrAddr;

    if ((instr & 0x7) != 0x0)
        __throw(unpredictableException);
    if (fields.m == 15)
        __throw(unpredictableException);

    target = getReg(pContext, fields.m);
    nextInstrAddr = getReg(pContext, PC) - 2;
    setReg(pContext, LR, nextInstrAddr | 1);
    blxWritePC(pContext, target);
    return PINKYSIM_STEP_OK;
}

static void blxWritePC(PinkySimContext* pContext, uint32_t address)
{
    pContext->xPSR &= ~EPSR_T;
    if (address & 1)
        pContext->xPSR |= EPSR_T;
    branchTo(pContext, address & 0xFFFFFFFE);
}

static int ldrLiteral(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRt10to8_Imm7to0Shift2(instr);
    uint32_t base;
    uint32_t address;

    base = align(getReg(pContext, PC), 4);
    address = base + fields.imm;
    setReg(pContext, fields.t, unalignedMemRead(pContext, address, 4));
    return PINKYSIM_STEP_OK;
}

static Fields decodeRt10to8_Imm7to0Shift2(uint32_t instr)
{
    Fields fields;

    fields.t = (instr & (0x7 << 8)) >> 8;
    fields.imm = (instr & 0xFF) << 2;
    return fields;
}

static uint32_t align(uint32_t value, uint32_t alignment)
{
    assert (alignment == 2 || alignment == 4);
    return value & ~(alignment - 1);
}

static uint32_t unalignedMemRead(PinkySimContext* pContext, uint32_t address, uint32_t size)
{
    // NOTE: All memory accesses must be aligned on ARMv6-M.
    return alignedMemRead(pContext, address, size);
}

static uint32_t alignedMemRead(PinkySimContext* pContext, uint32_t address, uint32_t size)
{
    uint32_t result = 0xFFFFFFFF;

    assert (size == 4 || size == 2 || size == 1);

    if (!isAligned(address, size))
        __throw(alignmentException);

    switch (size)
    {
    case 1:
        result = IMemory_Read8(pContext->pMemory, address);
        break;
    case 2:
        result = IMemory_Read16(pContext->pMemory, address);
        break;
    case 4:
        result = IMemory_Read32(pContext->pMemory, address);
        break;
    }
    return result;
}

static int isAligned(uint32_t address, uint32_t size)
{
    assert (size == 4 || size == 2 || size == 1);

    return address == (address & ~(size - 1));
}

static int loadStoreSingleDataItem(PinkySimContext* pContext, uint16_t instr)
{
    int result = PINKYSIM_STEP_UNDEFINED;

    if ((instr & 0xFE00) == 0x5000)
        result = strRegister(pContext, instr);
    else if ((instr & 0xFE00) == 0x5200)
        result = strhRegister(pContext, instr);
    else if ((instr & 0xFE00) == 0x5400)
        result = strbRegister(pContext, instr);
    else if ((instr & 0xFE00) == 0x5600)
        result = ldrsbRegister(pContext, instr);
    else if ((instr & 0xFE00) == 0x5800)
        result = ldrRegister(pContext, instr);
    else if ((instr & 0xFE00) == 0x5A00)
        result = ldrhRegister(pContext, instr);
    else if ((instr & 0xFE00) == 0x5C00)
        result = ldrbRegister(pContext, instr);
    else if ((instr & 0xFE00) == 0x5E00)
        result = ldrshRegister(pContext, instr);
    else if ((instr & 0xF800) == 0x6000)
        result = strImmediateT1(pContext, instr);
    else if ((instr & 0xF800) == 0x6800)
        result = ldrImmediateT1(pContext, instr);
    else if ((instr & 0xF800) == 0x7000)
        result = strbImmediate(pContext, instr);
    else if ((instr & 0xF800) == 0x7800)
        result = ldrbImmediate(pContext, instr);
    else if ((instr & 0xF800) == 0x8000)
        result = strhImmediate(pContext, instr);
    else if ((instr & 0xF800) == 0x8800)
        result = ldrhImmediate(pContext, instr);
    else if ((instr & 0xF800) == 0x9000)
        result = strImmediateT2(pContext, instr);
    else if ((instr & 0xF800) == 0x9800)
        result = ldrImmediateT2(pContext, instr);
    return result;
}

static int strRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    unalignedMemWrite(pContext, address, 4, getReg(pContext, fields.t));
    return PINKYSIM_STEP_OK;
}

static Fields decodeRm8to6_Rn5to3_Rt2to0(uint32_t instr)
{
    Fields fields;

    fields.t = instr & 0x7;
    fields.n = (instr & (0x7 << 3)) >> 3;
    fields.m = (instr & (0x7 << 6)) >> 6;
    return fields;
}

static void unalignedMemWrite(PinkySimContext* pContext, uint32_t address, uint32_t size, uint32_t value)
{
    // NOTE: All memory accesses must be aligned on ARMv6-M.
    alignedMemWrite(pContext, address, size, value);
}

static void alignedMemWrite(PinkySimContext* pContext, uint32_t address, uint32_t size, uint32_t value)
{
    assert (size == 4 || size == 2 || size == 1);

    if (!isAligned(address, size))
        __throw(alignmentException);

    switch (size)
    {
    case 4:
        IMemory_Write32(pContext->pMemory, address, value);
        break;
    case 2:
        IMemory_Write16(pContext->pMemory, address, value);
        break;
    case 1:
        IMemory_Write8(pContext->pMemory, address, value);
        break;
    }
}

static int strhRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    unalignedMemWrite(pContext, address, 2, getReg(pContext, fields.t));
    return PINKYSIM_STEP_OK;
}

static int strbRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    unalignedMemWrite(pContext, address, 1, getReg(pContext, fields.t));
    return PINKYSIM_STEP_OK;
}

static int ldrsbRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    setReg(pContext, fields.t, signExtend8(unalignedMemRead(pContext, address, 1)));
    return PINKYSIM_STEP_OK;
}

static uint32_t signExtend8(uint32_t valueToExtend)
{
    return (uint32_t)(((int32_t)valueToExtend << 24) >> 24);
}

static int ldrRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    setReg(pContext, fields.t, unalignedMemRead(pContext, address, 4));
    return PINKYSIM_STEP_OK;
}

static int ldrhRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;
    uint32_t data;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    data = unalignedMemRead(pContext, address, 2);
    setReg(pContext, fields.t, zeroExtend16(data));
    return PINKYSIM_STEP_OK;
}

static uint32_t zeroExtend16(uint32_t value)
{
    return value & 0xFFFF;
}

static int ldrbRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    setReg(pContext, fields.t, zeroExtend8(unalignedMemRead(pContext, address, 1)));
    return PINKYSIM_STEP_OK;
}

static uint32_t zeroExtend8(uint32_t value)
{
    return value & 0xFF;
}

static int ldrshRegister(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm8to6_Rn5to3_Rt2to0(instr);
    uint32_t address;
    uint32_t data;

    address = getReg(pContext, fields.n) + getReg(pContext, fields.m);
    data = unalignedMemRead(pContext, address, 2);
    setReg(pContext, fields.t, signExtend16(data));
    return PINKYSIM_STEP_OK;
}

static uint32_t signExtend16(uint32_t valueToExtend)
{
    return (uint32_t)(((int32_t)valueToExtend << 16) >> 16);
}

static int strImmediateT1(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeImm10to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + (fields.imm << 2);
    unalignedMemWrite(pContext, address, 4, getReg(pContext, fields.t));
    return PINKYSIM_STEP_OK;
}

static Fields decodeImm10to6_Rn5to3_Rt2to0(uint32_t instr)
{
    Fields fields;

    fields.t = instr & 0x7;
    fields.n = (instr & (0x7 << 3)) >> 3;
    fields.imm = (instr & (0x1F << 6)) >> 6;
    return fields;
}

static int ldrImmediateT1(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeImm10to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + (fields.imm << 2);
    setReg(pContext, fields.t, unalignedMemRead(pContext, address, 4));
    return PINKYSIM_STEP_OK;
}

static int strbImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeImm10to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + fields.imm;
    unalignedMemWrite(pContext, address, 1, getReg(pContext, fields.t));
    return PINKYSIM_STEP_OK;
}

static int ldrbImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeImm10to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + fields.imm;
    setReg(pContext, fields.t, unalignedMemRead(pContext, address, 1));
    return PINKYSIM_STEP_OK;
}

static int strhImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeImm10to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + (fields.imm << 1);
    unalignedMemWrite(pContext, address, 2, getReg(pContext, fields.t));
    return PINKYSIM_STEP_OK;
}

static int ldrhImmediate(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeImm10to6_Rn5to3_Rt2to0(instr);
    uint32_t address;

    address = getReg(pContext, fields.n) + (fields.imm << 1);
    setReg(pContext, fields.t, unalignedMemRead(pContext, address, 2));
    return PINKYSIM_STEP_OK;
}

static int strImmediateT2(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRt10to8_Imm7to0Shift2(instr);
    uint32_t n = SP;
    uint32_t address;

    address = getReg(pContext, n) + fields.imm;
    unalignedMemWrite(pContext, address, 4, getReg(pContext, fields.t));
    return PINKYSIM_STEP_OK;
}

static int ldrImmediateT2(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRt10to8_Imm7to0Shift2(instr);
    uint32_t n = SP;
    uint32_t address;

    address = getReg(pContext, n) + fields.imm;
    setReg(pContext, fields.t, unalignedMemRead(pContext, address, 4));
    return PINKYSIM_STEP_OK;
}

static int adr(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRd10to8_Imm7to0(instr);
    uint32_t result;

    result = align(getReg(pContext, PC), 4) + (fields.imm << 2);
    setReg(pContext, fields.d, result);
    return PINKYSIM_STEP_OK;
}

static int addSPT1(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRd10to8_Imm7to0(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, SP), (fields.imm << 2), 0);
    setReg(pContext, fields.d, addResults.result);
    return PINKYSIM_STEP_OK;
}

static int misc16BitInstructions(PinkySimContext* pContext, uint16_t instr)
{
    int result = PINKYSIM_STEP_UNDEFINED;

    if ((instr & 0x0F80) == 0x0000)
        result = addSPT2(pContext, instr);
    else if ((instr & 0x0F80) == 0x0080)
        result = subSP(pContext, instr);
    else if ((instr & 0x0FC0) == 0x0200)
        result = sxth(pContext, instr);
    else if ((instr & 0x0FC0) == 0x0240)
        result = sxtb(pContext, instr);
    else if ((instr & 0x0FC0) == 0x0280)
        result = uxth(pContext, instr);
    else if ((instr & 0x0FC0) == 0x02C0)
        result = uxtb(pContext, instr);
    else if ((instr & 0x0E00) == 0x0400)
        result = push(pContext, instr);
    else if ((instr & 0x0FE0) == 0x0660)
        result = cps(pContext, instr);
    else if ((instr & 0x0FC0) == 0x0A00)
        result = rev(pContext, instr);
    else if ((instr & 0x0FC0) == 0x0A40)
        result = rev16(pContext, instr);
    else if ((instr & 0x0FC0) == 0x0AC0)
        result = revsh(pContext, instr);
    else if ((instr & 0x0E00) == 0x0C00)
        result = pop(pContext, instr);
    else if ((instr & 0x0F00) == 0x0E00)
        __throw(bkptException)
    else if ((instr & 0x0F00) == 0x0F00)
        result = hints(pContext, instr);
    return result;
}

static int addSPT2(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRdisSP_Imm6to0Shift2(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, SP), fields.imm, 0);
    setReg(pContext, fields.d, addResults.result);
    return PINKYSIM_STEP_OK;
}

static Fields decodeRdisSP_Imm6to0Shift2(uint32_t instr)
{
    Fields fields;

    fields.d = SP;
    fields.imm = (instr & 0x7F) << 2;
    return fields;
}

static int subSP(PinkySimContext* pContext, uint16_t instr)
{
    Fields     fields = decodeRdisSP_Imm6to0Shift2(instr);
    AddResults addResults;

    addResults = addWithCarry(getReg(pContext, SP), ~fields.imm, 1);
    setReg(pContext, fields.d, addResults.result);
    return PINKYSIM_STEP_OK;
}

static int sxth(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRm5to3_Rdn2to0(instr);

    setReg(pContext, fields.d, signExtend16(getReg(pContext, fields.m)));
    return PINKYSIM_STEP_OK;
}

static int sxtb(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRm5to3_Rdn2to0(instr);

    setReg(pContext, fields.d, signExtend8(getReg(pContext, fields.m)));
    return PINKYSIM_STEP_OK;
}

static int uxth(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRm5to3_Rdn2to0(instr);

    setReg(pContext, fields.d, zeroExtend16(getReg(pContext, fields.m)));
    return PINKYSIM_STEP_OK;
}

static int uxtb(PinkySimContext* pContext, uint16_t instr)
{
    Fields fields = decodeRm5to3_Rdn2to0(instr);

    setReg(pContext, fields.d, zeroExtend8(getReg(pContext, fields.m)));
    return PINKYSIM_STEP_OK;
}

static int push(PinkySimContext* pContext, uint16_t instr)
{
    uint32_t    registers = ((instr & (1 << 8)) << 6) | (instr & 0xFF);
    uint32_t    address;
    int         i;

    if (bitCount(registers) < 1)
        __throw(unpredictableException);

    address = getReg(pContext, SP) - 4 * bitCount(registers);
    for (i = 0 ; i <= 14 ; i++)
    {
        if (registers & (1 << i))
        {
            alignedMemWrite(pContext, address, 4, getReg(pContext, i));
            address += 4;
        }
    }
    setReg(pContext, SP, getReg(pContext, SP) - 4 * bitCount(registers));
    return PINKYSIM_STEP_OK;
}

static uint32_t bitCount(uint32_t value)
{
    uint32_t count = 0;

    while (value)
    {
        value = value & (value - 1);
        count++;
    }
    return count;
}

static int cps(PinkySimContext* pContext, uint16_t instr)
{
    uint32_t im = instr & (1 << 4);

    if ((instr & 0xF) != 0x2)
        __throw(unpredictableException);

    if (currentModeIsPrivileged(pContext))
    {
        if (im)
            pContext->PRIMASK |= PRIMASK_PM;
        else
            pContext->PRIMASK &= ~PRIMASK_PM;
    }
    return PINKYSIM_STEP_OK;
}

static int currentModeIsPrivileged(PinkySimContext* pContext)
{
    // NOTE: This simulator only supports privileged mode.
    return TRUE;
}

static int rev(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t value;
    uint32_t result;

    value = getReg(pContext, fields.m);
    result = (value << 24) | (value >> 24) | ((value & 0xFF00) << 8) | ((value & 0xFF0000) >> 8);
    setReg(pContext, fields.d, result);
    return PINKYSIM_STEP_OK;
}

static int rev16(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t value;
    uint32_t result;

    value = getReg(pContext, fields.m);
    result = ((value & 0xFF00FF00) >> 8) | ((value & 0x00FF00FF) << 8);
    setReg(pContext, fields.d, result);
    return PINKYSIM_STEP_OK;
}

static int revsh(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRm5to3_Rdn2to0(instr);
    uint32_t value;
    uint32_t result;

    value = getReg(pContext, fields.m);
    result = ((value & 0xFF00FF00) >> 8) | ((value & 0x00FF00FF) << 8);
    setReg(pContext, fields.d, signExtend16(result));
    return PINKYSIM_STEP_OK;
}

static int pop(PinkySimContext* pContext, uint16_t instr)
{
    uint32_t    registers = ((instr & (1 << 8)) << 7) | (instr & 0xFF);
    uint32_t    address;
    int         i;

    if (bitCount(registers) < 1)
        __throw(unpredictableException);

    address = getReg(pContext, SP);
    for (i = 0 ; i <= 7 ; i++)
    {
        if (registers & (1 << i))
        {
            setReg(pContext, i, alignedMemRead(pContext, address, 4));
            address += 4;
        }
    }
    if (registers & (1 << 15))
        loadWritePC(pContext, alignedMemRead(pContext, address, 4));
    setReg(pContext, SP, getReg(pContext, SP) + 4 * bitCount(registers));
    return PINKYSIM_STEP_OK;
}

static void loadWritePC(PinkySimContext* pContext, uint32_t address)
{
    bxWritePC(pContext, address);
}

static int hints(PinkySimContext* pContext, uint16_t instr)
{
    uint32_t opA = (instr & (0x00F0)) >> 4;
    uint32_t opB = instr & 0x000F;
    int      result = PINKYSIM_STEP_UNDEFINED;

    if (opB != 0x0000)
        __throw(undefinedException);
    switch (opA)
    {
    case 0:
        result = nop(pContext, instr);
        break;
    case 1:
        result = yield(pContext, instr);
        break;
    case 2:
        result = wfe(pContext, instr);
        break;
    case 3:
        result = wfi(pContext, instr);
        break;
    case 4:
        result = sev(pContext, instr);
        break;
    default:
        result = treatAsNop(pContext, instr);
        break;
    }
    return result;
}

static int nop(PinkySimContext* pContext, uint16_t instr)
{
    return PINKYSIM_STEP_OK;
}

static int yield(PinkySimContext* pContext, uint16_t instr)
{
    return PINKYSIM_STEP_UNSUPPORTED;
}

static int wfe(PinkySimContext* pContext, uint16_t instr)
{
    return PINKYSIM_STEP_UNSUPPORTED;
}

static int wfi(PinkySimContext* pContext, uint16_t instr)
{
    return PINKYSIM_STEP_UNSUPPORTED;
}

static int sev(PinkySimContext* pContext, uint16_t instr)
{
    return PINKYSIM_STEP_UNSUPPORTED;
}

static int treatAsNop(PinkySimContext* pContext, uint16_t instr)
{
    return PINKYSIM_STEP_OK;
}

static int stm(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRn10to8RegisterList7to0(instr);
    uint32_t address;
    int      i;

    if (bitCount(fields.registers) < 1)
        __throw(unpredictableException);
    if ((fields.registers & (1 << fields.n)) && isNotLowestBitSet(fields.registers, fields.n))
        __throw(unpredictableException);

    address = getReg(pContext, fields.n);
    for (i = 0 ; i <= 14 ; i++)
    {
        if (fields.registers & (1 << i))
        {
            alignedMemWrite(pContext, address, 4, getReg(pContext, i));
            address += 4;
        }
    }
    setReg(pContext, fields.n, getReg(pContext, fields.n) + 4 * bitCount(fields.registers));
    return PINKYSIM_STEP_OK;
}

static Fields decodeRn10to8RegisterList7to0(uint32_t instr)
{
    Fields fields;

    fields.n = (instr & (7 << 8)) >> 8;
    fields.registers = instr & 0xFF;
    return fields;
}

static int isNotLowestBitSet(uint32_t bits, uint32_t i)
{
    return (int)(((1 << i) - 1) & bits);
}

static int ldm(PinkySimContext* pContext, uint16_t instr)
{
    Fields   fields = decodeRn10to8RegisterList7to0(instr);
    int      wback = (0 == (fields.registers & (1 << fields.n)));
    uint32_t address;
    int      i;

    if (bitCount(fields.registers) < 1)
        __throw(unpredictableException);

    address = getReg(pContext, fields.n);
    for (i = 0 ; i <= 7 ; i++)
    {
        if (fields.registers & (1 << i))
        {
            setReg(pContext, i, alignedMemRead(pContext, address, 4));
            address += 4;
        }
    }
    if (wback)
        setReg(pContext, fields.n, getReg(pContext, fields.n) + 4 * bitCount(fields.registers));
    return PINKYSIM_STEP_OK;
}

static int conditionalBranchAndSupervisor(PinkySimContext* pContext, uint16_t instr)
{
    if ((instr & 0x0F00) == 0x0E00)
        __throw(undefinedException)
    else if ((instr & 0x0F00) == 0x0F00)
        return svc(pContext, instr);
    else
        return conditionalBranch(pContext, instr);
}

static int svc(PinkySimContext* pContext, uint16_t instr)
{
    return PINKYSIM_STEP_SVC;
}

static int conditionalBranch(PinkySimContext* pContext, uint16_t instr)
{
    if (conditionPassedForBranchInstr(pContext, instr))
    {
        int32_t imm32 = (((int32_t)(instr & 0xFF)) << 24) >> 23;

        branchWritePC(pContext, getReg(pContext, PC) + imm32);
    }
    return PINKYSIM_STEP_OK;
}

static int conditionPassedForBranchInstr(PinkySimContext* pContext, uint16_t instr)
{
    uint32_t cond = (instr & 0x0F00) >> 8;
    uint32_t apsr = pContext->xPSR;
    int      result = FALSE;

    switch (cond >> 1)
    {
    case 0:
        result = ((apsr & APSR_Z) == APSR_Z);
        break;
    case 1:
        result = ((apsr & APSR_C) == APSR_C);
        break;
    case 2:
        result = ((apsr & APSR_N) == APSR_N);
        break;
    case 3:
        result = ((apsr & APSR_V) == APSR_V);
        break;
    case 4:
        result = ((apsr & APSR_C) == APSR_C) && ((apsr & APSR_Z) == 0);
        break;
    case 5:
        result = (!!(apsr & APSR_N) == !!(apsr & APSR_V));
        break;
    case 6:
        result = ((!!(apsr & APSR_N) == !!(apsr & APSR_V)) && ((apsr & APSR_Z) == 0));
        break;
    // NOTE: Can't be used as a condition code in ARMv6-M
    //case 7:
    //    result = TRUE;
    }
    if ((cond & 1) && (cond != 0xF))
        result = !result;
    return result;
}

static int unconditionalBranch(PinkySimContext* pContext, uint16_t instr)
{
    int32_t imm32 = (((int32_t)(instr & 0x7FF)) << 21) >> 20;

    branchWritePC(pContext, getReg(pContext, PC) + imm32);
    return PINKYSIM_STEP_OK;
}

static int executeInstruction32(PinkySimContext* pContext, uint16_t instr1)
{
    int      result = PINKYSIM_STEP_UNDEFINED;
    uint16_t instr2;

    pContext->newPC = pContext->pc + 4;
    instr2 =  IMemory_Read16(pContext->pMemory, pContext->pc + 2);

    if ((instr1 & 0x1800) == 0x1000 && (instr2 & 0x8000) == 0x8000)
        result = branchAndMiscellaneousControl(pContext, instr1, instr2);
    return result;
}

static int branchAndMiscellaneousControl(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    if ((instr2 & 0x5000) == 0x0000 && (instr1 & 0x07E0) == 0x0380)
        return msr(pContext, instr1, instr2);
    else if ((instr2 & 0x5000) == 0x0000 && (instr1 & 0x07F0) == 0x03B0)
        return miscellaneousControl(pContext, instr1, instr2);
    else if ((instr2 & 0x5000) == 0x0000 && (instr1 & 0x07E0) == 0x03E0)
        return mrs(pContext, instr1, instr2);
    else if ((instr2 & 0x5000) == 0x5000)
        return bl(pContext, instr1, instr2);

    __throw(undefinedException);
}

static int msr(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    uint32_t n = instr1 & 0xF;
    uint32_t SYSm = instr2 & 0xFF;
    uint32_t value;

    if (n == 13 || n == 15)
        __throw(unpredictableException);
    if (SYSm == 4 || (SYSm > 9 && SYSm < 16) || (SYSm > 16 && SYSm < 20) || (SYSm > 20))
        __throw(unpredictableException);
    if ((instr1 & 0x0010) != 0x0000 || (instr2 & 0x3F00) != 0x0800)
        __throw(unpredictableException);

    value = getReg(pContext, n);
    switch (SYSm >> 3)
    {
    case 0:
        if ((SYSm & (1 << 2)) == 0)
            pContext->xPSR = (pContext->xPSR & ~APSR_NZCV) | (value & APSR_NZCV);
        break;
    case 1:
        if (currentModeIsPrivileged(pContext))
        {
            switch (SYSm & 0x7)
            {
            case 0:
                pContext->spMain = value & 0xFFFFFFFC;
                break;
            case 1:
                // NOTE: This simulator doesn't support process stack usage.
                break;
            }
        }
        break;
    case 2:
        if (currentModeIsPrivileged(pContext))
        {
            switch (SYSm & 0x7)
            {
            case 0:
                pContext->PRIMASK = (pContext->PRIMASK & ~PRIMASK_PM) | (value & PRIMASK_PM);
                break;
            case 4:
                // NOTE: This simulator doesn't support thread mode.
                break;
            }
        }
        break;
    }
    return PINKYSIM_STEP_OK;
}

static int miscellaneousControl(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    int      result = PINKYSIM_STEP_UNDEFINED;

    if ((instr2 & 0x00F0) == 0x0040)
        result = dsb(pContext, instr1, instr2);
    else if ((instr2 & 0x00F0) == 0x0050)
        result = dmb(pContext, instr1, instr2);
    else if ((instr2 & 0x00F0) == 0x0060)
        result = isb(pContext, instr1, instr2);
    return result;
}

static int dsb(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    if ((instr1 & 0x000F) != 0x000F || (instr2 & 0x2F00) != 0x0F00)
        __throw(unpredictableException);
    return PINKYSIM_STEP_OK;
}

static int dmb(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    if ((instr1 & 0x000F) != 0x000F || (instr2 & 0x2F00) != 0x0F00)
        __throw(unpredictableException);
    return PINKYSIM_STEP_OK;
}

static int isb(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    if ((instr1 & 0x000F) != 0x000F || (instr2 & 0x2F00) != 0x0F00)
        __throw(unpredictableException);
    return PINKYSIM_STEP_OK;
}

static int mrs(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    uint32_t d = (instr2 & (0xF << 8)) >> 8;
    uint32_t SYSm = instr2 & 0xFF;
    uint32_t value = 0;

    if (d == 13 || d == 15)
        __throw(unpredictableException);
    if (SYSm == 4 || (SYSm > 9 && SYSm < 16) || (SYSm > 16 && SYSm < 20) || (SYSm > 20))
        __throw(unpredictableException);
    if ((instr1 & 0x001F) != 0x000F || (instr2 & 0x2000) != 0x0000)
        __throw(unpredictableException);

    switch (SYSm >> 3)
    {
    case 0:
        if ((SYSm & (1 << 0)) && currentModeIsPrivileged(pContext))
            value |= pContext->xPSR & IPSR_MASK;
        if ((SYSm & (1 << 1)))
            value |= 0; /* T-bit reads as zero on ARMv-6m */
        if ((SYSm & (1 << 2)) == 0)
            value |= pContext->xPSR & APSR_NZCV;
        break;
    case 1:
        if (currentModeIsPrivileged(pContext))
        {
            switch (SYSm & 0x7)
            {
            case 0:
                value = pContext->spMain;
                break;
            case 1:
                // NOTE: This simulator doesn't support process stack usage.
                break;
            }
        }
        break;
    case 2:
        switch (SYSm & 0x7)
        {
        case 0:
            value = pContext->PRIMASK & PRIMASK_PM;
            break;
        case 4:
            value = pContext->CONTROL;
            break;
        }
        break;
    }
    setReg(pContext, d, value);
    return PINKYSIM_STEP_OK;
}

static int bl(PinkySimContext* pContext, uint16_t instr1, uint16_t instr2)
{
    uint32_t s = (instr1 & (1 << 10)) >> 10;
    uint32_t immHi = instr1 & 0x3FF;
    uint32_t j1 = (instr2 & (1 << 13)) >> 13;
    uint32_t j2 = (instr2 & (1 << 11)) >> 11;
    uint32_t immLo = (instr2 & 0x7FF);
    uint32_t i1 = (s ^ j1) ^ 1;
    uint32_t i2 = (s ^ j2) ^ 1;
    uint32_t imm32 = ((int32_t)((s << 24) | (i1 << 23) | (i2 << 22) | (immHi << 12) | (immLo << 1)) << 7) >> 7;
    uint32_t nextInstrAddr;

    nextInstrAddr = getReg(pContext, PC);
    setReg(pContext, LR, nextInstrAddr | 1);
    branchWritePC(pContext, getReg(pContext, PC) + imm32);
    return PINKYSIM_STEP_OK;
}
