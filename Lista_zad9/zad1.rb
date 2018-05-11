#//////////////////////////////
#//  Programowanie Obiektowe //
#//  Maciej Tomasz Dudek     //
#//  Nr. indeksu 299168      //
#//  Pracownia 9             //
#//  Zadanie 1-Funkcja 1arg  //
#//////////////////////////////
class Funkcja
  @fun
  @@e =0.000000000001
  @@krok = 0.001
  @@krok_c = 0.000001
  @@zero = 0.000001
  
  class Pair
    def initialize(a,b)
      @first = a
      @second = b
    end
    def first()
      @first
    end
    def second()
      @second
    end
  end
  
  def initialize(f)
    if f.respond_to?("call")
      @fun = f
    else
      raise "Oczekiwano funkcji"
    end
  end
  
  #wartość funkcji w punkcie x 
  def value(x)
    @fun.call(x)
  end
  
  #pochodna funkcji w punkcie x 
  def poch(x)
    (self.value(x+@@e) - self.value(x)) / @@e
  end 
  
  #pole pod wykresem funkcji od a do b
  def pole (a,b)
    odp = 0
    
	while a < b
      t = a + @@krok_c
      if t > b
        t = b;
      end
      h = self.value(a) + self.value(t)
      h /= 2
      odp += h * (t-a)
      a += @@krok_c
    end 
    
	odp
  end
  
  #miejsca zerowe funkcji na przedziale od a do b z dokładnością e
  def zerowe (a,b,e)
    t = Array.new()
    odp = Array.new()
    
	while a < b
      t1 = a + @@krok
      if t1 > b
        t1 = b
      end
      if self.value(a) == 0
        odp.push(a)
        a += (1/10) * @@krok
      end
      if self.value(a) * self.value(t1) < 0
        t.push(Pair.new(a,t1))
      elsif self.poch(a) * self.poch(t1) <0
        t.push(Pair.new(a,t1))
      end
      a += @@krok
    end
	
    0.upto(t.size-1) do |x|
      p = t[x].first
      k = t[x].second
      
	  while p + e < k
        s = (p+k) / 2
        if self.value(p) * self.value(k) < 0
          if self.value(p) * self.value(s) < 0
            k = s
          else
            p = s
          end
        else
          if self.poch(p) * self.poch(s) < 0
            k = s
          else
            p = s
          end
        end
      end
      
	  if self.value(p) * self.value(k) < 0
        odp.push(p)
      elsif self.value(p) < @@zero
        odp.push(p)
      elsif self.value(k) < @@zero
        odp.push(k)
      end
    end
    
	if odp.size == 0
      nil
    else
      odp
    end
  end
end
