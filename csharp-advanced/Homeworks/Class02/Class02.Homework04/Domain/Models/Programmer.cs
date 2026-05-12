using Class02.Homework04.Domain.BaseEntity;
using System.Xml.Linq;

namespace Class02.Homework04.Domain.Models;

public class Programmer : Employee
{
    public decimal HourlyRate { get; set; }
    public decimal HoursWorked { get; set; }

    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name} || ID: {Id} \nRole: {GetType().Name} || Salary {CalculateSalary()} ");
    }


}


