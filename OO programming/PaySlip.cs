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
    /// The <see cref="_employeeID"/> is a <see langword="int"/>
    /// that you use for a employee Id.
    /// The <see cref="_hrsWorked"/> is a <see langword="decimal"/>
    /// that you use for a number of hours that employee worked.
    /// The <see cref="_hrlRate"/> is a <see langword="decimal"/>
    /// that you use for a hourly rate.
    /// The <see cref=" _taxTreshold"/> is a <see langword="decimal"/>
    /// that you use for a employee tax treshold.
    /// The <see cref=" _payGrossCalculated"/> is a <see langword="decimal"/>
    /// that you use for a calculated gross pay.
    /// The <see cref=" _taxCalculated"/> is a <see langword="decimal"/>
    /// that you use for a calculated tax.
    /// The <see cref=" _superCalculated"/> is a <see langword="decimal"/>
    /// that you use for a calculated suprannuation.
    /// The <see cref=" _payNetCalculated"/> is a <see langword="decimal"/>
    /// that you use for a calculated net pay.
    /// </remarks>
    public class PaySlip
    {
        private int _employeeID;
        private decimal _hrsWorked;
        private decimal _hrlRate;
        private decimal _taxTreshold;
        private decimal _payGrossCalculated;
        private decimal _taxCalculated;
        private decimal _superCalculated;
        private decimal _payNetCalculated;

        public PaySlip(int empID, decimal hWorked, decimal hRate, decimal taxTres, decimal payGross, decimal tax, decimal super, decimal payNet)
        {
            _employeeID = empID;
            _hrsWorked = hWorked;
            _hrlRate = hRate;
            _taxTreshold = taxTres;
            _payGrossCalculated = payGross;
            _taxCalculated = tax;
            _superCalculated = super;
            _payNetCalculated = payNet;
        }
        /// <inheritdoc cref="_employeeID"/>
        public int EmployeeID
        {
            get { return _employeeID; }
        }
        /// <inheritdoc cref="_hrsWorked"/>
        public decimal HoursWorked
        {
            get { return _hrsWorked; }
        }
        /// <inheritdoc cref="_hrlRate"/>
        public decimal HourlyRate
        {
            get { return _hrlRate; }
        }
        /// <inheritdoc cref="_taxTreshold"/>
        public decimal TaxTreshold
        {
            get { return _taxTreshold; }
        }
        /// <inheritdoc cref="_payGrossCalculated"/>
        public decimal GrossPay
        {
            get { return _payGrossCalculated; }
        }
        /// <inheritdoc cref="_payNetCalculated"/>
        public decimal NetPay
        {
            get { return _payNetCalculated; }
        }
        /// <inheritdoc cref="_taxCalculated"/>
        public decimal Tax
        {
            get { return _taxCalculated; }
        }
        /// <inheritdoc cref="_superCalculated"/>
        public decimal Supperanuation
        {
            get { return _superCalculated; }
        }
        public override string ToString()
        {
            return $"{EmployeeID} {HoursWorked} {HourlyRate} {TaxTreshold} {GrossPay} {NetPay} {Tax} {Supperanuation}";
        }
    }
}
