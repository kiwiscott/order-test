import pytest
import orderprocessor

lines = [
        ['NPPPPPPPCQQQMMMM','1P123456X9991010',1,'P123456','X', 999, 10.10],
        ['NNNNPPPPPPPPPPCCCCCCCCCCQQQQQMMMMMMMMMM','   1   P123456  SPORTING    9      1000',1,'P123456','SPORTING', 9, 10.00],
        ['NNNNPPPPPPPPPPCCCCCCCCCCQQQQQMMMMMMMMMM','   2   P999456    DRINKS   89        30',2,'P999456','DRINKS', 89, 0.30],
        ['PPPPPPP|CCCCCC|QQQ|MMMM|NNN','P999999| SPORT|545|2222|002',2,'P999999','SPORT', 545, 22.22],
        ['~~~PPPPPPP~~~CCCCCC~~~QQQ~~~MMMM~~~NNN~~~','~~~P899999~~~ ADESO~~~454~~~5566~~~321~~~',321,'P899999','ADESO', 454, 55.66]
      ];
      
@pytest.mark.parametrize("lineMask,line,lineno,code,category,quantity,price", lines)
def test_line_parse(lineMask,line,lineno, code,category,quantity,price):
    r = orderprocessor.lineparser(lineMask);
    l = r.parseline(line)
    assert l.lineno == lineno
    assert l.code == code
    assert l.category == category
    assert l.quantity == quantity
    assert l.price == price      
    
orders = [
        ['N,PPPPPPP,C,QQQ,MMMM',5,'1,P123455,X,002, 200 \n 2,P123456,A,001, 100'],
        ['N,PPPPPPP,C,QQQ,MMMM',(999*99.39) + (454*11.00),'1,P123455,X,999,9939 \n 2,P123456,A,454,1100'] 
      ];

@pytest.mark.parametrize("linemask,expectedTotal,lines", orders)
def test_order_total(linemask,expectedTotal,lines):
    r = orderprocessor.orderparser(linemask)
    lieslist = lines.split(' \n ')
    assert r.ordertotal(lieslist) == expectedTotal

