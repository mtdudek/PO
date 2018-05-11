// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Ln extends Operator1arg {
	public Ln(Wyrazenie _w1) {
		super(_w1);
	}
	@Override
	public double oblicz() {
		return Math.log(w1.oblicz());
	}
	@Override
	public String opis() {
		return "Ln("+w1.opis()+")";
	}
}
