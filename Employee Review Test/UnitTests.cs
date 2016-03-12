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
        Employee parker = new Employee("Dave Parker", "news@thv11.com", "501-244-4514", 10000);
        Employee byron = new Employee("B-dubs", "bwilkinson@thv11.com", "501-244-4517", 2);


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
        public void AddMultipleEmployeesToDepartment()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);
            Assert.IsFalse(d.Employees.Count == 0);

            Assert.AreSame("Kate", d.Employees[0].Name);
            Assert.AreSame("B-dubs", d.Employees[1].Name);
            Assert.AreSame("Dave Parker", d.Employees[2].Name);
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

        [TestMethod]
        public void AddReviewText()
        {
            kate.Review = "Kate is amazing and we need to pay her more! The best employee I've ever had!!";
            Assert.IsNotNull(kate.Review);
        }

        [TestMethod]
        public void EvaluateNegativeReview()
        {
            kate.Review = "Kate is not picking up new skills as quickly as we would like. She doesn't seem to put in enough effort, and she takes long lunches.";
            kate.EvaluateReview();
            Assert.IsFalse(kate.IsSatisfactory);
        }

        [TestMethod]
        public void EvaluateNegativeReview2()
        {
            kate.Review = "Zeke is a very positive person and encourages those around him, but he has not done well technically this year.  There are two areas in which Zeke has room for improvement.  First, when communicating verbally (and sometimes in writing), he has a tendency to use more words than are required.  This conversational style does put people at ease, which is valuable, but it often makes the meaning difficult to isolate, and can cause confusion.Second, when discussing new requirements with project managers, less of the information is retained by Zeke long-term than is expected.This has a few negative consequences: 1) time is spent developing features that are not useful and need to be re - run, 2) bugs are introduced in the code and not caught because the tests lack the same information, and 3) clients are told that certain features are complete when they are inadequate.  This communication limitation could be the fault of project management, but given that other developers appear to retain more information, this is worth discussing further.";
            kate.EvaluateReview();
            Assert.IsFalse(kate.IsSatisfactory);
        }

        [TestMethod]
        public void EvaluateNegativeReview3()
        {
            kate.Review = "Thus far, there have been two concerns over Yvonne's performance, and both have been discussed with her in internal meetings.  First, in some cases, Yvonne takes longer to complete tasks than would normally be expected.  This most commonly manifests during development on existing applications, but can sometimes occur during development on new projects, often during tasks shared with Andrew.  In order to accommodate for these preferences, Yvonne has been putting more time into fewer projects, which has gone well.Second, while in conversation, Yvonne has a tendency to interrupt, talk over others, and increase her volume when in disagreement.In client meetings, she also can dwell on potential issues even if the client or other attendees have clearly ruled the issue out, and can sometimes get off topic.";
            kate.EvaluateReview();
            Assert.IsFalse(kate.IsSatisfactory);
        }

        [TestMethod]
        public void EvaluatePositiveReview()
        {
            kate.Review = "Kate is amazing and we need to pay her more! The best employee I've ever had!!";
            kate.EvaluateReview();
            Assert.IsTrue(kate.IsSatisfactory);
        }

        [TestMethod]
        public void EvaluatePositiveReview2()
        {
            kate.Review = "Xavier is a huge asset to SciMed and is a pleasure to work with.  He quickly knocks out tasks assigned to him, implements code that rarely needs to be revisited, and is always willing to help others despite his heavy workload.  When Xavier leaves on vacation, everyone wishes he didn't have to go. Last year, the only concerns with Xavier performance were around ownership.  In the past twelve months, he has successfully taken full ownership of both Acme and Bricks, Inc.Aside from some false starts with estimates on Acme, clients are happy with his work and responsiveness, which is everything that his managers could ask for.";
            kate.EvaluateReview();
            Assert.IsTrue(kate.IsSatisfactory);
        }

        [TestMethod]
        public void EvaluatePositiveReview3()
        {
            kate.Review = "Wanda has been an incredibly consistent and effective developer.  Clients are always satisfied with her work, developers are impressed with her productivity, and she's more than willing to help others even when she has a substantial workload of her own.  She is a great asset to Awesome Company, and everyone enjoys working with her.  During the past year, she has largely been devoted to work with the Cement Company, and she is the perfect woman for the job.  We know that work on a single project can become monotonous, however, so over the next few months, we hope to spread some of the Cement Company work to others.  This will also allow Wanda to pair more with others and spread her effectiveness to other projects.";
            kate.EvaluateReview();
            Assert.IsTrue(kate.IsSatisfactory);
        }

        [TestMethod]
        public void MarkEmployeeSatisfactory()
        {
            kate.IsSatisfactory = true;
            Assert.IsTrue(kate.IsSatisfactory);
        }

        [TestMethod]
        public void TestRaise()
        {
            kate.Raise(200);
            Assert.AreEqual(8200, kate.Salary);
        }

        [TestMethod]
        public void TestDepartmentRaise()
        {
            d.AddEmployee(kate);
            kate.IsSatisfactory = true;
            d.DepartmentRaise(200);
            Assert.AreEqual(8200, kate.Salary);
        }

        [TestMethod]
        public void TestDepartmentRaiseWithMultipleEmployeesAllSatisfactory()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);

            kate.IsSatisfactory = true;
            parker.IsSatisfactory = true;
            byron.IsSatisfactory = true;
            d.DepartmentRaise(3000);
            Assert.AreEqual(9000, kate.Salary);
        }

        [TestMethod]
        public void TestDepartmentRaiseWithMultipleEmployeesNotAllSatisfactory()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);

            kate.IsSatisfactory = true;
            parker.IsSatisfactory = false;
            byron.IsSatisfactory = true;
            d.DepartmentRaise(2000);
            Assert.AreEqual(9000, kate.Salary);
        }

        [TestMethod]
        public void PrintingEmployeeInfo()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);

            kate.IsSatisfactory = true;
            parker.IsSatisfactory = false;
            byron.IsSatisfactory = true;

            string employeeInfoString = "";

            employeeInfoString = $"{d.Employees[0].Name}'s email address is {d.Employees[0].EmailAddress} " +
                                 $"Their phone number is {d.Employees[0].PhoneNumber} " +
                                 $"and their salary is ${d.Employees[0].Salary}. " +
                                 $"They are currently marked as Satisfactory: {d.Employees[0].IsSatisfactory}";

            Assert.AreEqual("Kate's email address is kramsey@thv11.com Their phone number is 501-743-6074 and their salary is $8000. They are currently marked as Satisfactory: True", employeeInfoString);





        }
    }
}
