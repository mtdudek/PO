// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Odwrot extends Operator1arg {
	public Odwrot(Wyrazenie _w1) {
		super(_w1);
	}
	@Override
	public double oblicz() {
		return 1/w1.oblicz();
	}
	@Override
	public String opis() {
		String ps = w1.opis();
		if (ps != "pi"&&ps != "e"&&ps != "fi" && !Zmienna.czyJestWSrodowisku(ps) && !Wyrazenie.czyDouble(ps)) {
			ps = "(" + ps + ")";
		}
		return "1/" + ps;
	}
}
