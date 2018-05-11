// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Liczba extends Wyrazenie {
	private Double g;
	public Liczba(double h) {
		g=h;
	}
	@Override
	public double oblicz() {
		return g;
	}
	@Override
	public String opis() {
		return g.toString();
	}
}
