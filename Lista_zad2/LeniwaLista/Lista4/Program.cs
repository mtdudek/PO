//Maciej Dudek
//indeks: 299186
using System;
using System.Collections.Generic;

public class ListaLeniwa{
    protected List<int> list = new List<int>();
    public int element(int x){
        for (int i = list.Count + 1; i <= x; i++){
            list.Add(i);
        }
        return x;
    }
    public int size(){
        return list.Count;
    }
}

public class Pierwsze : ListaLeniwa{
    public new int element(int x){
        if (list.Count >= x) return list[x];
        for (int i = 2; ; i++){
            bool ok = true;
            for (int j = 0; j < list.Count; j++){
                if (i % list[j] == 0){
                    ok = false;
                    break;
                }
            }
            if (ok){
                list.Add(i);
                if (list.Count >= x) return i;
            }
        }
    }
}


public class MojProgram{
    public static void Main(){
        ListaLeniwa lista = new ListaLeniwa();

        Console.WriteLine(lista.element(5));
        Console.WriteLine(lista.element(42));
        Console.WriteLine(lista.element(6));
        Console.WriteLine(lista.element(17));
        Console.WriteLine(lista.size());

        Pierwsze pierwsze = new Pierwsze();
        Console.WriteLine(pierwsze.element(1));
        Console.WriteLine(pierwsze.element(2));
        Console.WriteLine(pierwsze.element(3));
        Console.WriteLine(pierwsze.element(47));
        Console.WriteLine(pierwsze.element(10));
        Console.WriteLine(pierwsze.element(15));
        Console.WriteLine(pierwsze.size());
    }
}