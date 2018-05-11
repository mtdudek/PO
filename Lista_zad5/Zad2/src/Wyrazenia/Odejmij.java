// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Odejmij extends Operator2arg {
	public Odejmij(Wyrazenie _w1, Wyrazenie _w2) {
		super(_w1, _w2);
	}
	@Override
	public double oblicz() {
		return w1.oblicz()-w2.oblicz();
	}
	@Override
	public String opis() {
		boolean czy_plus_poza_nawiasem=false;
		int liczba_nawiasow=0;
		String 	ps = w2.opis(),
				minus=new String("-");
		for (int i = 0; i < ps.length(); i++)
			if (ps.charAt(i) == '(')
				liczba_nawiasow++;
			else if (ps.charAt(i) == ')')
				liczba_nawiasow--;
			else if (ps.charAt(i) == '+'&&liczba_nawiasow == 0)
				czy_plus_poza_nawiasem = true;
		if (czy_plus_poza_nawiasem) {
			minus+='(';
			ps+=')';
		}
		return w1.opis() + minus + ps;
	}
}
