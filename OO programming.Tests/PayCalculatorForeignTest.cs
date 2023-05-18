using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_WinForms.Tests
{
    public class PayCalculatorForeignTest
    {
        //[Theory]
        //[ClassData(typeof(PayCalculatorForeignResidents))]
        //public void GetTax(decimal calculatedPay, decimal expected)
        //{
        //    PayCalculatorForeignResidents payCalc = new PayCalculatorForeignResidents(hRate: 25);
        //    decimal actual = payCalc.CalculateTax(calculatedPay);

        //    Assert.Equal(expected, actual);
        //}

        [Fact]
        public void GetTax()
        {


            PayCalculatorForeignResidents payCalc = new PayCalculatorForeignResidents(hRate: 25);
            decimal actual = payCalc.CalculateTax(calculatedPay: 1000);
            decimal expected = 283.0868m;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNetPay()
        {
            PayCalculatorForeignResidents payCalc = new PayCalculatorForeignResidents(hRate: 25);
            decimal actual = payCalc.CalculateNetPay(calculatedPay: 500, tax: 30.0431m);
            decimal expected = 500 - 30.0431m;
            expected = Decimal.Round(expected, 2);
            Assert.Equal(expected, actual);
        }
    }
}
