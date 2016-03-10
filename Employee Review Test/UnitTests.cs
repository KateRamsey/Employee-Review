using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Employee_Review_Test
{
    [TestClass]
    public class EmployeeReviewTest
    {
        Department d = new Department("Sales");
        Employee kate = new Employee("Kate", "kramsey@thv11.com", "501-743-6074", 8000);

        [TestMethod]
        public void DepartmentCreation()
        {
            Assert.AreEqual("Sales", d.Name());
        }

        [TestMethod]
        public void EmployeeName()
        {
            Assert.AreEqual("Kate", kate.Name());
        }

        [TestMethod]
        public void AddEmployeeToDepartment()
        {
            d.AddEmployee(kate);
            Assert.IsFalse(d.EmployeeList.count() == 0);
        }

        [TestMethod]
        public void GetEmployeeName()
        {
            string employeeName = kate.Name();
            Assert.AreEqual("Kate", employeeName);
        }
        [TestMethod]
        public void GetEmployeeSalary()
        {
            string employeeSalary = kate.Salary();
            Assert.AreEqual(8000, employeeSalary);
        }

    }
}
