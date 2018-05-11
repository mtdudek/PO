// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L7 
// 2018-04-26
package Zadanie;
import java.io.*;
import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Program {
	
	static String getFileExtension(File file) {
	    String name = file.getName();
	    try {
	        return name.substring(name.lastIndexOf(".") + 1);
	    } catch (Exception e) {
	        return "";
	    }
	}
	
    public static void main(String[] args) throws IOException, ClassNotFoundException {
    	String path="";
    	
        if (args.length == 0) {
        	BezArgumentów g =new BezArgumentów();
        }
        else if(args.length>0)
        	path=args[0];
        File file = new File(path);
        String ex=getFileExtension(file);
        if (file.isFile()) {
        	if(ex.compareTo("car")==0||ex.compareTo("tram")==0)
        		deserializacja(path,null);
        	else {
        		System.out.println("ZŁA ŚCIERZKA!!!");
        	}
        }
        else if(args.length>1&&args[1].compareTo("Samochod")==0&&ex.compareTo("tram")!=0) {
        	Samochod car = new Samochod();
            EdycjaSamochodu edycja = new EdycjaSamochodu(car);
            if (ex.compareTo("car")!=0)
            	path+=".car";
            edycja.edycja(path,null);
        }
        else if (args.length>1&&args[1].compareTo("Tramwaj")==0&&ex.compareTo("car")!=0) {
        	Tramwaj tram = new Tramwaj();
        	EdycjaTramwaju edycja = new EdycjaTramwaju(tram);
            if (ex.compareTo("tram")!=0)
            	path+=".tram";
        	edycja.edycja(path,null);
        }
    }

    public static void deserializacja(String path,JFrame f1) throws IOException, 
    																ClassNotFoundException {
        File file = new File(path);
        String ex=getFileExtension(file);
        ObjectInputStream input = new ObjectInputStream( 
        						new BufferedInputStream( new FileInputStream(path)));
        if(ex.compareTo("car")==0) {
            Samochod car = (Samochod)input.readObject();
            EdycjaSamochodu edycja = new EdycjaSamochodu(car);
            edycja.edycja(path,f1);
        }
        else {
            Tramwaj tram = (Tramwaj)input.readObject();
            EdycjaTramwaju edycja = new EdycjaTramwaju(tram);
            edycja.edycja(path,f1);
        }
        input.close();
    }
}
