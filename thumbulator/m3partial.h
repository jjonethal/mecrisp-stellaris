
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
void do_zflag ( uint32_t x )
{
   if(x==0) cpsr|=CPSR_Z; else cpsr&=~CPSR_Z;
}
//-------------------------------------------------------------------
void do_nflag ( uint32_t x )
{
   if(x&0x80000000) cpsr|=CPSR_N; else cpsr&=~CPSR_N;
}
//-------------------------------------------------------------------
void do_cflag ( uint32_t a, uint32_t b, uint32_t c )
{
   uint32_t rc;

   cpsr&=~CPSR_C;
   rc=(a&0x7FFFFFFF)+(b&0x7FFFFFFF)+c; //carry in
   rc = (rc>>31)+(a>>31)+(b>>31);  //carry out
   if(rc&2) cpsr|=CPSR_C;
}
//-------------------------------------------------------------------
void do_vflag ( uint32_t a, uint32_t b, uint32_t c )
{
   uint32_t rc;
   uint32_t rd;

   cpsr&=~CPSR_V;
   rc=(a&0x7FFFFFFF)+(b&0x7FFFFFFF)+c; //carry in
   rc>>=31; //carry in in lsbit
   rd=(rc&1)+((a>>31)&1)+((b>>31)&1); //carry out
   rd>>=1; //carry out in lsbit
   rc=(rc^rd)&1; //if carry in != carry out then signed overflow
   if(rc) cpsr|=CPSR_V;
}
//-------------------------------------------------------------------
void do_cflag_bit ( uint32_t x )
{
  if(x) cpsr|=CPSR_C; else cpsr&=~CPSR_C;
}
//-------------------------------------------------------------------
void do_vflag_bit ( uint32_t x )
{
  if(x) cpsr|=CPSR_V; else cpsr&=~CPSR_V;
}
//-------------------------------------------------------------------


//-------------------------------------------------------------------------------------------------------------------------
// Schnippsel aus dem ARMUE
//-------------------------------------------------------------------------------------------------------------------------

// Decoding tools copied from ARMUE

static inline uint32_t _ASR32(uint32_t val, int amount) { return (uint32_t)((int32_t)val >> amount); }
#define HIGH_BIT32(value, bit_num) ((value) & (0xFFFFFFFF << (32-(bit_num))))
#define LOW_BIT32(value, bit_num)  ((value) & (0xFFFFFFFF >> (32-(bit_num))))
#define LOW_BIT16(value, bit_num)  ((value) & (0xFFFF     >> (16-(bit_num))))


/* general decoding */
#define DATA_PROCESS32_RN(ins_code) LOW_BIT32((ins_code) >> 16, 4)
#define DATA_PROCESS32_RD(ins_code) LOW_BIT32((ins_code) >> 8, 4)
#define DATA_PROCESS32_RM(ins_code) LOW_BIT32((ins_code), 4)
#define DATA_PROCESS32_S(ins_code) LOW_BIT32((ins_code) >> 20, 1)
#define DATA_PROCESS32_IMM3(ins_code) LOW_BIT32((ins_code) >> 12, 3)

/* shifted register decoding */
#define DATA_PROCESS32_IMM2(ins_code) LOW_BIT32((ins_code) >> 6, 2) // used in plain immediate decoding as well
#define DATA_PROCESS32_TYPE(ins_code) LOW_BIT32((ins_code) >> 4, 2)

/* modified immediate & plain bianry immediate decoding */
#define DATA_PROCESS32_IMM8(ins_code) LOW_BIT32((ins_code), 8)
#define DATA_PROCESS32_I(ins_code) LOW_BIT32((ins_code) >> 26, 1)
#define DATA_PROCESS32_I_IMM3_IMM8(ins_code) (DATA_PROCESS32_I(ins_code) << 11 | DATA_PROCESS32_IMM3(ins_code) << 8 | DATA_PROCESS32_IMM8(ins_code))

/* plain binary immediate decoding */
#define DATA_PROCESS32_IMM3_IMM2(ins_code) (DATA_PROCESS32_IMM3(ins_code) << 2 | DATA_PROCESS32_IMM2(ins_code))
#define DATA_PROCESS32_IMM4(ins_code) LOW_BIT32((ins_code) >> 16, 4)
#define DATA_PROCESS32_IMM4_I_IMM3_IMM8(ins_code) (DATA_PROCESS32_IMM4(ins_code) << 12 | DATA_PROCESS32_I_IMM3_IMM8(ins_code))
#define _DATA_PROCESS32_LOWBIT5(ins_code) LOW_BIT32((ins_code), 5)
#define DATA_PROCESS32_SAT_IMM(ins_code) _DATA_PROCESS32_LOWBIT5(ins_code)
#define DATA_PROCESS32_WIDTHM1(ins_code) _DATA_PROCESS32_LOWBIT5(ins_code)
#define DATA_PROCESS32_MSB(ins_code) _DATA_PROCESS32_LOWBIT5(ins_code)
#define DATA_PROCESS32_SH(ins_code) LOW_BIT32((ins_code) >> 21, 1)

/* register decoding */
#define DATA_PROCESS32_REG_OP2(ins_code) LOW_BIT32((ins_code) >> 4, 4)
#define DATA_PROCESS32_ROTATE(ins_code) LOW_BIT32((ins_code) >> 4, 2)


#define BIT_31 (0x1UL << 31)
#define BIT_1  (0x1UL << 1)
#define BIT_0  (0x1UL)

#define PSR_N (0x1UL << 31)
#define PSR_Z (0x1UL << 30)
#define PSR_C (0x1UL << 29)
#define PSR_V (0x1UL << 28)
#define PSR_Q (0x1UL << 27)
#define PSR_T (0x1UL << 24)

static inline uint8_t get_bit(uint32_t* reg, uint32_t bit_pos)
{
    return (*reg & bit_pos) == 0 ? 0: 1;
}

// if bit_val != 0 then set bit to 1. bit_pos is defined above
static inline void set_bit(uint32_t* reg, uint32_t bit_pos,int bit_val)
{
    if(bit_val == 0){
        *reg &= ~bit_pos;
    }else{
        *reg |= bit_pos;
    }
}

#define SET_PSR(val)  (cpsr = (val))
#define SET_APSR(val) (cpsr = (cpsr & ~0xF8000000ul) | (val))
#define SET_IPSR(val) (cpsr = (cpsr & ~0x000001FFul) | (val))
#define SET_APSR_N(result_reg) set_bit(&cpsr, PSR_N, (result_reg) & BIT_31)
#define SET_APSR_Z(result_reg) set_bit(&cpsr, PSR_Z, (result_reg) == 0 ? 1 : 0)
#define SET_APSR_C(carry)      set_bit(&cpsr, PSR_C, (carry))
#define SET_APSR_V(overflow)   set_bit(&cpsr, PSR_V, (overflow))
#define SET_APSR_Q(Q)          set_bit(&cpsr, PSR_Q, (Q))

#define GET_PSR    (cpsr)
#define GET_APSR   (cpsr & 0xF8000000ul)
#define GET_IPSR   (cpsr & 0x000001FFul)
#define GET_APSR_N get_bit(&cpsr, PSR_N)
#define GET_APSR_Z get_bit(&cpsr, PSR_Z)
#define GET_APSR_C get_bit(&cpsr, PSR_C)
#define GET_APSR_V get_bit(&cpsr, PSR_V)

inline uint32_t _ROR32(uint32_t val, int amount)
{
    uint32_t shift_out = val << (32 - amount);
    return val >> amount | shift_out;
}

void ROR_C(uint32_t val, int shift, uint32_t* result, int *carry_out)
{
    *carry_out = val >> (shift - 1) & BIT_0;
    *result = _ROR32(val, shift);
}

int ThumbExpandImm_C(uint32_t imm12, uint32_t carry_in, uint32_t *imm32, int*carry_out)
{
    uint32_t imm12_8 = LOW_BIT32(imm12, 8);
    if(((imm12 >> 10) & 0x3) == 0){
        switch((imm12 >> 8) & 0x3){
        case 0x0:
            *imm32 = imm12_8;
            break;
        case 0x1:
            if(imm12_8 == 0){
                return -1;
            }else{
                *imm32 = (imm12_8 << 16) | imm12_8;
            }
            break;
        case 0x2:
            if(imm12_8 == 0){
                return -2;
            }else{
                *imm32 = (imm12_8 << 24) | (imm12_8 << 8);
            }
            break;
        case 0x3:
            if(imm12_8 == 0){
                return -3;
            }else{
                *imm32 = (imm12_8 << 24) | (imm12_8 << 16) | (imm12_8 << 8) | imm12_8;
            }
            break;
        default:
            return -4;
        }
        *carry_out = carry_in;
    }else{
        uint32_t unrotated = (1ul << 7) | LOW_BIT32(imm12, 7);
        ROR_C(unrotated, LOW_BIT32(imm12 >> 7, 5), imm32, carry_out);
    }
    return 0;
}



/*<<ARMv7-M Architecture Reference Manual A2-43>>*/
inline void AddWithCarry(uint32_t op1, uint32_t op2, uint32_t carry_in, uint32_t* result, uint32_t* carry_out, uint32_t *overflow)
{
    /* uint64_t is 64bit */
    if(sizeof(uint64_t) == 8){
        uint64_t unsigned_sum = (uint64_t)op1 + (uint64_t)op2 + (uint64_t)carry_in;
        int64_t op1_64 = (int32_t)op1;
        int64_t op2_64 = (int32_t)op2;
        int64_t signed_sum = op1_64 + op2_64 + (int64_t)carry_in;
        uint32_t _result = unsigned_sum & 0xFFFFFFFFL;
        *overflow = (signed_sum == (int32_t)_result)? 0 : 1;
        *carry_out = (unsigned_sum == (uint64_t)_result) ? 0 : 1;
        *result = _result;

    /* general AddWithCarry if there isn't uint64_t */
    }else{
        // spilit 32 bit number to 2-16bit number
        uint16_t op1_low = op1 & 0xFFFF;
        uint16_t op1_high = (uint32_t)op1 >> 16;
        uint16_t op2_low = op2 & 0xFFFF;
        uint16_t op2_high = (op2) >> 16;

        // calculate low 16 bit carry
        int low_carry;
        uint32_t ulow_sum = (uint32_t)op1_low + (uint32_t)op2_low + (uint32_t)carry_in;
        uint32_t low_result = ulow_sum & 0xFFFF;
        low_carry = (ulow_sum == (uint32_t)low_result) ? 0 : 1;

        // calculate high 16 bit carry and overflow
        uint32_t uhigh_sum = (uint32_t)op1_high + (uint32_t)op2_high + (uint32_t)low_carry;
        int32_t op1_high_32 = (int16_t)op1_high;
        int32_t op2_high_32 = (int16_t)op2_high;
        int32_t shigh_sum = op1_high_32 + op2_high_32 + (int32_t)low_carry;
        uint16_t high_result = uhigh_sum & 0xFFFF;
        *overflow = (shigh_sum == (int16_t)high_result) ? 0 : 1;
        *carry_out = (uhigh_sum == (uint32_t)high_result) ? 0 : 1;
        *result = op1 + op2 + carry_in;
    }
}

int count_leading_0(uint32_t val)
{
    int count = 0;
    while(val != 0){
        val >>= 1;
        count++;
    }
    return 32 - count;
}

#define LONG_MUL_DIV32_OP2(ins_code) LOW_BIT32((ins_code) >> 4, 4)
#define LONG_MUL_DIV32_Rd(ins_code) LOW_BIT32((ins_code) >> 8, 4)
#define LONG_MUL_DIV32_Rm(ins_code) LOW_BIT32((ins_code), 4)
#define LONG_MUL_DIV32_Rn(ins_code) LOW_BIT32((ins_code) >> 16, 4)
#define LONG_MUL_DIV32_RdLo(ins_code) LOW_BIT32((ins_code) >> 12, 4)
#define LONG_MUL_DIV32_RdHi(ins_code) LOW_BIT32((ins_code) >> 8, 4)


#define MEM_ACCESS32_RT(ins_code) LOW_BIT32((ins_code) >> 12, 4)
#define MEM_ACCESS32_RN(ins_code) LOW_BIT32((ins_code) >> 16, 4)
#define MEM_ACCESS32_RM(ins_code) LOW_BIT32((ins_code), 4)
#define MEM_ACCESS32_IMM2(ins_code) LOW_BIT32((ins_code) >> 4, 2)
#define MEM_ACCESS32_IMM12(ins_code) LOW_BIT32((ins_code), 12)
#define MEM_ACCESS32_IMM8(ins_code) LOW_BIT32((ins_code), 8)
#define MEM_ACCESS32_P(ins_code) LOW_BIT32((ins_code) >> 10, 1)
#define MEM_ACCESS32_W(ins_code) LOW_BIT32((ins_code) >> 8, 1)
/* the U bit is not the same in normal and literal instructions */
#define MEM_ACCESS32_NORMAL_U(ins_code) LOW_BIT32((ins_code) >> 9, 1)
#define MEM_ACCESS32_LITERAL_U(ins_code) LOW_BIT32((ins_code) >> 23, 1)

//-------------------------------------------------------------------
// Data processing with 12 bit immediate
//-------------------------------------------------------------------

unsigned int read_register_dataprocessing ( unsigned int reg )
{
  if (reg == 15) { return(0); } else { return(read_register(reg)); }
}

void write_register_dataprocessing ( unsigned int reg, unsigned int data )
{
  if (reg != 15) { write_register(reg, data); }
  return;
}


void _and_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags, uint32_t carry)
{
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    uint32_t result = Rn_val & imm32;
    write_register_dataprocessing(Rd, result);

    if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
    }
}

void _and_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);
    uint32_t imm32;
    int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _and_imm(imm32, Rn, Rd, setflags, carry);

    // LOG_INSTRUCTION("_and_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

void _bic_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags, int carry)
{
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    uint32_t result = Rn_val & ~imm32;
    write_register_dataprocessing(Rd, result);

    if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
    }
}

void _bic_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _bic_imm(imm32, Rn, Rd, setflags, carry);

    // LOG_INSTRUCTION("_bic_imm_32, R%d, #%d\n", Rn, imm32);
}

void _orr_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags, int carry)
{
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    uint32_t result = Rn_val | imm32;
    write_register_dataprocessing(Rd, result);

    if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
    }
}

void _orr_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _orr_imm(imm32, Rn, Rd, setflags, carry);

    // LOG_INSTRUCTION("_orr_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

void _orn_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags, int carry)
{
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    uint32_t result = Rn_val | ~imm32;
    write_register_dataprocessing(Rd, result);

     if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
    }
}

void _orn_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _orn_imm(imm32, Rn, Rd, setflags, carry);
    // LOG_INSTRUCTION("_orn_imm_32, R%d, #%d\n", Rd, imm32);
}

void _eor_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags, int carry)
{
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    uint32_t result = Rn_val ^ imm32;
    write_register_dataprocessing(Rd, result);
    if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
    }
}

void _eor_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _eor_imm(imm32, Rn, Rd, setflags, carry);
    // LOG_INSTRUCTION("_eor_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

void _add_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags)
{
    uint32_t carry = GET_APSR_C;
    uint32_t overflow;

    uint32_t Rn_val = read_register_dataprocessing(Rn);
    uint32_t result;
    AddWithCarry(Rn_val, imm32, 0, &result, &carry, &overflow);
    write_register_dataprocessing(Rd, result);
    if(setflags != 0){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
        SET_APSR_V(overflow);
    }

}

void _add_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _add_imm(imm32, Rn, Rd, setflags);
    // LOG_INSTRUCTION("_add_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

void _adc_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags)
{
    uint32_t result, carry, overflow;
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    AddWithCarry(Rn_val, imm32, GET_APSR_C, &result, &carry, &overflow);
    write_register_dataprocessing(Rd, result);
    if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
        SET_APSR_V(overflow);
    }
}

void _adc_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _adc_imm(imm32, Rn, Rd, setflags);
    // LOG_INSTRUCTION("_adc_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

void _sbc_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags)
{
    uint32_t result, carry, overflow;
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    AddWithCarry(Rn_val, ~imm32, GET_APSR_C, &result, &carry, &overflow);
    write_register_dataprocessing(Rd, result);
    if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
        SET_APSR_V(overflow);
    }
}

void _sbc_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _sbc_imm(imm32, Rn, Rd, setflags);
    // LOG_INSTRUCTION("_sbc_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

void _sub_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags)
{
    uint32_t carry = GET_APSR_C;
    uint32_t overflow;

    uint32_t Rn_val = read_register_dataprocessing(Rn);
    uint32_t result;
    AddWithCarry(Rn_val, ~imm32, 1, &result, &carry, &overflow);
    write_register_dataprocessing(Rd, result);
    if(setflags != 0){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
        SET_APSR_V(overflow);
    }
}

void _sub_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _sub_imm(imm32, Rn, Rd, setflags);
    // LOG_INSTRUCTION("_sub_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

void _rsb_imm(uint32_t imm32, uint32_t Rn, uint32_t Rd, uint32_t setflags)
{
    /* Warning: this function is not tested since MDK can't generate 16bit code for it */
    uint32_t result, overflow, carry;
    uint32_t Rn_val = read_register_dataprocessing(Rn);
    AddWithCarry(~Rn_val, imm32, 1, &result, &carry, &overflow);
    write_register_dataprocessing(Rd, result);
    if(setflags){
        SET_APSR_N(result);
        SET_APSR_Z(result);
        SET_APSR_C(carry);
        SET_APSR_V(overflow);
    }
}

void _rsb_imm_32(uint32_t ins_code)
{
    uint32_t Rd = DATA_PROCESS32_RD(ins_code);
    uint32_t Rn = DATA_PROCESS32_RN(ins_code);
    uint32_t setflags = DATA_PROCESS32_S(ins_code);
    uint32_t i_imm3_imm8 = DATA_PROCESS32_I_IMM3_IMM8(ins_code);

    uint32_t imm32; int carry;
    ThumbExpandImm_C(i_imm3_imm8, GET_APSR_C, &imm32, &carry);

    _rsb_imm(imm32, Rn, Rd, setflags);
    // LOG_INSTRUCTION("_rsb_imm_32, R%d, R%d, #%d\n", Rd, Rn, imm32);
}

//-------------------------------------------------------------------------------------------------------------------------
// Das waren die Schnippsel aus dem ARMUE
//-------------------------------------------------------------------------------------------------------------------------


int execute ( void )
{
   uint32_t pc = read_register(15);

   
   
   uint32_t inst=fetch16(pc-2);
     // fprintf(stderr,"PC -- 0x%08X: 0x%08X\n", pc, inst);
   pc+=2;
   write_register(15, pc);   
   
   
    //  fprintf(stderr,"0x%08X 0x%04X\n",pc-4,inst);
   
   // -------------------------------------------------------------------------
   // 32 Bit Thumb-2 instructions, simplified.
   // -------------------------------------------------------------------------


   
   if ((inst & 0xF800) == 0xE800 || (inst & 0xF800) == 0xF000 || (inst & 0xF800) == 0xF800)
   {
       
     uint32_t opcode1 = inst;
     uint32_t opcode2 = fetch16(pc-2);
     pc+=2;
     write_register(15, pc);          
     
     inst = (opcode1 << 16) | opcode2;
          
     //  fprintf(stderr,"0x%08X: 0x%08X\n",(pc-6),inst);


   //  1111 0sii iiii iiii  11j1 jiii iiii iiii
   //  1111 0               11 1  
     
     
   if ((inst & 0xF800D000) == 0xF000D000) // BL
   {   
    
      uint32_t instr1 = opcode1;
      uint32_t instr2 = opcode2;       
         
      uint32_t s = (instr1 & (1 << 10)) >> 10;
      uint32_t immHi = instr1 & 0x3FF;
      uint32_t j1 = (instr2 & (1 << 13)) >> 13;
      uint32_t j2 = (instr2 & (1 << 11)) >> 11;
      uint32_t immLo = (instr2 & 0x7FF);
      uint32_t i1 = (s ^ j1) ^ 1;
      uint32_t i2 = (s ^ j2) ^ 1;
      uint32_t imm32 = ((int32_t)((s << 24) | (i1 << 23) | (i2 << 22) | (immHi << 12) | (immLo << 1)) << 7) >> 7;
      uint32_t nextInstrAddr;
     
      nextInstrAddr = read_register(15)-2;
      
     // fprintf(stderr,"Bl NextInstrAddr Destination -- 0x%08X: 0x%08X\n",nextInstrAddr,nextInstrAddr + imm32);
      
      write_register(14, nextInstrAddr | 1);    
      write_register(15, nextInstrAddr + imm32 + 2); // Special für diesen Emulator...
     
      return(0);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
  // 1111 0Scc ccii iiii 10j1 jiii iiii iiii
  //        11 11
  
  // 1111 1011 1100 0000 1101 0000 0000 0000 Maske    0xFBC0D000
  // 1111 0011 1100 0000 1001 0000 0000 0000 Bits     0xF3C09000
  
  // F    C    C    0    0    0    0    0
  // F    3    C    0    8    0    0    0
  
   if ((inst&0xFBC0D000)==0xF3C09000) // b.w  Unconditional branch, long format
   {                       
     uint32_t J1 = LOW_BIT32(inst >> 13, 1);
     uint32_t S  = LOW_BIT32(inst >> 26, 1);
     uint32_t I1 = !(J1 ^ S);
    
     uint32_t J2 = LOW_BIT32(inst >> 11, 1);
     uint32_t I2 = !(J2 ^ S);
    
     uint32_t imm10 = LOW_BIT32(inst >> 16, 10);
     uint32_t imm11 = LOW_BIT32(inst, 11);
    
     uint32_t imm32 =  _ASR32(S << 31 | I1 << 30 | I2 << 29 | imm10 << 19 | imm11 << 8, 7);
     
     uint32_t pc = read_register(15) - 2;     
     uint32_t destination = (pc + imm32) & 0xFFFFFFFF;
                  
     // fprintf(stderr, "b.w ");
     // fprintf(stderr,"-- 0x%08X: 0x%04X --> 0x%08X\n",read_register(15)-6,inst, destination);
     
     write_register(15, destination + 2); // Special für diesen Emulator...
     
     return(0);
   }

   // 1111 0scc ccii iiii  10j0 jiii iiii iiii
   // 1111 1000 0000 0000  1101 0000 0000 0000  0xF800D000
   
   if ((inst&0xF800D000)==0xF0008000) // bxx.w  conditional branch, long format
   {                       
     uint32_t J1 = LOW_BIT32(inst >> 13, 1);
     uint32_t S  = LOW_BIT32(inst >> 26, 1);

     uint32_t J2 = LOW_BIT32(inst >> 11, 1);

     uint32_t cond = LOW_BIT32(inst >> 22, 4);
     uint32_t imm6 = LOW_BIT32(inst >> 16, 6);
     uint32_t imm11 = LOW_BIT32(inst, 11);

     uint32_t imm32 = _ASR32(S << 31 | J1 << 30 | J2 << 29 | imm6 << 23 | imm11 << 12, 11);   
   
   
     uint32_t pc = read_register(15) - 2;     
     uint32_t destination = (pc + imm32) & 0xFFFFFFFF;
                  
     // fprintf(stderr, "b.w ");
     // fprintf(stderr,"-- 0x%08X: 0x%04X --> 0x%08X\n",read_register(15)-6,inst, destination);
     
     switch (cond)
     {
       case 0b0000: if (  cpsr&CPSR_Z ) { write_register(15, destination + 2); } return(0);  // beq.w
       case 0b0001: if (!(cpsr&CPSR_Z)) { write_register(15, destination + 2); } return(0);  // bne.w
     }
    
     fprintf(stderr,"Unimplemented long conditional jump Thumb-2 Opcode -- 0x%08X: 0x%04X\n",(pc-6),inst);     
     return(1);
   }   
   
            
   if ((inst&0xFB708000)==0xF2400000) // MOVW/MOVT
   {        
    // fprintf(stderr, "MOVW/MOVT\n");
     uint32_t Rd = DATA_PROCESS32_RD(inst);
     uint32_t imm16 = DATA_PROCESS32_IMM4_I_IMM3_IMM8(inst);
     
     if (inst&0x00800000)
          { write_register(Rd, (read_register(Rd) & 0xFFFF) | (imm16<<16)); }  // MOVT
     else { write_register(Rd,                                 imm16     ); }  // MOVW
     return(0);
   }
   
   
   
  // 1111 0i0x xxxs nnnn 0iii dddd iiii iiii
  // F    0    0    0    0    0    0    0
  // F    A    0    0    8    0    0    0

  if ((inst&0xFA008000)==0xF0000000) // Data processing, modified 12-bit immediate
  {
   // fprintf(stderr, "Data Processing 12 Bit Immediate\n");
   // fprintf(stderr,"0x%08X 0x%04X\n",Rn,(inst >> 21) & 0xF);
    
    switch((inst >> 21) & 0xF)    
    {        
       case 0b0000: _and_imm_32(inst); return(0); // and  0
       case 0b0001: _bic_imm_32(inst); return(0); // bic  1
       case 0b0010: _orr_imm_32(inst); return(0); // orr  2
       case 0b0011: _orn_imm_32(inst); return(0); // orn  3
       case 0b0100: _eor_imm_32(inst); return(0); // eor  4   *
       case 0b1000: _add_imm_32(inst); return(0); // add  8   *
       case 0b1010: _adc_imm_32(inst); return(0); // adc  A
       case 0b1011: _sbc_imm_32(inst); return(0); // sbc  B   *
       case 0b1101: _sub_imm_32(inst); return(0); // sub  D
       case 0b1110: _rsb_imm_32(inst); return(0); // rsb  E   *
    }   
    
     fprintf(stderr,"Unknown data processing with 12-bit immediate Thumb-2 Opcode -- 0x%08X: 0x%04X\n",(pc-6),inst);     
     return(1);
  }

    
   // Decode remaining "singular" opcodes used in Mecrisp-Stellaris:
   
   if ((inst&0xFFFF0FFF)==0xF8470D04) // str rn [ r7 #-4 ]!
   {
   // fprintf(stderr, "pushda\n");
     uint32_t Rn = (inst & 0xF000) >> 12;      
     uint32_t location = (read_register(7) - 4) & 0xFFFFFFFF;
     write32(location, read_register(Rn));
     write_register(7, location);     
     return(0);
   }
   
   
   if (inst == 0xeb1e0e03) // adds.w lr, lr, r3  *** Flags ignored... Wird nur zum Überspringen von Strings bei der Ausgabe verwendet.
   {
   // fprintf(stderr, "String überspringen\n");
     write_register(14, (read_register(14) + read_register(3)) & 0xFFFFFFFF);
     return(0);
   }
 
 
    
    if ((inst&0xFFF00000)==0xF8D00000) // ldr.w Rd, [Rt, +imm12]
    {
      // fprintf(stderr, "ldr.w Rd, [pc, +imm12]\n");
     
      uint32_t Rt    = (inst >> 16) & 0xF;
      uint32_t Rd    = (inst >> 12) & 0xF;
      uint32_t imm12 = inst & 0xFFF;
      
      uint32_t location;
      
      if (Rt == 0xF)
      {      
        uint32_t next_pc = read_register(15)-2;
        location  = next_pc;
        location &= ~3;
      }
      else
      {
        location = read_register(Rt);
      }             
      
      uint32_t data = read32(location + imm12);
            
      write_register(Rd, data);
           
      return(0);
    }
 

 
   if (inst == 0xe8bd400f) // ldmia.w sp!, {r0, r1, r2, r3, lr}
   {
//     fprintf(stderr, "Verrücktes LDMIA.W\n");
     uint32_t sp = read_register(13);
     
     write_register(0, read32(sp)); sp+=4;
     write_register(1, read32(sp)); sp+=4;
     write_register(2, read32(sp)); sp+=4;
     write_register(3, read32(sp)); sp+=4;
     write_register(14,read32(sp)); sp+=4;
     
     write_register(13, sp);
     return(0);
   }
   
   
   
   if (inst == 0xEA100201) // ands.w r2, r0, r1
   {
//   fprintf(stderr, "ands.w r2, r0, r1\n");
     uint32_t result = read_register(0) & read_register(1);
     write_register(2, result);     
     do_nflag(result);
     do_zflag(result);
     return(0);
   }
   
   

   if (inst == 0xEA104001) // ands.w r0, r0, r1, lsl #16
   {
//   fprintf(stderr, "ands.w r0, r0, r1, lsl #16\n");
     uint32_t result = read_register(0) & ((read_register(1)<<16) & 0xFFFFFFFF);
     write_register(0, result);
     do_nflag(result);
     do_zflag(result);
     return(0);
   }    
   
   
   
   if (inst == 0xea563603) // orrs.w r6, r6, r3, lsl #12
   {
//   fprintf(stderr, "orrs.w r6, r6, r3, lsl #12\n");
     uint32_t result = read_register(6) | ((read_register(3)<<12) & 0xFFFFFFFF);
     write_register(6, result);
     do_nflag(result);
     do_zflag(result);
     return(0);
   }   
   

   
   if (inst == 0xea564601) // orrs.w r6, r6, r1, lsl #16
   {
//   fprintf(stderr, "orrs.w r6, r6, r1, lsl #16\n");
     uint32_t result = read_register(6) | ((read_register(1)<<16) & 0xFFFFFFFF);
     write_register(6, result);
     do_nflag(result);
     do_zflag(result);
     return(0);
   }   
   


   if (inst == 0xea562603) // orrs.w	r6, r6, r3, lsl #8
   {
//   fprintf(stderr, "orrs.w	r6, r6, r3, lsl #8\n");
     uint32_t result = read_register(6) | ((read_register(3)<<8 & 0xFFFFFFFF));
     write_register(6, result);
     do_nflag(result);
     do_zflag(result);
     return(0);
   }      
   
   
   
   if (inst == 0xF8576026) // ldr.w	r6, [r7, r6, lsl #2]  -- pick
   {
//   fprintf(stderr, "ldr.w	r6, [r7, r6, lsl #2]  -- pick\n");
     write_register(6, read32(read_register(7) + (read_register(6) << 2)));
     return(0);
   }
   
   
      
   if (inst == 0xea5f0676) // movs.w r6, r6, ror #1
   {
  // fprintf(stderr, "movs.w r6, r6, ror #1\n");   
     uint32_t rc=read_register(6);
     do_cflag_bit(rc & 1);
       
     uint32_t rb=rc<<31;
     rc>>=1;
     rc|=rb;

     write_register(6 ,rc);
     do_nflag(rc);
     do_zflag(rc);
       
     return(0);
   }
   
   

   if ((inst&0xFFF000F0)==0xFBA00000) // umull
   {            
     uint32_t Rn = LONG_MUL_DIV32_Rn(inst);
     uint32_t Rm = LONG_MUL_DIV32_Rm(inst);
     uint32_t RdLo = LONG_MUL_DIV32_RdLo(inst);
     uint32_t RdHi= LONG_MUL_DIV32_RdHi(inst);
     
     uint64_t op1 = read_register(Rn);
     uint64_t op2 = read_register(Rm);
     uint64_t result = op1 * op2;
     
     write_register(RdHi, result >> 32);
     write_register(RdLo, result & 0xFFFFFFFF);
     
     return(0);
   }
    
    

   if ((inst&0xFFF000F0)==0xFB800000) // smull
   {            
     uint32_t Rn = LONG_MUL_DIV32_Rn(inst);
     uint32_t Rm = LONG_MUL_DIV32_Rm(inst);
     uint32_t RdLo = LONG_MUL_DIV32_RdLo(inst);
     uint32_t RdHi= LONG_MUL_DIV32_RdHi(inst);

     int64_t op1 = (int32_t)read_register(Rn);
     int64_t op2 = (int32_t)read_register(Rm);
     int64_t result = op1 * op2;
     
     write_register(RdHi, (uint64_t)result >> 32);
     write_register(RdLo, result & 0xFFFFFFFF);
     
     return(0);
   }    
        
    
    
   if ((inst&0xFFF0F0F0)==0xFB90F0F0) // sdiv
   {
      
    uint32_t Rn = LONG_MUL_DIV32_Rn(inst);
    uint32_t Rm = LONG_MUL_DIV32_Rm(inst);
    uint32_t Rd = LONG_MUL_DIV32_Rd(inst);
    
    int32_t Rm_val = read_register(Rm);
    int32_t Rn_val = read_register(Rn);
    int32_t result;
    
    if(Rm_val == 0){
        // TODO: interger zero divided trapping
        result = 0;
    }else{
        result = Rn_val / Rm_val;
    }

    write_register(Rd, result);
    return(0);
   }
   
   

   if ((inst&0xFFF0F0F0)==0xFBB0F0F0) // udiv
   {
      
    uint32_t Rn = LONG_MUL_DIV32_Rn(inst);
    uint32_t Rm = LONG_MUL_DIV32_Rm(inst);
    uint32_t Rd = LONG_MUL_DIV32_Rd(inst);
    
    uint32_t Rm_val = read_register(Rm);
    uint32_t Rn_val = read_register(Rn);
    uint32_t result;
    
    if(Rm_val == 0){
        // TODO: interger zero divided trapping
        result = 0;
    }else{
        result = Rn_val / Rm_val;
    }

    write_register(Rd, result);
    return(0);
   }

   
   
   
   if ((inst&0xFFF0F0F0)==0xfab0f080) // clz
   {
    uint32_t Rd = DATA_PROCESS32_RD(inst);
    uint32_t Rn = DATA_PROCESS32_RN(inst);
    uint32_t Rm = DATA_PROCESS32_RM(inst);      
      
    uint32_t Rm_val = read_register(Rm);
    uint32_t result = count_leading_0(Rm_val);
    write_register(Rd, result);
    
    return(0);
   }
       
    
    
    
    
    
    
    
    
    
    
    
    
     
     fprintf(stderr,"Unknown Thumb-2 Opcode -- 0x%08X: 0x%08X\n",(pc-6),inst);
     return(1); // return(0);
   }

   
   // -------------------------------------------------------------------------
   // 16 Bit instructions
   // -------------------------------------------------------------------------

   uint32_t sp;
   uint32_t ra,rb,rc;
   uint32_t rm,rd,rn,rs;
   uint32_t op;   
   
if(DISS) fprintf(stderr,"--- 0x%08X: 0x%04X ",(pc-4),inst);



   // -------------------------------------------------------------------------
   // 16 Bit M3 instructions - IT blocks, simplified
   // -------------------------------------------------------------------------

   if (inst==0xbf38) // it cc
   {
     // Skip next opcode if carry flag is set
     if (cpsr&CPSR_C)
     {      
       uint32_t nextinst = fetch16(read_register(15) - 2); // Special für diesen Emulator...
       
       // fprintf(stderr," it nextinst --- 0x%08X: 0x%04X\n",read_register(15),nextinst);
       
       if ((nextinst & 0xF800) == 0xE800 || (nextinst & 0xF800) == 0xF000 || (nextinst & 0xF800) == 0xF800)
            { write_register(15, read_register(15) + 4); }
       else { write_register(15, read_register(15) + 2); }                      
     }
     return(0);
   }
      
   if (inst==0xbf18) // it ne
   {
     // Skip next opcode if zero flag is set
     if (cpsr&CPSR_Z)
     {      
       uint32_t nextinst = fetch16(read_register(15) - 2); // Special für diesen Emulator...
       
       // fprintf(stderr," it nextinst --- 0x%08X: 0x%04X\n",read_register(15),nextinst);
       
       if ((nextinst & 0xF800) == 0xE800 || (nextinst & 0xF800) == 0xF000 || (nextinst & 0xF800) == 0xF800)
            { write_register(15, read_register(15) + 4); }
       else { write_register(15, read_register(15) + 2); }                      
     }
     return(0);
   }   

   // -------------------------------------------------------------------------
   // 16 Bit M0 instructions
   // -------------------------------------------------------------------------



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

   fprintf(stderr,"invalid instruction 0x%08X 0x%04X\n",pc-4,inst);
   return(1);
}

int run ( void )
{
   while(1)
   {
       if(execute()) break;
   }
   return(0);
}
