//////////////////////////////
//  Programowanie Obiektowe //
//  Maciej Tomasz Dudek     //
//  Nr. indeksu 299168      //
//  Pracownia 4             //
//  Zadanie 3-Graf(test)    //
//////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Graf;
using Slownik;

namespace Graf_test
{
    class Program
    {
        //Zmienne testów w1 - liczba wierzchołki
        //k1 - lczba krawędzi
        const int w1 = 3000, k1 = 150000;
        static Graf_random_gen p;

        //Dijkstra  
        static void Dijkstra(string start,string koniec,graf_interface graf){
            p.Reset_wie();
            p.Reset_kraw();
            kra k = new kra(0, "");
            Slownik<string, int> s = new Slownik<string, int>();
            Slownik<int, string> i_s = new Slownik<int, string>();
            int[] odleglosci= new int[w1];
            bool[] bylem = new bool[w1];
            for (int i = 0; i < w1; i++){
                odleglosci[i] = Int32.MaxValue;
                bylem[i] = false;
                string h = p.Nastepny_wierzchołek();
                s.dodaj_element_z_kluczem(h, i);
                i_s.dodaj_element_z_kluczem(i, h);
            }
            odleglosci[s.znajdz_element_z_kluczem(start)] = 0;
            while (!bylem[s.znajdz_element_z_kluczem(koniec)]){
                int min = Int32.MaxValue, poz = -1;
                for (int i = 0; i < w1; i++){
                    if (!bylem[i] && odleglosci[i] < min){
                        min = odleglosci[i];
                        poz = i;
                    }
                }
                if (poz == -1)
                    break;
                bool kon = true;
                bylem[poz] = true;
                while (kon){
                    try { k = graf.Kolejna_krawędź(i_s.znajdz_element_z_kluczem(poz)); }
                    catch { kon = false; }
                    if (!kon) break;
                    odleglosci[s.znajdz_element_z_kluczem(k.get_dest())] = 
                    odleglosci[poz] + k.get_weigth();
                }
            }
            odleglosci = null;
            bylem = null;
            s = null;
        }

        static void Main(string[] args)
        {
            p = new Graf_random_gen(w1, k1);
            Console.WriteLine("Mam Testy!!");
                string[] temp = new string[w1];
            for (int i = 0; i < w1; i++)
                temp[i]=p.Nastepny_wierzchołek();
            Graf1 g1 = new Graf1(temp);
            Graf2 g2 = new Graf2();
            Console.WriteLine("Graf 1 ma wierzchołki!!");
            p.Reset_wie();
            for (int i = 0; i < w1; i++){
                string h = p.Nastepny_wierzchołek();
                g2.Dodaj_wierzchołek(h);
            }
            Console.WriteLine("Graf 2 ma wierzchołki!!");
            for (int i = 0; i < k1; i++){
                triple h = p.Nastepna_krawedz();
                g1.Dodaj_krawędź_z_wagą(h.get_a(),h.get_b(),h.get_c());
                g1.Dodaj_krawędź_z_wagą(h.get_b(),h.get_a(),h.get_c());
                g2.Dodaj_krawędź_z_wagą(h.get_a(), h.get_b(), h.get_c());
                g2.Dodaj_krawędź_z_wagą(h.get_b(), h.get_a(), h.get_c());
            }
            Console.WriteLine("Oba grafy gotowe!!");
            Stopwatch k = new Stopwatch();
            int a, b;
            Random rand = new Random();
            a = rand.Next(w1);
            b = rand.Next(w1);
            //Rozpoczęcie testu 1
            Console.WriteLine("Pierwszy test:");
            k.Start();
            Dijkstra(temp[a],temp[b],g1);
            k.Stop();
            Console.WriteLine("Czas potrzebny pierwszej implementacji:" + k.Elapsed);
            //Zakończenie testu 1
            k.Reset();
            //Rozpoczącie testu 2
            Console.WriteLine("Drugi test:");
            k.Start();
            Dijkstra(temp[a], temp[b], g2);
            k.Stop();
            Console.WriteLine("Czas potrzebny drugiej implementacji:" + k.Elapsed);
            //Zakończenie testu 2
        }
    }
}
