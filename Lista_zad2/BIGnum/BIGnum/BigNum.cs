//Maciej Dudek
//indeks: 299186
using System;
using System.Collections.Generic;
using System.Text;

namespace BIGnum
{
    public class BigNum{
        protected ulong[] BigNum_ary;
        public string MaxVal,MinVal;
        public BigNum(){
            this.BigNum_ary = new ulong[64];
            Array.Clear(this.BigNum_ary, 0, this.BigNum_ary.Length);
            this.MaxVal = "(2^4095)-1";
            this.MinVal = "(-2^4095)+1";
        }
        public BigNum(int a){
            this.BigNum_ary = new ulong[64];
            Array.Clear(this.BigNum_ary, 0, this.BigNum_ary.Length);
            this.BigNum_ary[0]=(ulong)Math.Abs(a);
            if (a < 0){
                for (int i = 0; i < 64; i++){
                    this.BigNum_ary[i] = ~this.BigNum_ary[i];
                }
                this.Add_One();
            }
            this.MaxVal = "(2^4095)-1";
            this.MinVal = "(-2^4095)+1";
        }
        public BigNum(ulong[] ary){
            this.BigNum_ary = new ulong[64];
            Array.Clear(this.BigNum_ary, 0, this.BigNum_ary.Length);
            for (int i=0;i<64;i++){
                this.BigNum_ary[i] = ary[i];
            }
            this.MaxVal = "(2^4095)-1";
            this.MinVal = "(-2^4095)+1";
        }
        public BigNum(BigNum A){
            this.BigNum_ary = new ulong[64];
            Array.Clear(this.BigNum_ary, 0, this.BigNum_ary.Length);
            for (int i = 0; i < 64; i++){
                this.BigNum_ary[i] = A.BigNum_ary[i];
            }
            this.MaxVal = "(2^4095)-1";
            this.MinVal = "(-2^4095)+1";
        }
        public void Set_MaxVal(){
            for (int i = 0; i < 64; i++)
                this.BigNum_ary[i] |= 0xFFFFFFFFFFFFFFFF;
            this.BigNum_ary[63] &= 0x7FFFFFFFFFFFFFFF;
        }
        public void Set_MinVal(){
            for (int i = 0; i < 64; i++) this.BigNum_ary[i] = 0;
            this.BigNum_ary[63] = 0x8000000000000000;
            this.BigNum_ary[0] = 1;
        }
        public void Put(int a){
            Console.WriteLine(this.BigNum_ary[a]);
        }
        public void Add_One(){
            bool carry_over = true;
            for (int i = 0; (i < 64) && carry_over; i++){
                ulong temp = this.BigNum_ary[i];
                if (carry_over){
                    temp++;
                    carry_over = false;
                }
                if (temp < this.BigNum_ary[i]){
                    carry_over = true;
                }
                this.BigNum_ary[i] = temp;                   
            }
        }
        public void Shift_Right_Once (){
            this.BigNum_ary[0] >>= 1;
            for(int i = 1; i <64; i++){
                if ((this.BigNum_ary[i] & 1) == 1) this.BigNum_ary[i - 1] += 0x8000000000000000;
                this.BigNum_ary[i] >>= 1;
            }
        }
        public void Shift_Left_Once (){
            this.BigNum_ary[63] <<= 1;
            for (int i = 62; i >= 0; i--){
                if ((this.BigNum_ary[i] & 0x8000000000000000) == 0x8000000000000000) this.BigNum_ary[i + 1] += 1;
                this.BigNum_ary[i] <<= 1;
            }
        }
        public void Neg(){
            for (int i = 0; i < 64; i++){
                this.BigNum_ary[i] = ~this.BigNum_ary[i];
            }
            this.Add_One();
        }
        public bool Greater_Than_Zero(){
            if (this.Is_Negative()) return false;
            for (int i = 0; i < 64; i++){
                if (this.BigNum_ary[i] > 0)
                    return true;
            }
            return false;
        }
        public bool Is_Negative(){
            ulong mask = 0x8000000000000000;
            if ( (mask & this.BigNum_ary[63]) == mask)
                return true;
            return false;
        }
        public void Print(){
            bool neg = false;
            BigNum T = new BigNum(this);
            if (T.Is_Negative()) neg=true;
            if (neg) T.Neg();
            List<int>   t1 = new List<int>(),
                        t2 = new List<int>();
            t1.Add(1);
            int carry = 0;
            while (T.Greater_Than_Zero()){
                if ((T.BigNum_ary[0] & 1) == 1){
                    for (int i = 0; i < t2.Count;i++){
                        t2[i] += t1[i];
                    }
                    for (int i = t2.Count; i < t1.Count; i++){
                        t2.Add(t1[i]);
                    }
                    for (int i = 0; i < t2.Count; i++){
                        t2[i] += carry;
                        carry = 0;
                        carry = (t2[i] - (t2[i] % 10)) / 10;
                        t2[i] %= 10;
                    }
                    while (carry > 0){
                        t2.Add(carry % 10);
                        carry /= 10;
                    }
                }
                for (int i = 0; i < t1.Count; i++){
                    t1[i] *= 2;
                    t1[i] += carry;
                    carry = 0;
                    carry = (t1[i] - (t1[i] % 10)) / 10;
                    t1[i] %= 10;
                }
                while (carry > 0){
                    t1.Add(carry % 10);
                    carry /= 10;
                }
                T.Shift_Right_Once();
            }
            t2.Reverse();
            if (neg) Console.Write("-");
            t2.ForEach(i => Console.Write("{0}", i));
            Console.WriteLine();
        }
        public void Binary_Dump(){
            BigNum T = new BigNum(this);
            while (T.Greater_Than_Zero()){
                if ((T.BigNum_ary[0] & 1) == 1) Console.Write("1");
                else Console.Write("0");
                T.Shift_Right_Once();
            }
            Console.WriteLine();
        }
        public int Last_Bit_Pos(){
            int i = 63, k = 63;
            while (this.BigNum_ary[i] == 0) i--;
            ulong j = 0x8000000000000000;
            while ((this.BigNum_ary[i] & j) == 0){
                j >>= 1;
                k--;
            }
            return 64 * i + k;
        }
        public static BigNum operator+ (BigNum A,BigNum B){
            bool carry_over = false,
                 last_carry = false;
            BigNum t = new BigNum();
            for (int i = 0; i < 64; i++){
                carry_over = false;
                ulong temp = A.BigNum_ary[i] + B.BigNum_ary[i];
                if ((temp<A.BigNum_ary[i])||(temp<B.BigNum_ary[i]))
                    carry_over = true;
                if (last_carry){
                    temp ++;
                }
                if ((temp < A.BigNum_ary[i]) || (temp < B.BigNum_ary[i]))
                    carry_over = true;
                t.BigNum_ary[i] += temp;
                last_carry = carry_over;
            }
            return new BigNum(t.BigNum_ary);
        }
        public static BigNum operator- (BigNum A,BigNum B){
            BigNum T = new BigNum(B);
            for (int i = 0; i < 64; i++)
                T.BigNum_ary[i] = ~T.BigNum_ary[i];
            T.Add_One();
            return A + T;
        }
        public static BigNum operator* (BigNum A,BigNum B){
            BigNum  t = new BigNum();
            BigNum t1 = new BigNum(A),
                   t2 = new BigNum(B);
            bool an = A.Is_Negative(),
                 bn = B.Is_Negative();
            if (an)
                t1.Neg();
            if (bn)
                t2.Neg();

            while ( t2.Greater_Than_Zero() ){
                if((t2.BigNum_ary[0] & 1)==1){
                    t = t + t1;
                }
                t2.Shift_Right_Once();
                t1.Shift_Left_Once();
            }
            if (an)
                t.Neg();
            if (bn)
                t.Neg();
            return t;
        }
        public static BigNum operator/ (BigNum A,BigNum B){
            BigNum L1 = new BigNum(1),
                   t1 = new BigNum(A),
                   t2 = new BigNum(B),
                   t = new BigNum();
            bool an = A.Is_Negative(),
                 bn = B.Is_Negative();
            if (an)
                t1.Neg();
            if (bn)
                t2.Neg();
            int l1=t1.Last_Bit_Pos(),l2=t2.Last_Bit_Pos();
    
            while (l1 > l2){
                int p = l1 - l2 - 1;
                for (int i = 0; i < p; i++){
                    t2.Shift_Left_Once();
                    L1.Shift_Left_Once();
                }
                t = t + L1;
                t1 = t1 - t2;
                for (int i = 0; i < p; i++){
                    t2.Shift_Right_Once();
                    L1.Shift_Right_Once();
                }
                l1 = t1.Last_Bit_Pos();
                l2 = t2.Last_Bit_Pos();
            }
            t1 = t1 - t2;
            if (!t1.Is_Negative())
                t = t + L1;
            if (an)
                t.Neg();
            if (bn)
                t.Neg();
            return t;
        }
    }
}

