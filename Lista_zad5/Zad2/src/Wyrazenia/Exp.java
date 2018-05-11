// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Exp extends Operator1arg{
	public Exp(Wyrazenie _w1) {
		super(_w1);
	}
	@Override
	public double oblicz() {
		return Math.exp(w1.oblicz());
	}
	@Override
	public String opis() {
		String ps = w1.opis();
		boolean czy_plus_minus_mnoz_dziel_mod_poza_nawiasem = false;
		int liczba_nawiasow = 0;
		for (int i = 0; i < ps.length(); i++)
			if (ps.charAt(i) == '(')
				liczba_nawiasow++;
			else if (ps.charAt(i) == ')')
				liczba_nawiasow--;
			else if ((	ps.charAt(i) == '+' || ps.charAt(i) == '-' ||
						ps.charAt(i) == '*' || ps.charAt(i) == '/' ||
						ps.charAt(i) == '%') && liczba_nawiasow == 0)
				czy_plus_minus_mnoz_dziel_mod_poza_nawiasem = true;
		if (czy_plus_minus_mnoz_dziel_mod_poza_nawiasem) {
			ps+=')';
			ps = '(' + ps;
		}
		return "e^"+ps;
	}
}
