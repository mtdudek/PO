// Maciej Dudek
// Pracownia PO, czwartek, s.108
// L5, z1 Kolejka i Hierarchia
// 2018-04-12
package Kolejka;

//Klasa implementująca kolejkę

public class Kolejka<T extends Comparable<T>> {
	private int rozmiar_max,rozmiar_act;
	private Object[] kolejka_array; 
	public Kolejka(){
		rozmiar_max=1;
		rozmiar_act=0;
		kolejka_array= new Object[rozmiar_max];
	}
	//Dodawanie elementów typu T do kolejki
	public void push(T a) {
		if(rozmiar_act==rozmiar_max-1) {
			rozmiar_max*=2;
			Object[] kolejka_tmp=kolejka_array;
			kolejka_array= new Object[rozmiar_max];
			for (int i=0;i<rozmiar_max/2;i++)
				kolejka_array[i]=kolejka_tmp[i];
		}
		rozmiar_act++;
		kolejka_array[rozmiar_act]=a;
		for (int i=rozmiar_act;i>1;i/=2) {
			if(((T)kolejka_array[i/2]).compareTo((T)kolejka_array[i])>0) {
				T tem=(T)kolejka_array[i/2];
				kolejka_array[i/2]=kolejka_array[i];
				kolejka_array[i]=tem;
			}
		}
	}
	
	//Pobieranie pierwszego elementu z kolejki i usunięcie z kolejki
	public T pop() throws EmptyStackExeption{
		if(rozmiar_act<1)
			throw new EmptyStackExeption();
		T odp=(T)kolejka_array[1];
		kolejka_array[1]=kolejka_array[rozmiar_act];
		for (int i=1;i<rozmiar_act;) {
			if(i*2+1<rozmiar_act) {
				if(((T)kolejka_array[i*2]).compareTo((T)kolejka_array[i*2+1])<0) {
					if(((T)kolejka_array[i*2]).compareTo((T)kolejka_array[i])<0) {
						T tem =(T)kolejka_array[i];
						kolejka_array[i]=kolejka_array[i*2];
						kolejka_array[i*2]=tem;
						i*=2;
					}else
						break;
				}else {
					if(((T)kolejka_array[i*2+1]).compareTo((T)kolejka_array[i])<0) {
						T tem =(T)kolejka_array[i];
						kolejka_array[i]=kolejka_array[i*2+1];
						kolejka_array[i*2+1]=tem;
						i=i*2+1;
					}else
						break;
					
				}
			}else if(i*2<rozmiar_act) {
				if(((T)kolejka_array[i*2]).compareTo((T)kolejka_array[i])<0) {
					T tem =(T)kolejka_array[i];
					kolejka_array[i]=kolejka_array[i*2];
					kolejka_array[i*2]=tem;
					i*=2;
				}else
					break;
			}else
				break;
		}
		rozmiar_act--;
		return odp;
	}
	//Wypisuje wszystkie elementy z kolejki w kolejności
	public void print_all() throws EmptyStackExeption {
		Kolejka<T> tem=new Kolejka<T>();
		while(!this.empty()) {
			T out=this.pop();
			tem.push(out);
			System.out.print(out.toString() +" ");
		}
		while(!tem.empty()) {
			this.push(tem.pop());
		}
	}
	//Sprawdza czy pusty
	public boolean empty() {
		return rozmiar_act==0;
	}
}
