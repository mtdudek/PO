using System;

namespace BIGnum
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNum a = new BigNum(-1);
            BigNum b = new BigNum(10);
            BigNum c = new BigNum();
            BigNum d = new BigNum(1000000000);

            d = d * d;
            d = d * d;
            d.Print();
            d = d * d;
            d.Print();
            d *= d;
            d.Print();
            //d.Binary_Dump();
            //Console.WriteLine(d.Last_Bit_Pos());

            c = a * b;
            c.Print();
            c = a * a;
            c.Print();
            c = a - b;
            c.Print();
            c = b - a;
            c.Print();
            c = a + b;
            c.Print();
            c = b / a;
            c.Print();
            c = d / b;
            c.Print();

            Console.WriteLine("Max Big_Num_val:{0}=",a.MaxVal);
            c.Set_MaxVal();
            c.Print();
            Console.WriteLine("Min Big_Num val:{0}",a.MinVal);
            c.Set_MinVal();
            c.Print();
            c = c / a;
            c.Print();
            c = c * a;
            c.Print();
        }
    }
}
