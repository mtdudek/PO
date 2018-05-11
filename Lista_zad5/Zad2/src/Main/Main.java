// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Main;
import Wyrazenia.*;

public class Main {
	public static void main(String [] args) {
		Wyrazenie k =new Dodaj(new Liczba(4.0),new Liczba(7.0));
		System.out.println(k.opis());
		System.out.println(k.oblicz());
	}
}
