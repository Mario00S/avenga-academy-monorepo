using Enum.Role.Enums;

namespace EmployeeManagement.Library.Models;

public class Employee
{

    public Employee()
    {
        
    }

    public Employee(string firstName, string lastName, Role role, double salary)
    {
        FirstName = firstName;
        LastName = lastName;
        EmployeeRole = role;
        Salary = salary;
    }


    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Role EmployeeRole { get; set; }

    protected double Salary { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"{FirstName} {LastName} | Role: {EmployeeRole} | Salary: {GetSalary()}");
    }

    public virtual double GetSalary()
    {
        return Salary;
    }

}




//EXERCISE – Base Setup
//Create a class library project.

//Inside it create:

//Class Employee with properties:

//FirstName
//LastName
//Role(Enum: Sales, Manager, Other)
//Salary (protected double)
//Methods:

//PrintInfo()
//GetSalary()
//EXERCISE 1
//Create a SalesPerson class that inherits from Employee.

//Properties:

//SuccessSaleRevenue(double, private)
//Rules:

//Default salary = 500
//Default role = Sales
//Create:

//Constructor that sets all properties
//Method AddSuccessRevenue(number)
//Override GetSalary():

//If revenue ≤ 2000 → +500 bonus
//If revenue ≤ 5000 → +1000 bonus
//If revenue > 5000 → +1500 bonus
//EXERCISE 2
//Create class Manager that inherits from Employee.

//Property:

//Bonus(double, private)
//Create:

//Constructor
//Method AddBonus()
//Override GetSalary() to return Salary + Bonus.
