using OO_programming;
using System;
using Xunit;

namespace UnitTesting.Tests
{
    public class PayCalculatorTest
    {
        [Fact]
        public void CalculateGrossPay()
        {
            PayCalculator payCalc = new PayCalculator(hRate: 30);
            decimal actual = payCalc.CalculateGrossPay(20);
            decimal expected = 30 * 20;

            Assert.Equal(expected, actual);

        }
    }
}