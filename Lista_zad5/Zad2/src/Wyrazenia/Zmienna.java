// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z2 Wyrazenia
// 2018-04-12
package Wyrazenia;

import java.util.HashMap;
import java.util.Map;

public class Zmienna extends Wyrazenie{
	private String name;
	private static final Map<String,Double> srodowisko;
	static {
		srodowisko=new HashMap<String,Double>();
	}
	public static void dodajZmienna(String h) {
		srodowisko.put(h, 0.0);
	}
	public static void dodajZmiennaZWartoscia(String h,double t) {
		srodowisko.put(h, t);
	}
	public static void zmienWartoscZmiennej(String h,double t) {
		srodowisko.replace(h, t);
	}
	public static double wartoscZSrodowiska(String h) {
		return srodowisko.get(h);
	}
	public static boolean czyJestWSrodowisku(String h) {
		return srodowisko.containsKey(h);
	}
	public Zmienna(String h){
		this.name=new String(h);
	}
	@Override
	public double oblicz() {
		return Zmienna.wartoscZSrodowiska(name);
	}
	@Override
	public String opis() {
		return name;
	}
}