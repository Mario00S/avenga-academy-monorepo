using Class02.Homework04.Domain.BaseEntity;

namespace Class02.Homework04.Domain.Models;

public class Manager : Employee
{
    public decimal BaseSalary { get; set; }
    public decimal Bonus { get; set; }

    public override decimal CalculateSalary()
    {
        return BaseSalary + Bonus;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name} || ID: {Id} \nRole: {GetType().Name} || Salary {CalculateSalary()} ");
    }


}
