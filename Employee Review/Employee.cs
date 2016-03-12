using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Review
{
    public class Employee
    {
        public Employee(string name, string email, string phone, decimal salary)
        {
            Name = name;
            EmailAddress = email;
            PhoneNumber = phone;
            Salary = salary;
        }

        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public bool IsSatisfactory { get; private set; }
        public string Review { get; set; }

        public void Raise(decimal increase)
        {
            Salary += increase;
        }

        public void EvaluateReview()
        {
            IsSatisfactory = false;
            string sPattern = "satisf | effect | asset | success | pleasure | amazing";
            if (System.Text.RegularExpressions.Regex.IsMatch(this.Review, sPattern))
            {
                IsSatisfactory = true;
            }
        }
    }
}
