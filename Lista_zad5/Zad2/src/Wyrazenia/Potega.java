// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Potega extends Operator2arg {
	public Potega(Wyrazenie _w1, Wyrazenie _w2) {
		super(_w1, _w2);
	}
	@Override
	public double oblicz() {
		return Math.pow(w1.oblicz(), w2.oblicz());
	}
	@Override
	public String opis() {
		String	ls = w1.opis(),
				ps = w2.opis();
		if (ls != "pi"&&ls!="e"&&ls!="fi"&&!Zmienna.czyJestWSrodowisku(ls)&&!Wyrazenie.czyDouble(ls)) {
			ls = "(" + ls + ")";
		}
		boolean czy_plus_minus_mnoz_dziel_mod_poza_nawiasem=false;
		int liczba_nawiasow = 0;
		for (int i = 0; i < ps.length(); i++)
			if (ps.charAt(i) == '(')
				liczba_nawiasow++;
			else if (ps.charAt(i) == ')')
				liczba_nawiasow--;
			else if ((	ps.charAt(i) == '+' || ps.charAt(i) == '-' 
						|| ps.charAt(i) == '*' || ps.charAt(i) == '/' 
						|| ps.charAt(i) == '%') && liczba_nawiasow == 0)
				czy_plus_minus_mnoz_dziel_mod_poza_nawiasem = true;
		if (czy_plus_minus_mnoz_dziel_mod_poza_nawiasem) {
			ps += ')';
			ps = '(' + ps;
		}
		return ls + "^" + ps;
	}
}
