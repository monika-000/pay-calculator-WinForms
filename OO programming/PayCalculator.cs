using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_WinForms
{
    /// <summary>
    /// Base class to hold all Pay calculation functions
    /// </summary>
    /// <remarks>
    /// The <see cref="_hourlyRate"/> is a <see langword="decimal"/>
    /// that you use for a hourly rate.
    /// The <see cref="superRate"/> is a <see langword="decimal"/>
    /// that you use for a superannuation rate.
    /// </remarks>
    public class PayCalculator
    {
        private decimal _hourlyRate;
        public decimal superRate;
        public PayCalculator(decimal hRate)
        {
            superRate = 0.105m;
            _hourlyRate = hRate;
        }
        /// <inheritdoc cref="_hourlyRate"/>
        public decimal HourlyRate
        {
            get { return _hourlyRate; }
        }
        /// <summary>
        /// Method that claculates gross pay.
        /// </summary>
        /// <param name="hrsWorked">number of hours that employee worked</param>
        /// <returns>A decimal</returns>
        public virtual decimal CalculateGrossPay(decimal hrsWorked)
        {
            decimal calculatedPay = _hourlyRate * hrsWorked;
            return calculatedPay;

        }
        /// <summary>
        /// Method that claculates tax.Is iherited and calculated in PayCalculatorNoTreshold and PayCalculatroWithTreshold Class
        /// </summary>
        /// <param name="calculatedPay">calcuated gross pay</param>
        /// <returns>A decimal</returns>
        public virtual decimal CalculateTax(decimal calculatedPay)
        {
            return 0;
        }
        /// <summary>
        /// Method that claculates superannuation.
        /// </summary>
        /// <param name="calculatedPay">calcuated gross pay</param>
        /// <returns>A decimal</returns>
        public virtual decimal CalculateSuper(decimal calculatedPay)
        {
            decimal super = calculatedPay * superRate;
            return super;
        }
        /// <summary>
        /// Method that claculates net pay.Is iherited and calculated in PayCalculatorNoTreshold and PayCalculatroWithTresholdClass
        /// </summary>
        /// <param name="calculatedPay">calcuated gross pay</param>
        /// <param name="tax">Calculatd tax</param>
        /// <returns>A decimal</returns>
        public virtual decimal CalculateNetPay(decimal calculatedPay, decimal tax)
        {
            return 0;
        }
        /// <summary>
        /// Method thatreads tax treshold for employee.Is iherited and used in PayCalculatorNoTreshold and PayCalculatroWithTresholdClass
        /// </summary>
        /// <param name="calculatedPay">calcuated gross pay</param>
        /// <returns>A decimal</returns>
        public virtual decimal GetTreshold(decimal calculatedPay)
        {
            return 0;
        }
    }

}
