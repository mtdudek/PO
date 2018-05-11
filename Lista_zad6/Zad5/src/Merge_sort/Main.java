// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L6, z5 Merge_sort
// 2018-04-19
package Merge_sort;

public class Main {
	static void test(Integer h) {
		h++;
	}
	static void test(int h) {
		h++;
	}
	public static void main(String[] args) {
		int[] tosort= {10 ,2,99,3, 1,-100};
		Merge_sort m=new Merge_sort(tosort,0,tosort.length);
		m.start();
		try {
			m.join();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		tosort=m.ret;
		for (int i=0;i<tosort.length;i++)
			System.out.println(tosort[i]);
	}
}
