using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Employee_Review_Test
{
    [TestClass]
    public class EmployeeReviewTest
    {
        Department d = new Department("Sales");
        Employee e = new Employee("Kate", "kramsey@thv11.com", "501-743-6074", 32000);

        [TestMethod]
        public void DepartmentCreation()
        {
            Assert("Sales", d.Name())
        }

        [TestMethod]
        public void EmployeeName()
        {
            Assert("Kate", e.Name())
        }
    }
}
