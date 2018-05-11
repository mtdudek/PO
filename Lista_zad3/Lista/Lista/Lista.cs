//////////////////////////////
//  Programowanie Obiektowe //
//  Maciej Tomasz Dudek     //
//  Nr. indeksu 299168      //
//  Pracownia 3             //
//  Zadanie 1-Lista         //
//////////////////////////////
using System;

namespace Lista{ 
    //klasa wewnętrzna, niedostępna dla innych
    internal class Node<T> {
        T val;
        Node<T> next, previus;
        
        internal Node(T val_t) {
            next = null;
            previus = null;
            val = val_t;
        }
        
        internal T val_get() {
            return val;
        }
        
        internal Node<T> next_obj(){
            return next;
        }
        
        internal Node<T> previus_obj(){
            return previus;
        }
        
        internal void set_next_obj(Node<T> A){
            next = A;
        }
        
        internal void set_previus_obj(Node<T> A){
            previus = A;
        }
    }
    public class Lista<T> {
        private Node<T> front, end;
        private int size;
        
        ///Konstruktor domyślny
        public Lista(){
            front = null;
            end = null;
            size = 0;
        }
        
        ///usuń i zwróć pierwszy element z listy
        public T pop_begin() {
            if (size <= 0)
                throw new Exception("Empty list!"); 
            Node<T> temp = front;
            front = front.next_obj();
            size--;
            return temp.val_get();
        }
        
        ///usuń i zwróć ostatni element z listy
        public T pop_back() {
            if (size <= 0)
                throw new Exception("Empty list!");
            Node<T> temp = end;
            end = end.previus_obj();
            size--;
            return temp.val_get();
        }
        
        ///zwróć pierwszy element z listy
        public T begin(){
            return front.val_get();
        }
        ///zwróć ostatni element z listy
        public T back(){
            return end.val_get();
        }
        
        ///dodaj na początek listy
        public void push_begin(T val) {
            Node<T> t = new Node<T>(val);
            size++;
            if(size == 1){
                front = t;
                end = t;
                return;
            }
            front.set_previus_obj(t);
            t.set_next_obj(front);
            front = t;
        }
        
        ///dodaj na koniec listy
        public void push_back(T val) {
            Node<T> t = new Node<T>(val);
            size++;
            if (size == 1){
                front = t;
                end = t;
                return;
            }
            end.set_next_obj(t);
            t.set_previus_obj(end);
            end = t;
        }
    }
}
