namespace Class02.Homework04.Domain.BaseEntity;

public abstract class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public abstract decimal CalculateSalary();
    public abstract void DisplayInfo();
}
