// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Sin extends Operator1arg{
	public Sin(Wyrazenie _w1) {
		super(_w1);
	}
	@Override
	public double oblicz() {
		return Math.sin(w1.oblicz());
	}
	@Override
	public String opis() {
		return "sin("+w1.opis()+")";
	}
}
