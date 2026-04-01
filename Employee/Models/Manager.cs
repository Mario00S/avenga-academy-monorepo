namespace EmployeeManagement.Library.Models;
using Enum.Role.Enums;

public class Manager : Employee
{

    private double Bonus { get; set; } = 0;

    public Manager(string firstName, string lastName, double salary)
        :base(firstName, lastName, Role.Manager, salary)
    {
        
    }


    public void AddBonus(double bonus)
    {
        Bonus = Bonus + bonus;
    }

    public override double GetSalary()
    {
        return Salary + Bonus;
    }

}


//EXERCISE 2
//Create class Manager that inherits from Employee.

//Property:

//Bonus(double, private)
//Create:

//Constructor
//Method AddBonus()
//Override GetSalary() to return Salary + Bonus.