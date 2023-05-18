using System;
using Xunit;

namespace PayCalc_WinForms.Tests
{
    public class PayCalculatorResidentsTest
    {
        [Fact]
        public void GetTax()
        {
            PayCalculatorWithThreshold payCalc = new PayCalculatorWithThreshold(hRate: 25);
            decimal actual = payCalc.CalculateTax(calculatedPay: 1000);
            decimal expected = 161.4881m;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNetPay()
        {
            PayCalculatorWithThreshold payCalc = new PayCalculatorWithThreshold(hRate: 25);
            decimal actual = payCalc.CalculateNetPay(calculatedPay: 500, tax: 30.0431m);
            decimal expected = 500 - 30.0431m;
            expected = Decimal.Round(expected, 2);
            Assert.Equal(expected, actual);
        }

    }
}
