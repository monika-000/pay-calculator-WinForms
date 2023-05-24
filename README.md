# pay-calculator_WinForms

## Description
A Windows Form weekly pay calculator that calculates weekly gross and net pay, tax and superannuation for residents and foreign residents by reading from and writing data to CSV. Data is provided in CSV files, and the formula for calculating the tax, is for Australian tax thresholds.

## How to use
### Setup
 1. Clone the repository and download the solution.
 2. Instal CsvHelper using NuGet Package Manager.
 3. Build the solution and check for any errors. 

### Usage
1. Open the application in Visual Studio.
2. Update employeeDetails.csv, taxrate-residents.csv, taxrate-foreign-residents.csv files with your data. You can also run the program with the existing set of data. Please check the [Required CSV files section](#required-csv-files) for detailed fields description.  
3. Run the application in Visual Studio.
4. In the Windows Form Choose the employee for whom you'd like to calculate pay, enter the number of hours and click calculate button. The maximum number of hours you can enter is 40. 
5. On the right-hand side will be displayed the payment summary. Click the save button to save data to a CSV file. By default, data will be saved in the PaySlip folder. Document name will follow this pattern: "Pay_employeeId_fullName_date.csv"*.</br>

**date format YYYYMMDD HH:MM*

## Required CSV files 
Below you can find headers for each file. By default, headers are not included.</br>
**Please note:** This program is not set to ignore headers in CSV files, if you add them, it will treat it as a row with normal data and throw an error when it tries to parse the data.  
### employeeDetails.csv
| Employee Id  | First name | Last name | Hourly rate |Is foreign resident or resident for tax purposes|
| ------------- | ------------- | ------------- | ------------- | ------------- |
|  `integer` |  `string` | `string`  | `decimal` |`char`*   |

**Status for tax purposes. Values **R** for Resident, **F** for Foreign Resident*

### taxrate-residents.csv and taxrate-foreign-residents.csv
| Weekly earnings min | Weekly earnings max | Tax rates | Base AUD added for each treshold |
| ------------- | ------------- | ------------- | ------------- |
|  `decimal` |   `decimal` |  `decimal`  | `decimal` |

### payslip CSV
| Employee Id  | Hours worked | Hourly rate |Tax threshold |Gross pay |Net pay |Tax |Superannuation|
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- |------------- |
|  `integer` |  `decimal` | `decimal`  | `decimal` |`decimal`   |`decimal`   |`decimal`  |`decimal`  |

## License
Microsoft Public License (MS-PL) </br>
https://opensource.org/license/ms-pl-html/ </br>

Apache License, Version 2.0</br>
https://opensource.org/license/apache-2-0/ </br>

 GNU GENERAL PUBLIC LICENSE, Version 3 </br>
https://github.com/monika-000/pay-calculator/blob/853c2524e8b9a96d619b101524ce3d6c462403ce/LICENSE

## Packages
This code uses CsvHelper package for reading from and writing to CSV file.
