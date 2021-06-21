using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Calculator
{
    public class StringNumberParser : IStringNumberParser
    {
        public IEnumerable<int> Parse(string numbers)
        {
            if(string.IsNullOrEmpty(numbers))
                return new int[]{};

            var delimeters = new char[]{',','\n'};

            if(numbers.StartsWith("//"))
            {
                var delimiterSpec = numbers.Split('\n')[0];
                delimeters= new char[]{delimiterSpec[2]};
                numbers = numbers.Replace(delimiterSpec + "\n","");
            }

            var nums = numbers.Split(delimeters).Select(x=> int.Parse(x));
            return nums;
        }
    }
}