// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Mnoz extends Operator2arg {
	public Mnoz(Wyrazenie _w1, Wyrazenie _w2) {
		super(_w1, _w2);
	}
	@Override
	public double oblicz() {
		return w1.oblicz()*w2.oblicz();
	}
	@Override
	public String opis() {
		boolean czy_plus_minus_poza_nawiasem = false;
		int liczba_nawiasow = 0;
		String 	ls = w1.opis(),
				ps = w2.opis(),
				mnoz=new String("*");
		for (int i = 0; i < ps.length(); i++)
			if (ps.charAt(i) == '(')
				liczba_nawiasow++;
			else if (ps.charAt(i) == ')')
				liczba_nawiasow--;
			else if ((ps.charAt(i) == '+'||ps.charAt(i)=='-' || ls.charAt(i) == '%')&&liczba_nawiasow == 0)
				czy_plus_minus_poza_nawiasem = true;
		if (czy_plus_minus_poza_nawiasem) {
			ps+=')';
			ps = '(' + ps;
		}
		for (int i = 0; i < ls.length(); i++)
			if (ls.charAt(i) == '(')
				liczba_nawiasow++;
			else if (ls.charAt(i)== ')')
				liczba_nawiasow--;
			else if ((ls.charAt(i) == '+' || ls.charAt(i) == '-' || ls.charAt(i) == '%') && liczba_nawiasow == 0)
				czy_plus_minus_poza_nawiasem = true;
		if (czy_plus_minus_poza_nawiasem) {
			ls+=')';
			ls = '(' + ls;
		}
		return ls + mnoz + ps;
	}
}
