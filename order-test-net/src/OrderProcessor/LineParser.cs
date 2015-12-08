using System.Text.RegularExpressions;

namespace OrderProcessor
{
    public class LineParser
    {
        private const string EXPECTED_FORMAT = "^(?<lineno>[ 0-9]{4})(?<code>[ a-zA-z0-9]{10})(?<category>[ a-zA-z0-9]{10})(?<quantity>[ 0-9]{5})(?<price>[ 0-9]{10})$";
        private const string ERROR_MESSAGE = "line argument has an invalid format. The format should match the following regex \"^(?<lineno>[ 0-9]{4})(?<code>[ a-zA-z0-9]{10})(?<category>[ a-zA-z0-9]{10})(?<quantity>[ 0-9]{5})(?<price>[ 0-9]{10})$\"";
        
        public static OrderLine Parse(string line)
        {
            if(line == null)
             throw new System.ArgumentNullException("line"); 
            
            var regex = new Regex(EXPECTED_FORMAT);
            var match = regex.Match(line);
            
            if(!match.Success) throw new System.ArgumentException(ERROR_MESSAGE);

            return new OrderLine()
            {
                LineNo = ToInt(match, "lineno"),
                Code = ToTrimmedString(match, "code"),
                Category = ToTrimmedString(match, "category"),
                Quantity = ToInt(match, "quantity"),
                Price = (decimal.Parse(match.Groups["price"].Value.Trim()) / 100.0m)
            };
        } 
        private static string ToTrimmedString(Match m, string name)
        {
            return m.Groups[name].Value.Trim();
        }
        private static int ToInt(Match m, string name)
        {
            var t = ToTrimmedString(m, name);
            return int.Parse(t);
        }
        private static decimal ToPriceDecimal(Match m, string name)
        {
            var t = ToTrimmedString(m, name);
            return decimal.Parse(t) / 100.00m;
        }
    }
}

