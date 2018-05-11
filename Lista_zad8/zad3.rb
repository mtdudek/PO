#//////////////////////////////
#//  Programowanie Obiektowe //
#//  Maciej Tomasz Dudek     //
#//  Nr. indeksu 299168      //
#//  Pracownia 8             //
#//  Zadanie 3-Szyfrowanie   //
#//////////////////////////////
class Jawna
 def initialize(tekst)
  @tekst=tekst
  @roz = tekst.size
 end
 
 def zaszyfruj(kod)
  r =Random.new(kod)
  arry1=Array.new()
  arry2=Array.new()
  (' '..'~').each{
	  |x|
	  arry1.push(x)
	  arry2.push(x)
  }
  arry2=arry2.shuffle(random: r)
  slow= Hash.new()
  0.upto(arry1.size) do |x|
    slow[arry1[x]]=arry2[x]
  end
  tekst_u=String.new()
  0.upto(@roz -1 ) do |x|
   tekst_u << slow[@tekst[x]]
  end
  Zaszyfrowane.new(tekst_u)
 end
 
 def tekst()
  print @tekst
 end
end

class Zaszyfrowane
 def initialize(tekst)
  @tekst=tekst
  @roz = tekst.size
 end
 
 def odszyfruj(kod)
  r =Random.new(kod)
  arry1=Array.new()
  arry2=Array.new()
  (' '..'~').each{
	  |x|
	  arry1.push(x)
	  arry2.push(x)
  }
  arry2=arry2.shuffle(random: r)
  slow= Hash.new()
  0.upto(arry1.size) do |x|
    slow[arry2[x]]=arry1[x]
  end
  tekst_j = String.new()
  0.upto(@roz - 1) do |x|
    tekst_j<<slow[@tekst[x]]
  end
  Jawna.new(tekst_j)
 end
 
 def tekst()
  print @tekst
 end
end
