namespace StringCalculator.Calculator
{
    public class StringCalculatorFactory : IStringCalculatorFactory
    {
        public StringCalculator Create()
        {
            return new StringCalculator(
                new StringNumberParser(),
                new StringCalculatorAddRuleFactory());
        }
    }
}