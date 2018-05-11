// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Modulo extends Operator2arg {
	public Modulo(Wyrazenie _w1, Wyrazenie _w2) {
		super(_w1, _w2);
	}
	@Override
	public double oblicz() {
		double 	g = w1.oblicz(),
				t = w2.oblicz();
		if (t >= 0) {
			while (g < 0)
				g += t;
			while (g >= t)
				g -= t;
		}else {
			while (g + t >= 0)
				g += t;
			while (g < 0)
				g -= t;
		}
		return g; 
	}
	@Override
	public String opis() {
		String	ls = w1.opis(),
				ps = w2.opis();
		if (ls != "pi"&&ls != "e"&&ls != "fi" && !Zmienna.czyJestWSrodowisku(ls) && !Wyrazenie.czyDouble(ls)) {
			ls = "(" + ls + ")";
		}
		if (ps != "pi"&&ps != "e"&&ps != "fi" && !Zmienna.czyJestWSrodowisku(ps) && !Wyrazenie.czyDouble(ps)) {
			ps = "(" + ps + ")";
		}
		return ls + "%" + ps;
	}
}
