using System.Collections.Generic;
using System;
using System.Linq;

namespace StringCalculator.Calculator
{
    public class StringCalculatorAddRuleFactory : ICalculatorRuleStrategy
    {
        public IEnumerable<int> Apply(IEnumerable<int> numbers)
        {
            if(numbers.Any(x=> x < 0))
                throw new ArgumentException("Numbers Less Than Zero");

            numbers = numbers.Where(x=> x < 1001);
            return numbers;
        }
    }
}