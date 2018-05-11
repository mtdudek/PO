//////////////////////////////
//  Programowanie Obiektowe //
//  Maciej Tomasz Dudek     //
//  Nr. indeksu 299168      //
//  Pracownia 3             //
//  Zadanie 1-Lista(test)   //
//////////////////////////////
using System;
using Lista;

namespace Lista_test {
    class Program {
        static void Main(string[] args) {
            Lista<int> moja = new Lista<int>();
            moja.push_begin(90);
            moja.push_back(42);
            Console.WriteLine("{0},{1}", moja.begin(), moja.back());
            moja.push_back(69);
            moja.push_back(859867);
            Console.WriteLine("{0},{1}", moja.begin(), moja.back());
            Console.WriteLine("{0},{1}", moja.pop_back(), moja.pop_back());
        }
    }
}
