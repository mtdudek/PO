class Funkcja2
  @@krok_c = 0.0002

  def initialize(f)
    if f.respond_to?("call")
      @fun=f
      @tol_wys = 0.001
      @krok_poz = 0.001
    else
      raise "Oczekiwano funkcji"
    end
  end
  
  def value(x,y)
    @fun.call(x,y)
  end

  def objetosc(a,b,c,d)
    odp=0
    
	while a < b 
      t = a + @@krok_c
      if t > b
        t = b
      end
      x = c
      
	  while x < d
        t1 = x + @@krok_c
        if t1 > d
          t1 = d
        end
        odp += (t-a) * (t1-x) * self.value((a+t) / 2,(x+t1) / 2)
        x += @@krok_c
      end
      
	  a += @@krok_c
    end
    
	odp
  end

  def tol_wys=(tol)
    if tol.is_a?(Float)
      @tol_wys = tol
    else
      raise "Oczekiwano lliczby zmiennoprzecinkowej"
    end
  end

  def krok_poz=(krok)
    if krok.is_a?(Float)
      @krok_poz = krok
    else
      raise "Oczekiwano lliczby zmiennoprzecinkowej"
    end
  end

  def poziomica(a,b,c,d,wysokosc)
    odp=Array.new()
    a -= @krok_poz
    c -= @krok_poz
    
	while a < b
      t = a + @krok_poz
      if t > b
        t = b
      end
      x = c
      
	  while x < d
        t1 = x + @krok_poz
        if t1 > d
          t1 = d
        end
        if (self.value(t,t1) - wysokosc).abs < @tol_wys
          odp.push([t,t1])
        end
        x += @krok_poz
      end
      
	  a += @krok_poz
    end
    
	odp
  end
end
