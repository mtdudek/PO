//////////////////////////////
//  Programowanie Obiektowe //
//  Maciej Tomasz Dudek     //
//  Nr. indeksu 299168      //
//  Pracownia 4             //
//  Zadanie 3-Graf          //
//////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slownik;

namespace Graf
{
    //Interfejs grafowy

    public interface  graf_interface{

        //Dodaj wierzchołek fo grafu
        void Dodaj_wierzchołek(string a);

        //Sprawdza czy wierzchołek jest w grafie
        bool Czy_jest_wierzchołek(string a);

        //Usuwa wierzchołek z grafu
        void Usun_wierzchołek(string a);

        //Dodaje krawędź z wagą
        void Dodaj_krawędź_z_wagą(string a, string b, int c);

        //Sprawdza czy jest krawędź między wierzchołkami
        bool Czy_jest_krawędź(string a,string b);

        //Usuwa krawędź z grafu
        void Usun_krawędź(string a, string b);

        //Resetuje na której krawędź jest wierzchołek 
        void Resetuj_krawędź(string a);

        //Udąstępnia następną krawędź
        kra Kolejna_krawędź(string a);
    }
    //Klasa pomocnicza do pozyskiwania krawędzi
    public class kra{
        int weight;
        string dest;

        public kra(int a,string b){
            weight = new int();
            weight = a;
            dest = new string(b.ToCharArray());
        }

        //Udostępnia wagę krawędzi
        public int get_weigth(){
            return weight;
        }

        //Udostępnia koniec krawędzi
        public string get_dest(){
            return dest;
        }
    }

    //Klasa pomocnicza do generatora grafu
    public class triple{
        string a, b;
        int c;

        public triple(string _a,string _b,int _c){
            a = new string(_a.ToCharArray());
            b = new string(_b.ToCharArray());
            c = _c;
        }

        //Udostępnia pierwszy z konców krawędzi
        public string get_a(){
            return a;
        }

        //Udostępnia drugi z końców krawędzi
        public string get_b(){
            return b;
        }

        //Udostępnia wagę krawędzi
        public int get_c(){
            return c;
        }
    }

    //Obiekt do twirzenia losowych grafów
    public class Graf_random_gen{
        string[] wierzchołki;
        triple[] krawedzie;
        int w_s,k_s,index1, index2;
        Slownik<int, string> i_s;
        Slownik<int, Slownik<int,bool>> s;

        //Generator stringów 
        string String_gen(){
            string chars =  "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmn"+
                            "opqrstuvwxyz0123456789";
            char[] stringChars = new char[8];
            Random random = new Random();

            for (int i = 0; i<stringChars.Length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];
            return new String(stringChars);
        }

        //Konstruktor
        public Graf_random_gen(int w,int k){
            w_s = w;
            k_s = k;
            index1 = -1;
            index2 = -1;
            i_s = new Slownik<int, string>();
            s = new Slownik<int, Slownik<int, bool>>();
            wierzchołki = new string[w];
            if (k > w * (w - 1) / 2)
                k = w * (w - 1) / 2;
            krawedzie = new triple[k];
            //Generowanie wierzchołków
            for (int i = 0; i < w; i++){
                string h = String_gen();
                wierzchołki[i] = h;
                i_s.dodaj_element_z_kluczem(i, h);
                s.dodaj_element_z_kluczem(i, new Slownik<int, bool>());
            }
            Console.WriteLine("Mam wierzchołki");
            for (int i = 0; i < w; i++)
                for (int j = 0; j < w; j++)
                    if (i == j)
                        s.znajdz_element_z_kluczem(i).
                        dodaj_element_z_kluczem(j, true);
                    else
                        s.znajdz_element_z_kluczem(i).
                        dodaj_element_z_kluczem(j, false);
            //Generowanie krawędzi
            Random rand1 = new Random(new System.DateTime().Millisecond);
            Random rand2 = new Random(new System.DateTime().Millisecond * 11);
            for (int i = 0; i < k; i++){
                int a = rand1.Next(w);
                int b = rand2.Next(w);
                int c = rand1.Next(1,10000);
                if (a == b) i--;
                else if (s.znajdz_element_z_kluczem(a).
                         znajdz_element_z_kluczem(b)) i--;
                else{
                    s.znajdz_element_z_kluczem(a).zmien_wartosc(b, true);
                    s.znajdz_element_z_kluczem(b).zmien_wartosc(a, true);
                    krawedzie[i] = new triple(i_s.znajdz_element_z_kluczem(a),
                                              i_s.znajdz_element_z_kluczem(b),c);
                }
            }
        }

        //Następny wierzchołek z grafu
        public string Nastepny_wierzchołek(){
            index1++;
            if (index1 >= w_s)
                throw new System.ArgumentException();
            return wierzchołki[index1];
        }

        //Następna krawędź z grafu
        public triple Nastepna_krawedz(){
            index2++;
            if (index2 >= k_s)
                throw new System.ArgumentException();
            return krawedzie[index2];
        }

        //Resetuje wypisywanie wierzchołków
        public void Reset_wie(){
            index1 = -1;
        }

        //Resetuje wypisywanie krawędzi
        public void Reset_kraw(){
            index2 = -1;
        }
    }

    //Implementacja grafu jako macierzy sąsiedztwa
    public class Graf1 : graf_interface{
        Slownik<string,int> Sl1;
        Slownik<int, string> Sl2;
        int liczba_wierz;
        int[,] actual_tab, old_tab;
        int[] act_kra,old_kra;

        public Graf1(){
            liczba_wierz = new int();
            liczba_wierz = 0;
            actual_tab = new int[liczba_wierz, liczba_wierz];
            act_kra = new int[liczba_wierz];
            Sl1 = new Slownik<string, int>();
            Sl2 = new Slownik<int, string>();
        }

        public Graf1(string[] k){
            liczba_wierz = new int();
            liczba_wierz = k.Length;
            actual_tab = new int[liczba_wierz, liczba_wierz];
            act_kra = new int[liczba_wierz];
            Sl1 = new Slownik<string, int>();
            Sl2 = new Slownik<int, string>();
            for (int i = 0; i < k.Length; i++){
                Sl1.dodaj_element_z_kluczem(k[i], i);
                Sl2.dodaj_element_z_kluczem(i, k[i]);
                act_kra[i] = -1;
            }

        }

        public void Dodaj_wierzchołek(string a){
            if (Czy_jest_wierzchołek(a))
                throw new System.ArgumentException("Już instnieje");
            Sl1.dodaj_element_z_kluczem(a, liczba_wierz);
            Sl2.dodaj_element_z_kluczem(liczba_wierz, a);
            liczba_wierz++;
            old_tab = actual_tab;
            actual_tab = new int[liczba_wierz, liczba_wierz];
            for (int i = 0; i < liczba_wierz - 1; i++)
                for (int j = 0; j < liczba_wierz - 1; j++)
                    actual_tab[i, j] = old_tab[i, j];
            old_kra = act_kra;
            act_kra = new int[liczba_wierz];
            for (int i = 0; i < liczba_wierz - 1; i++)
                act_kra[i] = old_kra[i];
            act_kra[liczba_wierz - 1] = -1;
        }

        public bool Czy_jest_wierzchołek(string a){
            bool n = new bool();
            n = true;
            try{
                Sl1.znajdz_element_z_kluczem(a);
            }catch{
                n = false;
            }
            return n;
        }

        public void Usun_wierzchołek(string a){
            int g;
            if (Czy_jest_wierzchołek(a)){
                g = Sl1.znajdz_element_z_kluczem(a);
                Sl1.usun_element_z_kluczem(a);
                Sl2.usun_element_z_kluczem(g);
                for (int i = g + 1; i < liczba_wierz; i++){
                    string t1 = Sl2.znajdz_element_z_kluczem(i);
                    Sl2.usun_element_z_kluczem(i);
                    Sl2.dodaj_element_z_kluczem(i - 1, t1);
                    Sl1.usun_element_z_kluczem(t1);
                    Sl1.dodaj_element_z_kluczem(t1, i - 1);
                }
                liczba_wierz--;
                old_tab = actual_tab;
                old_kra = act_kra;
                act_kra = new int[liczba_wierz];
                actual_tab = new int[liczba_wierz, liczba_wierz];
                for (int i = 0; i < liczba_wierz; i++){
                    if (i >= g){
                        if (act_kra[i + 1] >= g){
                            act_kra[i] = old_kra[i + 1] - 1;
                        }else{
                            act_kra[i] = old_kra[i + 1];
                        }
                    }else{
                        if (act_kra[i + 1] >= g){
                            act_kra[i] = old_kra[i] - 1;
                        }else{
                            act_kra[i] = old_kra[i];
                        }
                    }
                }
                for(int i = 0; i < liczba_wierz; i++){
                    for (int j = 0; j < liczba_wierz; j++){
                        if (i >= g){
                            if (j >= g){
                                actual_tab[i,j] = old_tab[i + 1,j+1];
                            }else{
                                actual_tab[i,j] = old_tab[i + 1,j];
                            }
                        }else{
                            if (j>= g){
                                actual_tab[i,j] = old_tab[i,j+1];
                            }else{
                                actual_tab[i,j] = old_tab[i,j];
                            }
                        }
                    }
                }
            }
        }

        public void Dodaj_krawędź_z_wagą(string a, string b, int c){
            if (!Czy_jest_wierzchołek(a) || !Czy_jest_wierzchołek(b))
                throw new System.ArgumentException("Któryś z wierzchołków" +
                                                   " nie isnieje");
            actual_tab[Sl1.znajdz_element_z_kluczem(a),
                       Sl1.znajdz_element_z_kluczem(b)]= c;
        }

        public bool Czy_jest_krawędź(string a, string b){
            if (!Czy_jest_wierzchołek(a) || !Czy_jest_wierzchołek(b))
                throw new System.ArgumentException("Któryś z wierzchołków" +
                                                   " nie isnieje");
            return actual_tab[Sl1.znajdz_element_z_kluczem(a), 
                              Sl1.znajdz_element_z_kluczem(b)]>0;
        }

        public void Usun_krawędź(string a, string b){
            if (!Czy_jest_wierzchołek(a) || !Czy_jest_wierzchołek(b))
                throw new System.ArgumentException("Któryś z wierzchołków" +
                                                   " nie isnieje");
            actual_tab[Sl1.znajdz_element_z_kluczem(a),
                       Sl1.znajdz_element_z_kluczem(b)]= 0;
        }

        public void Resetuj_krawędź(string a){
            if (!Czy_jest_wierzchołek(a))
                throw new System.ArgumentException("Wierzchołek nie istnieje");
            act_kra[Sl1.znajdz_element_z_kluczem(a)] = -1;
        }

        public kra Kolejna_krawędź(string a){
            if (!Czy_jest_wierzchołek(a))
                throw new System.ArgumentException("Wierzchołek nie istnieje");
            int u = Sl1.znajdz_element_z_kluczem(a);
            int j = act_kra[u];
            j++;
            while (j < liczba_wierz && actual_tab[u, j] == 0)
                j++;
            act_kra[u] = j;
            if (j == liczba_wierz){
                throw new System.ArgumentException("Brak krawedzi");
            }
            return new kra(actual_tab[u,j],Sl2.znajdz_element_z_kluczem(j));
        }
    }

    //Implementacja grafu jako obiektów "Wierzchołek"
    //z krawędziami do swoich sąsiadów
    public class Graf2:graf_interface{
        //Klasa wierzchołków
        internal class Vertix{
            kra[] tab;
            int index,size;
            internal string name;

            internal Vertix(string name_){
                index = new int();
                size = new int();
                size = 0;
                index = -1;
                tab = new kra[size];
                name = new string(name_.ToCharArray());
            }

            //Usuń ścierzkę do wieszchołka
            internal void delete_path(string a){
                kra[] tab_old = tab;
                int jest = -1;
                for (int i = 0; i < size; i++)
                    if (tab[i].get_dest() == a)
                        jest = i;
                if (jest>-1){
                    if (index >= jest)
                        index--;
                    size--;
                    tab = new kra[size];
                    for (int i = 0; i < size + 1; i++){
                        if (tab_old[i].get_dest() != a){
                            if (i>jest)
                                tab[i - 1] = tab_old[i];
                            else
                                tab[i] = tab_old[i];
                        }
                    }
                }
            }

            //Dodaj ścierzkę
            internal void add_path(kra d){
                kra[] tab_old = tab;
                size++;
                tab = new kra[size];
                for (int i = 0; i < size - 1; i++)
                    tab[i] = tab_old[i];
                tab[size - 1] = d;
            }

            //Sprawdza czy isnieje ścieżka
            internal bool is_path(string a){
                for (int i = 0; i < size; i++)
                    if (tab[i].get_dest() == a)
                        return true;
                return false;
            }

            //Resetuje przeszukiwanie ścierzek
            internal void reset_path(){
                index = -1;
            }

            //Zwraca następną ścierzkę
            internal kra next_path(){
                index++;
                if(index==size)
                    throw new System.ArgumentException("Brak krawedzi");
                return tab[index];
            }
        }
        Slownik<string,Vertix> S;
        Slownik<int, Vertix> Si;
        int liczba_wierz;

        public Graf2(){
            S = new Slownik<string, Vertix>();
            Si = new Slownik<int, Vertix>();
            liczba_wierz = new int();
            liczba_wierz = 0;
        }

        public void Dodaj_wierzchołek(string a){
            if (Czy_jest_wierzchołek(a))
                throw new System.ArgumentException("Wierzchołek istnieje");
            Vertix n = new Vertix(a);
            S.dodaj_element_z_kluczem(a, n);
            Si.dodaj_element_z_kluczem(liczba_wierz, n);
            liczba_wierz++;
        }

        public bool Czy_jest_wierzchołek(string a){
            bool n = new bool();
            n = true;
            try{S.znajdz_element_z_kluczem(a);}
            catch{n = false;}
            return n;
        }

        public void Usun_wierzchołek(string a){
            if (!Czy_jest_wierzchołek(a))
                throw new System.ArgumentException("Wierzchołek nie istnieje");
            S.usun_element_z_kluczem(a);
            int g=Int32.MinValue;
            Vertix n;
            for (int i = 0; i < liczba_wierz; i++){
                n = Si.znajdz_element_z_kluczem(i);
                if (n.name == a){
                    Si.usun_element_z_kluczem(i);
                    g = i;
                }
                n.delete_path(a);
                if (i > g){
                    Si.dodaj_element_z_kluczem(i - 1, 
                                               Si.znajdz_element_z_kluczem(i));
                    Si.usun_element_z_kluczem(i);
                }
            }
            liczba_wierz--;
        }

        public void Dodaj_krawędź_z_wagą(string a, string b, int c){
            if (!Czy_jest_wierzchołek(a) || !Czy_jest_wierzchołek(b))
                throw new System.ArgumentException("Któryś z wierzchołków" +
                                                   " nie isnieje");
            S.znajdz_element_z_kluczem(a).add_path(new kra(c, b));
        }

        public bool Czy_jest_krawędź(string a, string b){
            if (!Czy_jest_wierzchołek(a) || !Czy_jest_wierzchołek(b))
                throw new System.ArgumentException("Któryś z wierzchołków" +
                                                   " nie isnieje");
            return S.znajdz_element_z_kluczem(a).is_path(b);
        }

        public void Usun_krawędź(string a, string b){
            if (!Czy_jest_wierzchołek(a) || !Czy_jest_wierzchołek(b))
                throw new System.ArgumentException("Któryś z wierzchołków" +
                                                   " nie isnieje");
            S.znajdz_element_z_kluczem(a).delete_path(b);
        }

        public void Resetuj_krawędź(string a){
            if (!Czy_jest_wierzchołek(a))
                throw new System.ArgumentException("Wierzchołek nie istnieje");
            S.znajdz_element_z_kluczem(a).reset_path();
        }

        public kra Kolejna_krawędź(string a){
            if (!Czy_jest_wierzchołek(a))
                throw new System.ArgumentException("Wierzchołek nie istnieje");
            return S.znajdz_element_z_kluczem(a).next_path();
        }
    }
}
