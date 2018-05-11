// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L6, z5 Merge_sort
// 2018-04-19
package Merge_sort;

public class Merge_sort extends Thread {
	int[] arr;
	int l,r;
	public int[] ret;
	public Merge_sort(int[] arrt,int lt,int rt) {
		arr=arrt;
		l=lt;
		r=rt;
		ret=null;
	}
	public void run() {
		ret=new int[r-l];
		if(r-l==1) {
			ret[0]=arr[l];
			return;
		}
		int d=(r+l)/2;
		Merge_sort 	m1=new Merge_sort(arr,l,d),
					m2=new Merge_sort(arr,d,r);
		m1.start();
		m2.start();
		try {
			m1.join();
			m2.join();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		
		int i=0,j=0,l1=0;
		while(i<m1.ret.length&&j<m2.ret.length) {
			if(m1.ret[i]<m2.ret[j]) {
				ret[l1]=m1.ret[i];
				i++;
			}
			else {
				ret[l1]=m2.ret[j];
				j++;
			}
			l1++;
		}
		while(i<m1.ret.length) {
			ret[l1]=m1.ret[i];
			i++;
			l1++;
		}
		while(j<m2.ret.length) {
			ret[l1]=m2.ret[j];
			j++;
			l1++;
		}
	}
}
