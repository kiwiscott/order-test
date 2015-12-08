import datetime
import functools

line = type('line', (object,), {})
linemask = type('linemask', (object,), {})

class orderparser(): 
  def __init__(self,formatmask):
    self.lineparser = lineparser(formatmask);

  def ordertotal(self,lines):
    def linetotal(l):
        x = self.lineparser.parseline(l)
        return x.quantity * x.price
          
    lineprices = map(linetotal,lines)
    total = functools.reduce(lambda x,y: x+y, lineprices,0) 
    return total

class lineparser():
  def __init__(self,formatmask):
    self.lineMask = linemask();
    self.lineMask.line = [formatmask.index('N'), formatmask.rfind('N')+1] 
    self.lineMask.code = [formatmask.index('P'), formatmask.rfind('P')+1]
    self.lineMask.category = [formatmask.index('C'), formatmask.rfind('C')+1] 
    self.lineMask.quantity = [formatmask.index('Q'), formatmask.rfind('Q')+1]
    self.lineMask.price = [formatmask.index('M'), formatmask.rfind('M')+1]
  
  def parseline(self,linedetails):  
    l = line(); 
    l.lineno = int(linedetails[ self.lineMask.line[0] : self.lineMask.line[1] ])
    l.code = (linedetails[ self.lineMask.code[0] : self.lineMask.code[1] ]).lstrip(' ')
    l.category = (linedetails[ self.lineMask.category[0] : self.lineMask.category[1] ]).lstrip(' ')
    l.quantity = int(linedetails[ self.lineMask.quantity[0] : self.lineMask.quantity[1] ])
    priceValue = linedetails[ self.lineMask.price[0] : self.lineMask.price[1] ]
    l.price = float(priceValue[0:-2] +'.'+ priceValue[-2:])   
    return l;