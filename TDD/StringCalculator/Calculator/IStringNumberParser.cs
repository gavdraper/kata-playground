using System.Collections.Generic;

namespace StringCalculator.Calculator
{
    public interface IStringNumberParser
    {
        public IEnumerable<int> Parse(string numbers);
    }
}