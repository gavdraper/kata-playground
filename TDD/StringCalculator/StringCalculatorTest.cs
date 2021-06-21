using System;
using StringCalculator.Calculator;
using Xunit;

namespace StringCalculator
{
    public class UnitTest1
    {
        StringCalculator.Calculator.StringCalculator calc;

        public UnitTest1()
        {
            var factory = new StringCalculatorFactory();
            calc = factory.Create();
        }

        [Fact]
        public void EmptyStringReturnsZero()
        {
            Assert.Equal(0,calc.Add(""));
        }

        [Fact]
        public void NullStringReturnsZero()
        {
            Assert.Equal(0,calc.Add(null));
        }

        [Fact]
        public void SingleNumberReturnsSameNumber()
        {
            Assert.Equal(2,calc.Add("2"));
        }

        [Fact]
        public void TwoCommaSeperatedNumbersReturnsSum()
        {
            Assert.Equal(3,calc.Add("1,2"));
        }

        [Fact]
        public void ThreeCommaReturnSeperatedNumbersReturnsSum()
        {
            Assert.Equal(6,calc.Add("1,2\n3"));
        }

        [Fact]
        public void CustomDelimiterSumsNumbers()
        {
            Assert.Equal(3,calc.Add("//;\n1;2"));
        }

        [Fact]
        public void AnyNegativeNumberThrowsException()
        {
             Assert.Throws<ArgumentException>(() => calc.Add("1,2,-9"));
        }

        [Fact]
        public void NumbersOverOneThousendIgnored()
        {
             Assert.Equal(2,calc.Add("2,1001"));
        }
    }
}
