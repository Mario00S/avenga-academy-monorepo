namespace EmployeeManagement.Library.Models;

using Enum.Role.Enums;

public class SalesPerson : Employee
{

    private double SuccessSaleRevenue { get; set; } = 0;

    public SalesPerson(string firstName, string lastName)
        :base(firstName, lastName, Role.Sales, 500)
    {
        
    }


    public void AddSuccessRevenue(double number)
    {
        if (number >= 0)
        {
            SuccessSaleRevenue = SuccessSaleRevenue + number;
        }
        else
        {
            Console.WriteLine("Invalid input");
        }


    }

    public override double GetSalary()
    {
        if (SuccessSaleRevenue <= 2000)
        {
            return Salary + 500;
        }else if (SuccessSaleRevenue <= 5000)
        {
            return Salary + 1000;
        }
        else
        {
            return Salary + 1500;
        }

    }
}


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
