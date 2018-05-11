// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

public class Pi extends Stala{
	public Pi(double g){
		super(g);
	}
	@Override
	public double oblicz(){
		return wart;
	}
	@Override
	public String opis() {
		return "pi";
	}
}
