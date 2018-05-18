#/////////////////////////////////
#//  Programowanie Obiektowe    //
#//  Maciej Tomasz Dudek        //
#//  Nr. indeksu 299168         //
#//  Pracownia 10               //
#//  Zadanie 1-Kolekcje i sort  //
#/////////////////////////////////
class Kolekcja

  @inner

  def initialize()
    @inner=Array.new()
  end

  # operacja zamiany elementów
  def swap(i,j)
    temp=@inner[i]
    @inner[i]=@inner[j]
    @inner[j]=temp
  end

  # pobierz i-ty element
  def get(i)
    @inner[i]
  end
  
  # rozmiar kolekcji
  def length()
    @inner.length
  end
  
  # dodanie elementu
  def add(i)
    i.respond_to?("<=>")
    @inner.push(i)
  end
  
  # usuniecie ostatniego elementu
  def delete_last()
    @inner.pop()
  end

  # usuniecie i-tego elementu
  def delete(i)
    self.swap(i,self.length-1)
    @inner.pop()
  end

end 

class Sortowanie

  @kolekcja_to_sort

  # jest kolekcja?
  def kolekcja?(i)
    i.respond_to?("swap") && \
    i.respond_to?("length") && \
    i.respond_to?("get")
  end
  
  # sortowanie quick-sort implementacja
  # p-poczatek sortowanego przedzialu
  # k-koniec sortowanego przedzialu
  def quick_sort(p,k)
    unless k-p==0
      pivot_pos=p
      (p+1).upto(k) do |x|
        if @kolekcja_to_sort.get(pivot_pos) > @kolekcja_to_sort.get(x)
          x.downto(pivot_pos+1) do |y|
            @kolekcja_to_sort.swap(y,y-1)
          end
          pivot_pos+=1
        end
      end
      if(pivot_pos>p)
        quick_sort(p,pivot_pos-1)
      end
      if(pivot_pos<k)
        quick_sort(pivot_pos+1,k)
      end
    end
  end
  
  # sortowanie bouble-sort implementacja
  # p-poczatek sortowanego przedzialu
  # k-koniec sortowanego przedzialu
  def bouble_sort(p,k)
    posortowane=false
    while not posortowane
      posortowane=true
      0.upto(@kolekcja_to_sort.length-2) do |x|
        if @kolekcja_to_sort.get(x) > @kolekcja_to_sort.get(x+1)
          @kolekcja_to_sort.swap(x,x+1)
          posortowane=false
        end
      end
    end
  end
  
  # sortowanie quick-sort
  def sort1(i)
    if self.kolekcja?(i)
      @kolekcja_to_sort=i
      self.quick_sort(0,i.length-1)
      @kolekcja_to_sort
    else
      print "Nie jest kolekcja!!"
    end
  end

  # sortowanie bombelkowe
  def sort2(i)
    if self.kolekcja?(i)
      @kolekcja_to_sort=i
      self.bouble_sort(0,i.length-1)
      @kolekcja_to_sort
    else
      print "Nie jest kolekcja!!"
    end
  end

end 
  
r =Random.new()
a=Array.new()

k1=Kolekcja.new()
k2=Kolekcja.new()

s=Sortowanie.new()

0.upto(10000) do |x|
  temp=r.rand(100000)
  a.push(temp)
  k1.add(temp)
  k2.add(temp)
end

require 'benchmark'

Benchmark.bm(7) do |x|
  x.report("quick:")  {s.sort1(k1)}
  x.report("boulbe:") {s.sort2(k2)}
end
