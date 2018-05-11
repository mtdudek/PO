// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L3, z2 Słownik
// Słownik_test
// Słownik.dll
// 2018-03-15
using System;

namespace Slownik
{
    public class Slownik<K, V>{
        slowniki<K,V> inter;
        // domyślny konstruktor
        public Slownik(){
            string  inte1 = "IComparable",
                    inte2= "IEquatable";
            if (typeof(K).GetInterface(inte1) != null){
                inter = new slownik_czarno_czerwony<K, V>();
            }
            else if (typeof(K).GetInterface(inte2) != null){
                inter = new slownik_ogokny<K, V>();
            }
            else
                throw new Exception("Obiekty tej klas nie da sie poruwnać.\n" +
                    "Może zapomniałeś dodać " + inte1 + "lub " + inte2);
        }
        // dodaj element
        public void dodaj_element_z_kluczem(K key, V val){
            inter.dodaj_element_z_kluczem(key , val);
        }
        // znajdź element
        public V znajdz_element_z_kluczem(K k){
            return inter.znajdz_element_z_kluczem(k);
        }
        // usuń element
        public void usun_element_z_kluczem(K k){
            inter.usun_element_z_kluczem(k);
        }
        // wypisz cały słownik
        public void wypisz_caly_slownik(){
            inter.wypisz_caly_slownik();
        }
        // liczba elementów w słowniku
        public void liczba_elementow(){
            inter.liczba_elementow();
        }
        public void zmien_wartosc (K key, V val){
            inter.zmien_wartosc(key,val);
        }
    }
    internal abstract class slowniki<K, V>{
        internal virtual void dodaj_element_z_kluczem(K key, V val) { throw new NotImplementedException(); }
        internal virtual V znajdz_element_z_kluczem(K k) { throw new NotImplementedException(); }
        internal virtual void usun_element_z_kluczem(K k) { throw new NotImplementedException(); }
        internal virtual void wypisz_caly_slownik() { throw new NotImplementedException(); }
        internal virtual int liczba_elementow() { throw new NotImplementedException(); }
        internal virtual void zmien_wartosc(K key, V val) { throw new NotImplementedException(); }

    }
    internal class slownik_ogokny<K, V> : slowniki<K,V>
    {
        Node first, last;
        int size;
        internal class Node{
            internal K key;
            internal V val;
            internal Node next;
            internal Node(K k, V v){
                key = k;
                val = v;
                next = null;
            }
            internal Node(){
                key = default(K);
                val = default(V);
                next = null;
            }
        }
        internal slownik_ogokny(){
            size = new int();
            size = 0;
            first = new Node();
            last = first;
        }
        internal override void dodaj_element_z_kluczem(K key, V val){
            size++;
            last.next = new Node(key, val);
            last = last.next;
        }
        internal override V znajdz_element_z_kluczem(K k){
            Node p = first;
            while (p.next != null){
                p = p.next;
                if (p.key.Equals(k))
                    return p.val;
            }
            throw new System.ArgumentException("Nie ma w słowniku!!!\n");
        }
        internal override void zmien_wartosc(K key, V val){
            Node p = first;
            while (p.next != null){
                p = p.next;
                if (p.key.Equals(key))
                    p.val = val;
            }
            throw new System.ArgumentException("Nie ma w słowniku!!!\n");
        }
        internal override void usun_element_z_kluczem(K k){
            size--;
            Node p = first;
            while (p.next != null){
                if (p.next.key.Equals(k)){
                    p.next = p.next.next;
                    return;
                }
                p = p.next;
            }
        }
        internal override void wypisz_caly_slownik() {
            Node p = first;
            while (p.next != null){
                p = p.next;
                Console.WriteLine(p.key.ToString(), p.val.ToString());
            }
        }
        internal override int liczba_elementow() {
            return size;
        }
    }
    internal class slownik_czarno_czerwony<K, V> : slowniki<K, V>{
        internal class Node{
            internal IComparable<K> key;
            internal V val;
            internal Node Lson,Rson,Parent;
            internal bool black;
            internal Node(K k, V v){

                key = (IComparable<K>)k;
                val = v;
                black = false;
                Lson = null;
                Rson = null;
                Parent = null;
            }
            internal Node(){
                key = default(IComparable<K>);
                val = default(V);
                black = false;
                Lson = null;
                Rson = null;
                Parent = null;
            }
            internal Node get_Parent(){
                return Parent;
            }
            internal Node get_Grandparent(){
                Node t = this.get_Parent();
                if (t == null)
                    return null;
                return t.get_Parent();
            }
            internal Node get_Sibling(){
                Node t = this.get_Parent();
                if (t == null)
                    return null;
                if (this == t.Lson)
                    return t.Rson;
                else
                    return t.Lson;
            }
            internal Node get_Uncle(){
                Node t1 = this.get_Parent(),
                     t2 = this.get_Grandparent();
                if (t2 == null)
                    return null;
                return t1.get_Sibling();
            }
            internal void rotate_left(){
                Node nn = this.Rson;
                this.Rson = nn.Lson;
                if (nn.Lson != null)
                    nn.Lson.Parent = this;
                nn.Lson = this;
                nn.Parent = this.get_Parent();
                Node g = this.get_Parent();
                this.Parent = nn;
                if (g != null){
                    if (g.Lson == this)
                        g.Lson = nn;
                    else
                        g.Rson = nn;
                }
            }
            internal void rotate_right(){
                Node nn = this.Lson;
                this.Lson = nn.Rson;
                if (nn.Rson != null)
                    nn.Rson.Parent = this;
                nn.Rson = this;
                nn.Parent = this.get_Parent();
                Node g = this.get_Parent();
                this.Parent = nn;
                if(g!=null){
                    if (g.Lson == this)
                        g.Lson = nn;
                    else
                        g.Rson = nn;
                }
            }
            internal void replace(Node n){
                IComparable<K> t = this.key;
                this.key = n.key;
                n.key = t;
                V tv = this.val;
                this.val = n.val;
                n.val = tv;
            }
        }
        int size;
        Node root;
        internal slownik_czarno_czerwony(){
            root = null;
            size = new int();
            size = 0;
        }
        private void insert(Node ro,Node n){
            if (ro == null){
                ro = n;
            }
            else if (ro != null && ro.key.CompareTo((K)n.key) < 0){
                if (ro.Lson != null)
                    insert(ro.Lson, n);
                else{
                    ro.Lson = n;
                    n.Parent = ro;
                }
            }
            else{
                if (ro.Rson != null)
                    insert(ro.Rson, n);
                else{
                    ro.Rson = n;
                    n.Parent = ro;
                }
            }
        }
        private void insert_repair(Node n){
            if (n.get_Parent() == null)
                insert_c1(n);
            else if (n.get_Parent().black)
                insert_c2(n);
            else if (n.get_Uncle()!=null && !n.get_Uncle().black)
                insert_c3(n);
            else
                insert_c4(n);
        }
        private void insert_c1(Node n){
            n.black = true;
        }
        private void insert_c2(Node n){
            return;
        }
        private void insert_c3(Node n){
            n.get_Parent().black = true;
            if(n.get_Uncle()!=null)
                n.get_Uncle().black = true;
            if (n.get_Grandparent() != null){
                n.get_Grandparent().black = false;
                insert_repair(n.get_Grandparent());
            }
        }
        private void insert_c4(Node n){
            Node p = n.get_Parent(),
                 g = n.get_Grandparent();
            if (g != null ){
                if (g.Lson != null && n == g.Lson.Rson){
                    p.rotate_left();
                    n = n.Lson;
                }else if (g.Rson != null && n == g.Rson.Lson) {
                    p.rotate_right();
                    n = n.Rson;
                }
                p = n.get_Parent();
                g = n.get_Grandparent();
            }
            if (n == p.Lson)
                g.rotate_right();
            else
                g.rotate_left();
            p.black = true;
            g.black = false;
        }
        internal override void dodaj_element_z_kluczem(K key, V val){
            size++;
            Node n = new Node(key, val);
            insert(root, n);
            insert_repair(n);
            root = n;
            while (root.get_Parent() != null)
                root = root.get_Parent();
        }
        internal Node find_node_with_key(K k){
            Node h = root;
            while (h!=null&&h.key.CompareTo(k) != 0){
                if (h.key.CompareTo(k) < 0)
                    h = h.Lson;
                else
                    h = h.Rson;
            }
            if (h == null)
                throw new System.ArgumentException("Brak w słowniku"+k.ToString());
            return h;
        }
        internal override V znajdz_element_z_kluczem(K k){
            return find_node_with_key(k).val;
        }
        internal override void usun_element_z_kluczem(K k){
            Node n = find_node_with_key(k),
                 te = n;
            if (n.Rson != null){
                te = n.Rson;
                while (te.Lson != null)
                    te = te.Lson;
            } else if (n.Lson != null){
                te = n.Lson;
                while (te.Rson != null)
                    te = te.Rson;
            }
            if (n != te){
                n.replace(te);
                n = te;
            }
            Node c = n.Rson == null ? n.Lson : n.Rson;
            if (c == null){
                if (n.get_Parent() != null){
                    if (n == n.Parent.Lson)
                        n.Parent.Lson = null;
                    else
                        n.Parent.Rson = null;
                } else
                    root = null;
            }
            else{
                n.replace(c);
                bool t = n.black;
                n.black = c.black;
                c.black = t;
                n.Lson = c.Lson;
                n.Rson = c.Rson;
                c.Parent = null;
                c.Lson = null;
                c.Rson = null;
                if (c.black){
                    if (!n.black){
                        n.black = true;
                    } else
                        delete_c1(n);
                }
                if (n.Lson == c)
                    n.Lson = null;
                else
                    n.Rson = null;
            }
        }
        internal void delete_c1(Node n){
            if (n.get_Parent() != null)
                delete_c2(n);
        }
        internal void delete_c2(Node n){
            Node s = n.get_Sibling();
            if (!s.black){
                n.Parent.black = false;
                s.black = true;
                if (n == n.Parent.Lson)
                    n.Parent.rotate_left();
                else
                    n.Parent.rotate_right();
            }
            delete_c3(n);
        }
        internal void delete_c3(Node n){
            Node s = n.get_Sibling();
            if (n.Parent.black && s.black && s.Lson.black && s.Rson.black){
                s.black = false;
                delete_c1(n.Parent);
            } else
                delete_c4(n);
        }
        internal void delete_c4(Node n){
            Node s = n.get_Sibling();
            if (!n.Parent.black && s.black && s.Lson.black && s.Rson.black){
                s.black = false;
                n.Parent.black = true;
            } else
                delete_c5(n);
        }
        internal void delete_c5(Node n){
            Node s = n.get_Sibling();
            if (n == n.Parent.Lson && s.Rson.black && !s.Lson.black){
                s.black = false;
                s.Lson.black = true;
                s.rotate_right();
            } else if(n==n.Parent.Rson&& s.Lson.black && !s.Rson.black){
                s.black = false;
                s.Rson.black = true;
                s.rotate_left();
            }
            delete_c6(n);
        }
        internal void delete_c6(Node n){
            Node s = n.get_Sibling();
            s.black = n.Parent.black;
            if (n == n.Parent.Lson){
                s.Rson.black = true;
                n.Parent.rotate_left();
            } else{
                s.Lson.black = true;
                n.Parent.rotate_right();
            }
        }
        internal override int liczba_elementow(){
            return size;
        }
        internal override void wypisz_caly_slownik(){
            recursion_print(root,"");
            Console.WriteLine("\nWypisany");
        }
        internal void recursion_print(Node n,string h){
            if (n == null)
                return;
            Node p = n.get_Parent();
            Console.Write(h + n.black + " " + n.key.ToString() + " wartość:" 
                + n.val.ToString() + " Ojc:");
            if (p != null)
                Console.WriteLine(p.key);
            else
                Console.WriteLine();
            if (n.Lson != null){
                Console.WriteLine("L:");
                recursion_print(n.Lson, h + "  ");
            }
            if (n.Rson != null){
                Console.WriteLine("P:");
                recursion_print(n.Rson,h+"  ");
            }
        }
        internal override void zmien_wartosc(K key, V val){
            Node h = find_node_with_key(key);
            h.val = val;
        }
    }
}
