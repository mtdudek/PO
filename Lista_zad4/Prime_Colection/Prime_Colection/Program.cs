// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L4, z1 Słownik
// Słownik_test
// Słownik.dll
// 2018-04-12
using System;
using System.Collections;

namespace Prime_Colection
{
    //Kolekcja liczb pierwszych
    class PrimeCollection : IEnumerable{
        public PrimeCollection(){}
        public IEnumerator GetEnumerator(){
            return new PrimeEnum();
        }
    }
    //Iterator kolekcji
    class PrimeEnum : IEnumerator{
        int p;
        public PrimeEnum() { p = 1; }
        //Funkcja która ustala nowe p i jeśli
        //jest to nie możliwe zwraca false
        public bool MoveNext(){
            if (p == 1){
                p++;
                return true;
            }else{
                if (p == 2)
                    p++;
                else
                    p += 2;
                while (p > 0){
                    bool pier = true;
                    for (int i = 2; i * i <= p && pier; i ++)
                        if (p % i == 0)
                            pier = false;
                    if (pier)
                        return true;
                    p += 2;
                }
                return false;
            }
        }
        //Podaje p
        public object Current{
            get{
                return p;
            }
        }
        //Resetuje p
        public void Reset(){
            p = 1;
        }
    }
    class Program{
        static void Main(string[] args){
            PrimeCollection pc = new PrimeCollection();
            foreach (int p in pc)
                Console.WriteLine(p);
        }
    }
}
