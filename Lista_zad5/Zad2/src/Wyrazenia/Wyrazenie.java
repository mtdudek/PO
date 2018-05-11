// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public abstract class Wyrazenie{
	public static boolean czyDouble(String h) {
		boolean jest = true;
		int dots = 0;
		for (int i = 0; i < h.length() && jest; i++) {
			if (h.charAt(i) == '.')
				dots++;
			if (dots > 1)
				jest = false;
			if (h.charAt(i) < '0' || '9' < h.charAt(i))
				jest = false;
		}
		return jest;
	}
	public abstract double oblicz();
	public abstract String opis();
}

abstract class Operator1arg extends Wyrazenie{
	protected Wyrazenie w1;
	protected Operator1arg(Wyrazenie _w1){
		this.w1=_w1;
	}
}

abstract class Operator2arg extends Operator1arg{
	protected Wyrazenie w2;
	protected Operator2arg(Wyrazenie _w1, Wyrazenie _w2){
		super(_w1);
		this.w2=_w2;
	}
}

abstract class Stala extends Wyrazenie{
	protected Stala(double g) {
		this.wart=g;
	}
	protected double wart;
}
