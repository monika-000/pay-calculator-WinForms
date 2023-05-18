# pay-calculator_WinForms

## Description
This is a Windows Form weekly pay calculator that calculate weekly gorss and net pay, tax and supperannuation for residents and foreign residents by reading form and writing data to CSV.

## How to use
### Setup
 1. Clone the repository and download the solution.
 2. Instal CsvHelper using NuGet Package Manager.
 3. Build the solution and check for any errors. 

### Usage
1. Open application in Visual Studio.
2. Update employeeDetails.csv, taxrate-residents.csv, taxrate-foreign-residents.csv files with your data. You can also run program with the existing set of data. Please check Required CSV files section for the detailed fields description. 
3. Run application in Visual Studio.
4. In the Windows Form Choose employee for whom you'd like to calculate pay, enter number of hours and click calculate button. The maximal number of hours you can enter is 40. 
5. On the right hand side will be dispayed payment summary. Click save button to save data to CSV file. By default data will be saved in PaySlip folder. Document name will follow this pattern: "Pay_employeeId_fullName_date.csv"*.</br>

**date format YYYYMMDD HH:MM*

## Required CSV files 
Below you can find headers for each file. By default headers are not included.</br>
**Please note:** this program is not set to ignore headers in CSV files, if you add them, it will treat it as row with normal data.  
### employee.csv
| Employee Id  | First name | Last name | Hourly rate |Has tax free treshold |
| ------------- | ------------- | ------------- | ------------- | ------------- |
|  `integer` |  `string` | `string`  | `decimal` |`char`*   |

**Values **Y** for Yes, **N** for No*

### taxrate-nothreshold.csv and taxrate-withthreshold.csv
| Weekly earnings min  | Weekly earnings max | Tax rates A | Tax rates B |
| ------------- | ------------- | ------------- | ------------- |
|  `decimal` |   `decimal` |  `decimal`  | `decimal` |

### payslip CSV
| Employee Id  | Hours worked | Hourly rate |Tax treshold |Gross pay |Net pay |Tax |Superannuation|
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
