using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc_WinForms
{
    /// <summary>
    /// Extends PayCalculator class handling No tax threshold
    /// </summary>
    public class PayCalculatorForeignResidents : PayCalculator
    {
       
        public PayCalculatorForeignResidents(decimal hRate) : base(hRate) { }
        /// <inheritdoc cref="CalculateGrossPay"/>
        public override decimal CalculateGrossPay(decimal hrsWorked)
        {
            return base.CalculateGrossPay(hrsWorked);
        }
        /// <inheritdoc cref="CalculateSuper"/>
        public override decimal CalculateSuper(decimal calculatedPay)
        {
            return base.CalculateSuper(calculatedPay);
        }
        /// <inheritdoc cref="GetTreshold"/>
        public override decimal GetTreshold(decimal calculatedPay)
        {
            //List<string> textTresholds = DataExpImp.GetTaxTresholdsForeignResidents();
            List<decimal> taxThresholds = DataExportImport.GetTaxTresholdsForeignResidents();

            decimal treshold = 0;
            for (int i = 0; i < taxThresholds.Count; i++)
            {
                if (calculatedPay < taxThresholds[i])
                {
                    treshold = taxThresholds[i];
                    break;
                }
            }
            return treshold;
        }
        /// <inheritdoc cref="CalculateTax"/>
        public override decimal CalculateTax(decimal calculatedPay)
        {
            decimal tax = 0;
            List<decimal> taxThresholds = DataExportImport.GetTaxTresholdsForeignResidents();
            List<decimal> taxRates = DataExportImport.taxRatesForeignResidents();
            List<decimal> taxBase = DataExportImport.taxRatesBaseForeignResidents();

            for (int i = 0; i < taxThresholds.Count; i++)
            {
                if(calculatedPay <= taxThresholds[i])
                {
                    tax = calculatedPay * taxRates[i] + taxBase[i];
                    break;
                }
                //decimal newPay = Math.Round(calculatedPay);
                //if (newPay < taxThresholds[i])
                //{
                //    tax = taxRates[i] * newPay - taxBase[i];
                //    break;
                //}
            }
            return tax;

        }
        /// <inheritdoc cref="CalculateNetPay"/>
        public override decimal CalculateNetPay(decimal calculatedPay, decimal tax)
        {
            decimal netPay = calculatedPay - tax;
            netPay = Decimal.Round(netPay, 2);
            return netPay;
        }
    }

}
