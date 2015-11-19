#Learning to TDD some classes
 
##Lets learn some basic TDD
While doing these excercises try and remember the basic TDD premise -> RED, GREEN, REFACTOR

###Part 3
Our system is in trouble we've taken on more ordersand foolishly customers sent us orders with pricing and we took there order totals as gospel.



We are getting better our boss, Gee Long, wants us to take on the next task. We need to take on more customers and start checking their ocers as they come into our system. We were foolishly letting customers send us orders without checking the pricing  

Each customer seems to want to have their own format and since we have big customers we don't want to lose we need to think of a way to support them. Here's a list of customer formats that we need to think about supporting. 

Your task is to extend your previous code to include the new requirements for parsing order lines.

####Boom Daddy
Our largest customer who spends $100,000 per month with us. Our sales guy, Sella Grandma, says if we can take electronic orders from the customer we will grow the sales base by 10% per month over the next year.  

Boom Daddy's format is:
>* The format of the line is fixed at 16 characters with the following fields
>* Single Digit Line Number
>* Seven Digit Product Code
>* Single Digit Category
>* Three Digit Quantity
>* Three Digit Quantity
>* Four Digit Price Float (note the last two digits represent cents)

Here's some sample line items 
>'1P123456X9991010'
>'2    456D 99  10'

####Seal Eye Lights
Our 36th largest customer who spends $10,000 per month with us. Our sales guy, Wail Hunta, thinks this is a quick win - we already have multiple customers on boards so this is a breeze  

_since a differnt sales person is giving us the requirements we are getting different requirement formats_

The format is:
>* The format of the line is fixed at 27 characters and they have a custom format like 'PPPPPPP|CCCCCC|QQQ|DDDD|NNN'
>* P is a placeholder for the product code
>* C is a placeholder for the product category
>* Q is a placeholder for the quantity
>* D is a placeholder for the price
>* N is a placeholder for the line number

Here's some sample line items 
>'P999999| SPORT|545|2222|002'

**Without committing to a future solution remeber that we may have 1000 plus customers! Can you make this code adaptable to future change**

[refactoring-adaptive-model](http://martinfowler.com/articles/refactoring-adaptive-model.html)