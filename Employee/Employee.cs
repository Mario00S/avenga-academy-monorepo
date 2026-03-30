namespace Employee;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected double Salary { get; set; }


    public void PrintInfo()
    {
        Console.WriteLine($"The info for the : {FirstName} and {LastName} and {Salary}");
    }

    public double GetSalary() 
    {
        return Salary;
    }

}




//Create a class library project.

//Inside it create:

//Class Employee with properties:

//FirstName
//LastName
//Role(Enum: Sales, Manager, Other)
//Salary(protected double)
//Methods:

//PrintInfo()
//GetSalary()