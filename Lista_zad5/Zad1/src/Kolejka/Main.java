// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z1 Kolejka i Hierarchia
// 2018-04-12
package Kolejka;
import Hierarchia.*;

public class Main {
	public static void main(String[] args) throws EmptyStackExeption {
		Kolejka<String> t=new Kolejka<String>();
		Kolejka<Integer> i= new Kolejka<Integer>();
		i.push(3);
		i.push(1);
		i.push(2);
		i.print_all();
		System.out.println("I'M ALIVE");
		t.push("This was a triumph.");
		t.push("I'm making a note here:");
		t.push("HUGE SUCCESS.");
		t.print_all();
	}
}
