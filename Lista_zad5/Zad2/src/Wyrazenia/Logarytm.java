// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Logarytm extends Operator2arg {
	public Logarytm(Wyrazenie _w1, Wyrazenie _w2) {
		super(_w1, _w2);
	}
	@Override
	public double oblicz() {
		return Math.log(w2.oblicz())/Math.log(w1.oblicz());
	}
	@Override
	public String opis() {
		String	it1 = w1.opis(),
				it2 = w2.opis();
		return "log(" + it1 + ")(" + it2 + ")";
	}
}
