// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L6, z3 Bufor
// 2018-04-19
package Bufor;

public class Bufor <T>{
	int s,point1,point2;
	Object[] buf;
	public Bufor() {
		s=0;
		buf=null;
	}
	public Bufor(int _size) {
		s=_size;
		buf=new Object[s];
		for (int i=0;i<s;i++)
			buf[i]=null;
		point1=0;
		point2=-1;
	}
	//Usuń z bufora
	public synchronized T pop() throws InterruptedException {
		point2++;
		if(point2==s)
			point2=0;
		while(buf[point2]==null)
			wait();
		T ret=(T)buf[point2];
		buf[point2]=null;
		notify();
		return ret;
	}
	//Dodaj do bufora
	public synchronized void put(T element) throws InterruptedException {
		while(buf[point1]!=null)
			wait();
		buf[point1]=element;
		point1++;
		if(point1==s)
			point1=0;
		notify();
	}
}
