// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Cos extends Operator1arg {
	public Cos(Wyrazenie _w1) {
		super(_w1);
	}
	@Override
	public double oblicz() {
		return Math.cos(w1.oblicz());
	}
	@Override
	public String opis() {
		return "cos("+w1.opis()+")";
	}
}
