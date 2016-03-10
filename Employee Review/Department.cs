using System;
using System.Collections.Generic;
using System.Linq;
using Employee_Review;

public class Department
{
    public string Name { get; set; }
    public List<Employee> Employees = new List<Employee>();

    public Department(string name)
    {
        Name = name;
    }

    public void AddEmployee(Employee newEmployee)
    {
        Employees.Add(newEmployee);
    }

    public decimal TotalSalaries()
    {
        return Employees.Sum(e => e.Salary);
    }

    public void DepartmentRaise(decimal raiseBudget)
    {
        int employeesToGetRaises = 0;
        foreach (Employee e in Employees)
        {
            if (e.IsSatisfactory)
            {
                employeesToGetRaises++;
            }
        }
        if (employeesToGetRaises != 0)
        {
            decimal raisePerPerson = raiseBudget / employeesToGetRaises;

            foreach (Employee e in Employees)
            {
                if (e.IsSatisfactory)
                {
                    e.Salary += raisePerPerson;
                }
            }
        }

    }
}
