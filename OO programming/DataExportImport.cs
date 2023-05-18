using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper;
using System.Linq;

namespace PayCalc_WinForms
{
    /// <summary>
    /// Base class to handle all csv file operations(reading form a fil and writing to a file).
    /// This class uses CsvHelper package by JoshClose© https://github.com/JoshClose/CsvHelper.git
    /// </summary>
    public class DataExportImport
    {
        /// <summary>
        /// Method that reads employee details form CSV file.
        /// </summary>
        /// <returns>A list of type Employee</returns>
        public static List<Employee> GetEmployees()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };
            var records = new List<Employee>();
            using (var reader = new StreamReader("..\\..\\..\\employeeDetails.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    Employee emp = new Employee
                    (
                       int.Parse(csv.GetField(0)),
                       csv.GetField(1),
                       csv.GetField(2),
                       decimal.Parse(csv.GetField(3)),
                       char.Parse(csv.GetField(4))
                    );
                    records.Add(emp);
                }
                return records;
            }
        }
        /// <summary>
        /// Method that reads tax tresholds form taxrate-notreshold CSV file.
        /// </summary>
        /// <returns>A list of type decimals</returns>
        public static List<decimal> GetTaxTresholdsForeignResidents()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                //Delimiter = ";"
            };
            var records = new List<string>();
            using (var reader = new StreamReader("..\\..\\..\\taxrate-foreign-residents.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    var record = csv.GetField(1);
                    records.Add(record);
                }
                List<decimal> taxThresholds = records.Select(Decimal.Parse).ToList();
                return taxThresholds;
            }
        }
        /// <summary>
        /// Method that reads tax tresholds form taxrate-withtreshold CSV file.
        /// </summary>
        /// <returns>A list of type decimals</returns>
        public static List<decimal> GetTaxTresholdsFoResidents()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                //Delimiter = ";"
            };
            var records = new List<string>();
            using (var reader = new StreamReader("..\\..\\..\\taxrate-residents.csv"))
            using (var csv = new CsvReader(reader, config))
            {

                while (csv.Read())
                {
                    var record = csv.GetField(1);
                    records.Add(record);
                }
                List<decimal> taxThresholds = records.Select(Decimal.Parse).ToList();
                return taxThresholds;
            }
        }
        /// <summary>
        /// Method that reads tax rates A form taxrate-notreshold CSV file.
        /// </summary>
        /// <returns>A list of type decimals</returns>
        public static List<decimal> taxRatesForeignResidents()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };
            var records = new List<string>();
            using (var reader = new StreamReader("..\\..\\..\\taxrate-foreign-residents.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    var record = csv.GetField(2);
                    records.Add(record);
                }
                List<decimal> taxRatesA = records.Select(Decimal.Parse).ToList();
                return taxRatesA;
            }
        }
        /// <summary>
        /// Method that reads tax rates B form taxrate-notreshold CSV file.
        /// </summary>
        /// <returns>A list of type decimals</returns>
        public static List<decimal> taxRatesBaseForeignResidents()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };
            var records = new List<string>();
            using (var reader = new StreamReader("..\\..\\..\\taxrate-foreign-residents.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    var record = csv.GetField(3);
                    records.Add(record);
                }
                List<decimal> taxRatesB = records.Select(Decimal.Parse).ToList();
                return taxRatesB;
            }
        }
        /// <summary>
        /// Method that reads tax rates A form taxrate-withtreshold CSV file.
        /// </summary>
        /// <returns>A list of type decimals</returns>
        public static List<decimal> taxRatesResidents()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                //Delimiter = ";"
            };
            var records = new List<string>();
            using (var reader = new StreamReader("..\\..\\..\\taxrate-residents.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    var record = csv.GetField(2);
                    records.Add(record);
                }
                List<decimal> taxRatesA = records.Select(Decimal.Parse).ToList();
                return taxRatesA;
            }
        }
        /// <summary>
        /// Method that reads tax rates B form taxrate-withtreshold CSV file.
        /// </summary>
        /// <returns>A list of type decimals</returns>
        public static List<decimal> taxRatesBaseResidents()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };
            var records = new List<string>();
            using (var reader = new StreamReader("..\\..\\..\\taxrate-residents.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    var record = csv.GetField(3);
                    records.Add(record);
                }
                List<decimal> taxRatesB = records.Select(Decimal.Parse).ToList();
                return taxRatesB;
            }
        }
        /// <summary>
        /// Method that writes employee's payslip details to CSV file.
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="fName">Employee first name</param>
        /// <param name="lName">Employee last name</param>
        /// <param name="paySlip">List of parameters for PaySlip object</param>
        public static void WritingToCSV(string id, string fName, string lName, List<string> paySlip)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };
            string outputDir = GetPathToDataFolder();
            string path = Path.Combine(outputDir, $"Pay_{id}_{fName}{lName}_{DateTime.Now.ToString("yyyyMMddhhmm")}.csv");
            var records = paySlip;
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<PaySlip>();
                csv.NextRecord();
                foreach (var record in records)
                {
                    csv.WriteField(record);
                }
            }
        }
        static string GetPathToDataFolder()
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string outputDir = Path.Combine(currentDir, "..", "..", "..", "PaySlips");
            return Path.GetFullPath(outputDir);
        }
    }
}
