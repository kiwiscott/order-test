using System;
using Xunit;

namespace OrderProcessor.UnitTest
{
    ///>The format of the line is fixed width at 39 characters with the following fields
    ///>* Four Digit Line Number Integer
    ///>* Ten Digit Product Code Alphanumberic
    ///>* Ten Digit Category Code Alphanumberic
    ///>* Five Digit Quantity Integer
    ///>* Ten Digit Price Float (note the last two digits represent a price)
    ///>* The line items may have whitespace instead of digits
    public class LineParserTest
    {
        //^([ 0-9]{4})([ a-zA-z0-9]{10})([ a-zA-z0-9]{10})([ 0-9]{5})([ 0-9]{10})$

        string line = "   1   P123456  SPORTING    9      1000";

        [Theory]
        [InlineData("   1   P123456  SPORTING    9      1000", 1, "P123456", "SPORTING", 9, 10.00)]
        [InlineData("9999P123456789GREATMUSIC888887777777777", 9999, "P123456789", "GREATMUSIC", 88888, 77777777.77)]
        public void ParsingFull(string lineString, int lineno, string code, string category, int quantity, decimal price)
        {
            var result = LineParser.Parse(lineString);
            Assert.Equal(lineno, result.LineNo);
            Assert.Equal(code, result.Code);
            Assert.Equal(category, result.Category);
            Assert.Equal(quantity, result.Quantity);
            Assert.Equal(price, result.Price);
        }

        [Theory]
        [InlineData("")]
        [InlineData("123456789012345678901234567890123456789012345678")]
        public void InvalidStringFormatsShouldFail(string lineString)
        {
            var expectedMessage = "line argument has an invalid format. The format should match the following regex \"^(?<lineno>[ 0-9]{4})(?<code>[ a-zA-z0-9]{10})(?<category>[ a-zA-z0-9]{10})(?<quantity>[ 0-9]{5})(?<price>[ 0-9]{10})$\"";
            var ex = Assert.Throws<System.ArgumentException>(() => LineParser.Parse(lineString));
            Assert.Equal(expectedMessage, ex.Message);
        }
        [Fact]
        public void MinNullStringShouldBeAnError()
        {
            string str = char.MinValue.ToString(); // Add null terminator.
            var ex = Assert.Throws<System.ArgumentException>(() => LineParser.Parse(str));
        }
        [Fact]
        public void ParsingNullStringShouldBeAnError()
        {
            var ex = Assert.Throws<System.ArgumentNullException>(() => LineParser.Parse(null));
            Assert.Equal("line", ex.ParamName);
        }

        [Fact]
        public void ParsingStringShouldNotBeNull()
        {
            var result = LineParser.Parse(line);
            Assert.NotNull(result);
        }

        [Fact]
        public void LineNoShouldBeOne()
        {
            var result = LineParser.Parse(line);
            Assert.Equal(1, result.LineNo);
        }

        [Fact]
        public void CodeShouldBeP123456()
        {
            var result = LineParser.Parse(line);
            Assert.Equal("P123456", result.Code);
        }

        [Fact]
        public void CategoryShouldBeSPORTING()
        {
            var result = LineParser.Parse(line);
            Assert.Equal("SPORTING", result.Category);
        }

        [Fact]
        public void QuantityShouldBeNine()
        {
            var result = LineParser.Parse(line);
            Assert.Equal(9, result.Quantity);
        }

        [Fact]
        public void PriceShouldBeTenDollars()
        {
            var result = LineParser.Parse(line);
            Assert.Equal(10.00m, result.Price);
        }
    }
}

/*
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

*/
