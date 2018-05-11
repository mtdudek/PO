// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L3, z2 Słownik
// Słownik_test
// Słownik_test
// 2018-03-15
using System;
using Slownik;

namespace Slownik_test{
    class Program{
        static void Main(string[] args){
            Slownik<string, int> Sl = new Slownik<string, int>();
            Console.Write("Dostępne operacje:\n1 K V->dodaj element z kluczem K"+
                " i wartością V;\n2 K->wynisuje element z kulczem K;\n3 K->usuwa"+
                " element z kluczem K;\n4->wypisz zawartość słownika;\n"+
                "5->zakończ program.\n");
            while (true){
                Console.Write("Podaj polecenie>");
                string h = Console.ReadLine();
                string[] tab = h.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                int p;
                if( !Int32.TryParse(tab[0],out p)){
                    Console.Write("Złe polecenie!!\n");
                    continue;
                }
                if (p == 1){
                    if ((tab.Length==3)&&(Int32.TryParse(tab[2], out p)))
                        Sl.dodaj_element_z_kluczem(tab[1], p);
                    else
                        Console.Write("Złe dane!!\n");
                }
                else if (p == 2){
                    Console.WriteLine(Sl.znajdz_element_z_kluczem(tab[1]));
                }
                else if (p == 3){
                    Sl.usun_element_z_kluczem(tab[1]);
                }
                else if (p == 4){
                    Sl.wypisz_caly_slownik();
                }
                else if (p == 5){
                    break;
                }
                else
                    Console.Write("Złe polecenie!!\n");
            }
        }
    }
}
