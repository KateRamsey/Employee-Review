using System;
using System.Collections.Generic;
using Employee_Review;

public class Department
{
    public string Name { get; set; }
    public List<Employee> Employees = new List<Employee>(); 

    public Department(string name)
    {
        Name = name;
    }
}
