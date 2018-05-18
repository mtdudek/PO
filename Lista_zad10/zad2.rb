#/////////////////////////////////
#//  Programowanie Obiektowe    //
#//  Maciej Tomasz Dudek        //
#//  Nr. indeksu 299168         //
#//  Pracownia 10               //
#//  Zadanie 2-Kolekcje  i      //
#//  wyszukiwanie binarne       //
#/////////////////////////////////

class Kolekcja

  #konstruktor
  def initialize
    @inner=Array.new()
    @w = Wyszukiwanie.new()
  end

  #dodaj element
  def add(i)
    if i.respond_to?("<=>")
      pos = @w.upper_bound(i,self)
      @inner.insert(pos,i)
    else
      print "Nie porownuje sie!!!"
    end
  end
  
  #zamienia elementy na pozycji i-tej i j-tej
  def swap(i,j)
    temp = @inner[i]
    @inner[i] = @inner[j]
    @inner[j] = temp
  end
  
  #podglada element na i-tej pozycji
  def get(i)
    @inner[i]
  end
  
  #podglada pierwszy element
  def front()
    @inner[0]
  end
  
  #podglada ostatni element
  def back
    @inner[-1]
  end
  
  #usun element z poczatku
  def pop_front()
    if length > 0
      @inner.delete_at(0)
    else
      raise "Pusta kolekcja"
    end
  end

  #usun element z konca
  def pop_back()
    if length > 0
      @inner.pop()
    else
      raise "Pusta kolekcja" 
    end
  end
  
  #rozmiar
  def length()
    @inner.length
  end

end

class Wyszukiwanie

  #wyszukiwanie binarne
  #zwraca pozycje pierwszego 
  #niemniejszego elementu od 'i' w 'k'
  #lub koniec kolekcji
  #'i' - szukany element
  #'k' - kolekcja posortowana
  def lower_bound_bi(i,k)
    def inner_op(pocz,kon,i,k)
      sr=(pocz + kon) / 2
      if kon - pocz < 2 || \
         k.get(pocz) == i
        pocz
      end
      if k.get(sr) == i
        sr
      elsif k.get(sr) < i
        inner_op(sr,kon,i,k)
      else
        inner_op(pocz,sr,i,k)
      end
    end
    inner_op(0,k.length,i,k)
  end
  
  #wyszukiwanie binarne
  #zwraca pozycje pierwszego 
  #wiekszego elementu od 'i' w 'k'
  #lub koniec kolekcji
  #'i' - szukany element
  #'k' - kolekcja posortowana
  def upper_bound(i,k)
    def inner_op(pocz,kon,i,k)
      sr=(pocz + kon) / 2
      if kon == pocz
        pocz
      elsif kon - pocz == 1
        if k.get(pocz) <= i
          kon
        else
          pocz
        end
      elsif k.get(sr) <= i
        inner_op(sr,kon,i,k)
      else
        inner_op(pocz,sr,i,k)
      end
    end
    inner_op(0,k.length,i,k)
  end
  
  #wyszukiwanie interpolacyjne
  #zwraca pozycje pierwszego 
  #niemniejszego elementu od 'i' w 'k'
  #lub koniec kolekcji
  #'i' - szukany element
  #'k' - kolekcja posortowana
  def lower_bound_inter(i,k)
    def inner_op(pocz,kon,i,k)
      sr=pocz + ((i-k.get[pocz]) * (kon-pocz))/\
         (k.get(kon) - k.get(pocz))
      if kon - pocz < 2 || \
         k.get(pocz) == i
        pocz
      end
      if k.get(sr) == i
        sr
      elsif k.get(sr) < i
        inner_op(sr,kon,i,k)
      else
        inner_op(pocz,sr,i,k)
      end
    end
    inner_op(0,k.length-1,i,k)
  end
  
  #sprawdza czy 'i' jest kolekcja
  def kolekcja?(i)
    i.respond_to?("swap") && \
    i.respond_to?("length") && \
    i.respond_to?("get")
  end
  
  #sprawdza czy 'i' jest posortowane
  def sorted_kolekcja?(i)
    if kolekcja?(i)
      sorted=true
      1.upto(i.length-1) do |x|
        sorted = sorted &&\
                 i.get(x-1) < i.get(i)
      end
      sorted
    else
      false
    end
  end

end

k= Kolekcja.new()
k.add(1)
k.add(0)
k.add(-1)
k.add(13)
k.add(8)
k.add(8)
k.add(9)
print "\n"
print k.front,"\n"
print k.back,"\n"
