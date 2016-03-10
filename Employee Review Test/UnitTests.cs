using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee_Review;

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
            Department news = new Department("News");
            Assert.AreEqual("News", news.Name);
        }

        [TestMethod]
        public void EmployeeCreation()
        {
            Employee parker = new Employee("Dave Parker", "news@thv11.com", "501-244-4514", 10000);
            Assert.AreEqual("Dave Parker", parker.Name);
        }

        [TestMethod]
        public void EmployeeName()
        {
            Assert.AreEqual("Kate", kate.Name);
        }

        [TestMethod]
        public void AddEmployeeToDepartment()
        {
            d.AddEmployee(kate);
            Assert.IsFalse(d.Employees.Count == 0);

            Assert.AreSame("Kate", d.Employees[0].Name);
        }

        [TestMethod]
        public void GetEmployeeName()
        {
            string employeeName = kate.Name;
            Assert.AreEqual("Kate", employeeName);
        }

        [TestMethod]
        public void GetEmployeeSalary()
        {
            decimal employeeSalary = kate.Salary;
            Assert.AreEqual(8000, employeeSalary);
        }

        [TestMethod]
        public void GetDepartmentName()
        {
            string departmentName = d.Name;
            Assert.AreEqual("Sales", departmentName);
        }

        [TestMethod]
        public void GetDepartmentSalary()
        {
            d.AddEmployee(kate);
            decimal departmentSalary = d.TotalSalaries();
            Assert.AreEqual(8000, departmentSalary);
        }

        //[TestMethod]
        //public void AddReviewText()
        //{
        //    kate.Review = "Kate is amazing and we need to pay her more! The best employee I've ever had!!";
        //    Assert.IsNotNull(kate.Review);
        //}

        //[TestMethod]
        //public void MarkEmployeeSatisfactory()
        //{
        //    kate.IsSatisfactory = true;
        //    Assert.IsTrue(kate.IsSatisfactory);
        //}

        [TestMethod]
        public void TestRaise()
        {
            kate.Raise(200);
            Assert.AreEqual(8200, kate.Salary);
        }

        [TestMethod]
        public void TestDepartmentRaise()
        {
            d.DepartmentRaise(200);
            kate.IsSatisfactory = true;
            Assert.AreEqual(8200, kate.Salary);
        }
    }
}
