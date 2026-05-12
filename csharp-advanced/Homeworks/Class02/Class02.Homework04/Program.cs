using Class02.Homework04.Domain.BaseEntity;
using Class02.Homework04.Domain.Models;

Programmer programmer1 = new Programmer()
{
    Id = 1,
    Name = "Alice",
    HourlyRate = 25,
    HoursWorked = 160
};

Programmer programmer2 = new Programmer()
{
    Id = 2,
    Name = "Bob",
    HourlyRate = 30,
    HoursWorked = 150
};

Manager manager1 = new Manager()
{
    Id = 3,
    Name = "Carol",
    BaseSalary = 3000,
    Bonus = 500
};

Manager manager2 = new Manager()
{
    Id = 4,
    Name = "David",
    BaseSalary = 3500,
    Bonus = 700
};

Employee[] employees = { programmer1, programmer2, manager1, manager2};
Console.WriteLine("Printing the Display info for all of the employees:");
Console.ReadLine();
foreach (var employee in employees)
{
    employee.DisplayInfo();
}
Console.ReadLine();
