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

public class EdycjaTramwaju extends JComponent{
    private Tramwaj tram;
    protected JFrame frame;
    protected Container kontener;
    protected GridLayout layout;
    protected JLabel maksPredkosc_etykieta;
    protected JTextField maksPredkosc_pole;
    protected JLabel zasilanie_etykieta;
    protected JTextField zasilanie_pole;
    protected JLabel liczbaPasazerow_etykieta;
    protected JTextField liczbaPasazerow_pole;
    private JTextField numerLinii_pole;
    private JLabel numerLinii_etykieta;
    private JTextField iloscWagonow_pole;
    private JLabel iloscWagonow_etykieta;
    public EdycjaTramwaju(Tramwaj tram) {
    	this.tram = tram;
    }
    public void edycja(String sciezka,JFrame f1){
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
        maksPredkosc_etykieta = new JLabel("Predkosc Maksymalna[km/h]");
        kontener.add(maksPredkosc_etykieta);
        maksPredkosc_pole = new JTextField( "" + tram.getMaksPredkosc() ,40);
        kontener.add(maksPredkosc_pole);
        zasilanie_etykieta = new JLabel("Rodzaj zasilania");
        kontener.add(zasilanie_etykieta);
        zasilanie_pole = new JTextField( "" + tram.getRodzajZasilania() ,40);
        kontener.add(zasilanie_pole);
        liczbaPasazerow_etykieta = new JLabel("Liczba Pasazerow");
        kontener.add(liczbaPasazerow_etykieta);
        liczbaPasazerow_pole = new JTextField( "" + tram.getliczbaPasazerow() ,40);
        kontener.add(liczbaPasazerow_pole);
        iloscWagonow_etykieta = new JLabel("Ilosc Wagonow");
        kontener.add(iloscWagonow_etykieta);
        iloscWagonow_pole = new JTextField( "" + tram.getIloscWagonow() ,40);
        kontener.add(iloscWagonow_pole);
        numerLinii_etykieta = new JLabel("Numer Linii");
        kontener.add(numerLinii_etykieta);
        numerLinii_pole = new JTextField( "" + tram.getNumerLinii() ,40);
        kontener.add(numerLinii_pole);
        JButton zastosuj = new JButton("zastosuj");

        //Akcja guzika zastosuj
        //Zastosuj - ustawia pola kalsy
        zastosuj.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                tram.setNumerLinii(numerLinii_pole.getText());
                tram.setLiczbaPasazerow (Integer.parseInt(liczbaPasazerow_pole.getText()));
                tram.setIloscWagonow ( Integer.parseInt(iloscWagonow_pole.getText()));
                tram.setRodzajZasilania (zasilanie_pole.getText());
                tram.setMaksPredkosc (Integer.parseInt(maksPredkosc_pole.getText()));
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

    public void serializacja (String sciezka)  throws IOException {
        ObjectOutputStream output = new ObjectOutputStream( new BufferedOutputStream( new FileOutputStream(sciezka)));
        output.reset();
        output.writeObject(tram);
        output.close();

    }
}
