using System.Linq;

namespace StringCalculator.Calculator
{

    public class StringCalculator
    {
        private readonly IStringNumberParser parser;
        private readonly ICalculatorRuleStrategy addRuleStrategy;

        public StringCalculator(IStringNumberParser parser, ICalculatorRuleStrategy addRuleStrategy)
        {
            this.parser = parser;
            this.addRuleStrategy = addRuleStrategy;
        }
        public int Add(string numbers)
        {
            var numberList = parser.Parse(numbers);
            numberList = addRuleStrategy.Apply(numberList);
            return numberList.Sum();
        }
    }
}