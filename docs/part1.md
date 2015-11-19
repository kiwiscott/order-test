#Learning to TDD some classes
 
##Lets learn some basic TDD
While doing these excercises try and remember the basic TDD premise -> RED, GREEN, REFACTOR

###Part 1
 We are writting part of a order management system. You task of to take a string in a known format and turn them into order line objects
>The format of the line is fixed width at 39 characters with the following fields
>* Four Digit Line Number Integer
>* Ten Digit Product Code Alphanumberic
>* Ten Digit Category Code Alphanumberic
>* Five Digit Quantity Integer
>* Ten Digit Price Float (note the last two digits represent a price)
>* The line items may have whitespace instead of digits

The output object should have the following fields:  
>* lineno (int)
>* code (alpha)
>* category(alpha)
>* quantity (int)
>* price (float)

Here's the first sample line item 
>'   1   P123456  SPORTING    9      1000'

expected object
>{lineno : 1 , code : 'P123456', category : 'SPORTING' , quantity : 9, price : 10.00}
   
 **Remember stay focused on the task at hand making baby steps to get to the goal**
