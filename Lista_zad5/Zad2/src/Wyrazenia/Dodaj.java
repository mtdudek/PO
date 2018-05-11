// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Dodaj extends Operator2arg {
	public Dodaj(Wyrazenie _w1, Wyrazenie _w2) {
		super(_w1, _w2);
	}
	@Override
	public double oblicz() {
		return w1.oblicz()+w2.oblicz();
	}
	@Override
	public String opis() {
		return w1.opis() + "+" + w2.opis();
	}
}
