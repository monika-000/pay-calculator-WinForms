using CsvHelper.Configuration.Attributes;

namespace PayCalc_WinForms
{/// <summary>
 /// Base class to hold all Employee details. 
 /// </summary>
 /// <remarks>
 /// The <see cref="_employeeID"/> is a <see langword="int"/>
 /// that you use for a employee Id.
 /// The <see cref="_firstName"/> is a <see langword="string"/>
 /// that you use for a employee first name.
 /// The <see cref="_lastName"/> is a <see langword="string"/>
 /// that you use for a employee last name.
 /// The <see cref="_hrlRate"/> is a <see langword="decimal"/>
 /// that you use for a hourly rate.
 /// The <see cref=" _taxType"/> is a <see langword="decimal"/>
 /// that you use for a employee tax status(tax free treshold claimed or not claimed).
 /// </remarks>
    public class Employee
    {
        [Index(0)]
        private int _employeeID;
        [Index(1)]
        private string _firstName;
        [Index(2)]
        private string _lastName;
        [Index(3)]
        private decimal _hrlRate;
        [Index(4)]
        private char _taxType;

        public Employee(int empID, string fName, string lName, decimal hRate, char tClaimed)
        {

            _employeeID = empID;
            _firstName = fName;
            _lastName = lName;
            _hrlRate = hRate;
            _taxType = tClaimed;
        }
        /// <inheritdoc cref="_employeeID"/>
        public int EmployeeID
        {
            get
            {
                return _employeeID;
            }
        }
        /// <inheritdoc cref="_firstName"/>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }
        /// <inheritdoc cref="_lastName"/>
        public string LastName
        {
            get
            {
                return _lastName;
            }
        }
        /// <inheritdoc cref="_hrlRate"/>
        public decimal HourlyRate
        {
            get
            {
                return _hrlRate;
            }
        }
        /// <inheritdoc cref="_taxType"/>
        public char TaxClaimed
        {
            get
            {
                return _taxType;
            }
        }
        public override string ToString()
        {
            return EmployeeID + " " + FirstName + " " + LastName;
        }
    }
}


