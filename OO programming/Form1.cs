using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PayCalc_WinForms
{
    /// <summary>
    /// Class that manages UI.
    /// </summary>
    public partial class Form1 : Form
    {
        private BindingSource _emp;
        /// <summary>
        /// Constructior method that initalizes winfrom components and adds biding source to listbox1.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            List<Employee> emp = DataExportImport.GetEmployees();
            _emp = new BindingSource();
            _emp.DataSource = emp;
            listBox1.DataSource = _emp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            object item = listBox1.SelectedItem;
            Employee employee = (Employee)item;
            bool isNumber = false;
            decimal hours = 0;
            isNumber = decimal.TryParse(txtHour.Text, out hours);
            decimal tax = 0;
            decimal netPay = 0;
            decimal treshold = 0;
            PayCalculator payCalc = new PayCalculator(employee.HourlyRate);
            PayCalculatorNoThreshold payCalcNoTres = new PayCalculatorNoThreshold(employee.HourlyRate);
            PayCalculatorWithThreshold payCalcWithTres = new PayCalculatorWithThreshold(employee.HourlyRate);
            string message = "The number of hours can't be greater than 40 and has to be a number";
            string msg = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            if (!isNumber || hours > 40)
            {
                MessageBox.Show(message, msg, buttons);
            }
            else
            {
                decimal grossPay = payCalc.CalculateGrossPay(hours);
                decimal super = payCalc.CalculateSuper(grossPay);
                switch (employee.TaxClaimed)
                {
                    case 'Y':
                        treshold = payCalcWithTres.GetTreshold(grossPay);
                        tax = payCalcWithTres.CalculateTax(grossPay);
                        netPay = payCalcWithTres.CalculateNetPay(grossPay, tax);
                        break;
                    case 'N':
                        treshold = payCalcNoTres.GetTreshold(grossPay);
                        tax = payCalcNoTres.CalculateTax(grossPay);
                        netPay = payCalcNoTres.CalculateNetPay(grossPay, tax);
                        break;
                }
                PaySlip paySlip = new PaySlip(employee.EmployeeID, hours, employee.HourlyRate, treshold, grossPay, tax, super, netPay);

                string textToDisplay = $"{paySlip.EmployeeID}{Environment.NewLine}{employee.FirstName} {employee.LastName}{Environment.NewLine}{paySlip.HoursWorked}{Environment.NewLine}{paySlip.HourlyRate}{Environment.NewLine}{paySlip.TaxTreshold}{Environment.NewLine}{grossPay}{Environment.NewLine}{paySlip.NetPay}{Environment.NewLine}{paySlip.Tax}{Environment.NewLine}{paySlip.Supperanuation}";

                paySlip_textBox.Text = textToDisplay;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> textBoxData = new List<string>();

            string text = paySlip_textBox.Text;
            text = Regex.Replace(text, @"\r\n", " ");
            textBoxData = text.Split(' ').ToList();
            List<string> payslipData = new List<string>();
            payslipData.AddRange(textBoxData);
            payslipData.RemoveRange(1, 2);
            DataExportImport.WritingToCSV(textBoxData[0], textBoxData[1], textBoxData[2], payslipData);
        }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
