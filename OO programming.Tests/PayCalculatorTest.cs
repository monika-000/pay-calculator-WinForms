namespace PayCalc_WinForms.Tests
{
    public class PayCalculatorTest
    {
        [Fact]
        public void GetGrossPay()
        {
            PayCalculator payCalc = new PayCalculator(hRate: 30);
            decimal actual = payCalc.CalculateGrossPay(hrsWorked: 20);
            decimal expected = 30 * 20;
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GetSuperannuation()
        {
            PayCalculator payCalc = new PayCalculator(hRate: 30);
            decimal actual = payCalc.CalculateSuper(calculatedPay: 500);
            decimal expected = 500 * 0.105m;
            Assert.Equal(expected, actual);

        }
    }
}