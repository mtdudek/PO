// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L6, z3 Bufor
// 2018-04-19
package Bufor;
import java.security.SecureRandom;

public class Main {
	static Bufor bufer;
	public static void main(String[] args) {
		bufer=new Bufor<String>(8);
		Thread a,b;
		a=new Producer(bufer);
		b=new Consumer(bufer);
		a.start();
		b.start();
	}
}

//Prodecent
class Producer extends Thread{
	Bufor<String> t;
	Producer(Bufor<String> g){
		t=g;
	}
	public void run() {
		SecureRandom g=new SecureRandom();
		for (int i=0;i<10000;i++) {
			String h=String_gen.randomString( g.nextInt(15) );
			try {
				t.put(h);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
}

//Generator ciągów losowych znaków
class String_gen{
	static final String AB = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
	static SecureRandom rnd = new SecureRandom();
	
	public static String randomString( int len ){
	   StringBuilder sb = new StringBuilder( len );
	   for( int i = 0; i < len; i++ ) 
	      sb.append( AB.charAt( rnd.nextInt(AB.length()) ) );
	   return sb.toString();
	}
}

//Konsumer
class Consumer extends Thread{
	Bufor<String> t;
	Consumer(Bufor<String> g){
		t=g;
	}
	public void run() {
		for (int i=0;i<10000;i++) {
			String h=null;
			try {
				h=t.pop();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			System.out.println(h);
		}
	}
}