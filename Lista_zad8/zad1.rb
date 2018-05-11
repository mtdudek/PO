class Fixnum
  @@slowaspecjalne = {
      0 => "zero", 1 => "jeden", 2 => "dwa", 3 => "trzy", 4 => "cztery",
      5 => "piec", 6 => "szesc", 7 => "siedem", 8 => "osiem", 9 => "dziwiec",
      10 => "dziesiec", 11 => "jedynascie", 12 => "dwanascie",
      13 => "trzynacie", 14 => "czternacie", 15 => "pietnascie",
      16 => "szesnacie", 17 => "siedemnascie", 18 => "osiemnascie",
      19 => "dziewietnascie", 20 => "dwadziescia", 30 => "trzydziesci",
      40 => "czterdziesci", 50 => "piecdziesiat", 60 => "szescdziesiat",
      70 => "sidemdziesiat", 80 => "osiemdziesiat", 90 => "dziewiecdziesiat",
      100 => "sto", 200 => "dwiescie", 300 => "sta", 500 => "set",
      1000 => "tysiac", 2000 => "tysiace", 5000=> "tysiecy",
      1000000 => "milion", 2000000 => "miliony", 5000000 => "milionow",
      1000000000 => "miliard", 2000000000 => "miliardy", 5000000000 => "miliardow"}
  def czynniki
    arry1=Array.new()
    1.upto(self) do |x|
      if self%x==0
        arry1.push(x)
      end
    end
    arry1
  end
  def ack(m)
    if self == 0
      m+1
    elsif m==0
      (self -1).ack(1)
    else
      (self -1).ack(self.ack(m-1))
    end 
  end
  def doskonala
    dzi=Array.new()
    dzi=self.czynniki
    dzi.pop
    i=0
    dzi.each{|x| i+=x}
    i == self
  end
  def slownie
    if (self >= 1000000000000)
      print "Poza zakresem\n"
    elsif self==0
      print @@slowaspecjalne[self]
    else
	  x=self
      if x<0
        print "minus "
        x*=-1
      end
       e=1000000000
      while x>0
        t=x/e
        while t==0
          e/=1000
          t=x/e
        end
        x-=t*e
        o=String.new()
        se=t/100
        t-=se*100
        dz=t/10
        t-=dz*10
        if se>0
          if se==1
            o.concat(@@slowaspecjalne[100]+" ")
          elsif se==2
            o.concat(@@slowaspecjalne[200]+" ")
          elsif se>4
            o.concat(@@slowaspecjalne[se])
            o.concat(@@slowaspecjalne[500]+" ")
          else
            o.concat(@@slowaspecjalne[se])
            o.concat(@@slowaspecjalne[300]+" ")
          end
        end
        if dz>0
          if dz==1
            o.concat(@@slowaspecjalne[dz*10+t]+" ")
            t=0
          else
            o.concat(@@slowaspecjalne[dz*10]+" ")
          end
        end
        if t>0
          o.concat(@@slowaspecjalne[t]+" ")
        end
        if (se>0||dz>0||t>4)&&e>1 
          o.concat(@@slowaspecjalne[5*e]+" ")
        elsif t==1 && e>1
          o.concat(@@slowaspecjalne[e]+" ")
        elsif e>1
          o.concat(@@slowaspecjalne[2*e]+" ")
        end
        print o
      end
    end
  end
end
