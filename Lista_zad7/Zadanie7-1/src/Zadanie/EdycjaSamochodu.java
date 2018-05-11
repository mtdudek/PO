// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L7 
// 2018-04-26
package Zadanie;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.io.*;

public class EdycjaSamochodu extends JComponent{
    private Samochod car;
    protected JFrame frame;
    protected Container kontener;
    protected GridLayout layout;
    protected JLabel maksPredkosc_etykieta;
    protected JTextField maksPredkosc_pole;
    protected JLabel zasilanie_etykieta;
    protected JTextField zasilanie_pole;
    protected JLabel liczbaPasazerow_etykieta;
    protected JTextField liczbaPasazerow_pole;
    protected JLabel marka_etykieta;
    protected JTextField marka_pole;
    protected JLabel liczbaDrzwi_etykieta;
    protected JTextField liczbaDrzwi_pole;
    public EdycjaSamochodu(Samochod c) {
        car = c;
    }
    public void edycja(String sciezka,JFrame f1) {
        frame = new JFrame("Edycja Pojazdu");
    	WindowListener exitListener = new WindowAdapter() {
    	    @Override
    	    public void windowClosing(WindowEvent e) {
    	    	if(f1!=null)
    	    		f1.setVisible(true);
    	    }
    	};
    	frame.addWindowListener(exitListener);
        frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        kontener = frame.getContentPane();
        layout = new GridLayout(6,2);
        kontener.setLayout(layout);
        marka_etykieta = new JLabel("Marka");
        kontener.add(marka_etykieta);
        marka_pole = new JTextField(car.getMarka());
        kontener.add(marka_pole);
        maksPredkosc_etykieta = new JLabel("Predkosc Maksymalna[km/h]");
        kontener.add(maksPredkosc_etykieta);
        maksPredkosc_pole = new JTextField( "" + car.getMaksPredkosc() ,40);
        kontener.add(maksPredkosc_pole);
        liczbaDrzwi_etykieta = new JLabel("Liczba Drzwi");
        kontener.add(liczbaDrzwi_etykieta);
        liczbaDrzwi_pole = new JTextField( "" + car.getLiczbaDrzwi() ,40);
        kontener.add(liczbaDrzwi_pole);
        zasilanie_etykieta = new JLabel("Rodzaj zasilania");
        kontener.add(zasilanie_etykieta);
        zasilanie_pole = new JTextField( "" + car.getRodzajZasilania() ,40);
        kontener.add(zasilanie_pole);
        liczbaPasazerow_etykieta = new JLabel("Liczba Pasazerow");
        kontener.add(liczbaPasazerow_etykieta);
        liczbaPasazerow_pole = new JTextField( "" + car.getliczbaPasazerow() ,40);
        kontener.add(liczbaPasazerow_pole);
        JButton zastosuj = new JButton("zastosuj");
        
        //Akcja guzika zastosuj
        //Zastosuj - ustawia pola kalsy
        zastosuj.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                car.setMarka(marka_pole.getText());
                car.setLiczbaPasazerow(Integer.parseInt(liczbaPasazerow_pole.getText()));
                car.setLiczbaDrzwi( Integer.parseInt(liczbaDrzwi_pole.getText()));
                car.setRodzajZasilania ( zasilanie_pole.getText());
                car.setMaksPredkosc (Integer.parseInt(maksPredkosc_pole.getText()));
            }
        });
        kontener.add(zastosuj);
        JButton zapisz = new JButton("zapisz");
        
        //Akcja guzika zapisz
        //Zapisz - zapisuje ustawienia klasy
        zapisz.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    serializacja(sciezka);
                } catch (IOException e1) {
                    e1.printStackTrace();
                }
            }
        });
        kontener.add(zapisz);
		frame.setPreferredSize(new Dimension(400,300));
        frame.pack();
        frame.setVisible(true);
    }
    public void serializacja (String sciezka) throws IOException {
        ObjectOutputStream output = new ObjectOutputStream( new BufferedOutputStream( new FileOutputStream(sciezka)));
        output.reset();
        output.writeObject(car);
        output.close();
    }
}
