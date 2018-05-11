// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L7 
// 2018-04-26
package Zadanie;

import java.awt.Container;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;

import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.filechooser.FileNameExtensionFilter;

public class BezArgumentów {
	private JFrame frame;
	private Container kontener;
	private GridLayout wyglad;
	private JFileChooser choosefile;
    private FileNameExtensionFilter filter1, filter2;
    private JButton Czytaj,No_sam,No_tra;
    private JLabel co;
    private JTextField nazwa;
	public BezArgumentów(){
		frame=new JFrame("Menu");
		frame.setVisible(false);
		frame.setPreferredSize(new Dimension(300,200));
		kontener=frame.getContentPane();
		wyglad=new GridLayout(5,1);
		kontener.setLayout(wyglad);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		choosefile = new JFileChooser("C:\\Users\\Maciej\\Desktop\\PO\\Lista_zad7\\Zadanie7-1");
		filter1 = new FileNameExtensionFilter(
	            "Samocjody", "car");
		filter2 = new FileNameExtensionFilter(
	        	"Tramwaj", "tram");
		choosefile.setAcceptAllFileFilterUsed(false);
	    choosefile.addChoosableFileFilter(filter1);
	    choosefile.addChoosableFileFilter(filter2);
	    Czytaj = new JButton("Czytaj plik");
	    co=new JLabel("Nazwa nowego pojazdu");
	    nazwa=new JTextField("",40);
	    No_sam = new JButton("Nowy samochód");
	    No_tra= new JButton("Nowy tramwaj");
	    kontener.add(Czytaj);
	    kontener.add(co);
	    kontener.add(nazwa);
	    kontener.add(No_sam);
	    kontener.add(No_tra);
	    
	    //Akcja czytania pliku
	    Czytaj.addActionListener(new ActionListener() {
	        @Override
	        public void actionPerformed(ActionEvent e) {
	            frame.setVisible(false);
	            int returnVal = choosefile.showOpenDialog(frame);
	            if(returnVal == JFileChooser.APPROVE_OPTION) {
	            	String path;
	            	path=choosefile.getSelectedFile().getAbsolutePath();
	        		try {
						Program.deserializacja(path,frame);
					} catch (ClassNotFoundException e1) {
						e1.printStackTrace();
					} catch (IOException e1) {
						e1.printStackTrace();
					}
	            }
	            else
	            	frame.setVisible(true);
	        }
	    });
	    
	    //Akcja tworzenia nowego samochodu
	    No_sam.addActionListener(new ActionListener() {
	        @Override
	        public void actionPerformed(ActionEvent e) {
	            frame.setVisible(false);
	        	Samochod car=new Samochod();
	        	EdycjaSamochodu edycja= new EdycjaSamochodu(car);
	        	String path=nazwa.getText();
	        	nazwa.setText("");
	        	path+=".car";
	            File file = new File(path);
	            edycja.edycja(path,frame);
	        }
	    });
	    
	    //Akcja tworzenia noego tramwaju
	    No_tra.addActionListener(new ActionListener() {
	        @Override
	        public void actionPerformed(ActionEvent e) {
	            frame.setVisible(false);
	        	Tramwaj tram=new Tramwaj();
	        	EdycjaTramwaju edycja= new EdycjaTramwaju(tram);
	        	String path=nazwa.getText();
	        	nazwa.setText("");
	        	path+=".tram";
	            File file = new File(path);
	            edycja.edycja(path,frame);
	        }
	    });
	    frame.pack();
        frame.setVisible(true);
	}
}
