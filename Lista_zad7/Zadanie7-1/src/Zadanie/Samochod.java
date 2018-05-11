// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L7 
// 2018-04-26
package Zadanie;
import java.io.*;

public class Samochod extends Pojazd implements Serializable{
    private int liczbaDrzwi;
    private String marka;
    public int getLiczbaDrzwi() { 
    	return liczbaDrzwi;
    }
    public String getMarka(){ 
    	return marka;
    }
    public void setLiczbaDrzwi(int a) { 
    	liczbaDrzwi=a;
    }
    public void setMarka(String a){ 
    	marka=a;
    }
    public Samochod(int maxsp, int iloscPas, String zasilanie, int drzwi, String marka) {
        super(maxsp, "Samochod", iloscPas, zasilanie);
        liczbaDrzwi = drzwi;
        this.marka = marka;

    }
    public Samochod () {
        super(200, "Samochod", 5, "benzyna");
        liczbaDrzwi = 5;
        marka = "ford";

    }
    @Override
    public String toString () {
        return typ + " marki: " + marka + "\n" + liczbaDrzwi + "-drzwiowy" + "\nmaksymalna prędkośc[km/h]: " + maksPredkosc + "\nilość pasażerów: " +
                liczbaPasazerow + "\nrodzaj zasilania: " + rodzajZasilania;
    }
}
