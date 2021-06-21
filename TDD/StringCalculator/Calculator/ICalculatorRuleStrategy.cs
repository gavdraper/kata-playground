using System.Collections.Generic;

namespace StringCalculator.Calculator
{
    public interface ICalculatorRuleStrategy
    {
        IEnumerable<int> Apply(IEnumerable<int> numbers);
    }
}