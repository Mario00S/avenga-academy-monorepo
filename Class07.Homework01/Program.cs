using EmployeeManagement.Library.Models;

#region requirements

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


#endregion

#region WorkSpace

Console.WriteLine("Enter to reveal the Sales Staff:");
Console.ReadLine();
SalesPerson[] salesPersons = new SalesPerson[]
{
    new SalesPerson("Bob", "Bobsky"),
    new SalesPerson("Mo", "Mosky"),
    new SalesPerson("John", "Johnson"),
    new SalesPerson("Ana", "Ansky"),
    new SalesPerson("Eva", "Evsky"),
    new SalesPerson("Mark", "Marksky")
};

salesPersons[0].AddSuccessRevenue(1999.99);  // <= 2000  -> +500
salesPersons[1].AddSuccessRevenue(2000);     // <= 2000  -> +500
salesPersons[2].AddSuccessRevenue(2000.01);  // <= 5000  -> +1000
salesPersons[3].AddSuccessRevenue(4999.99);  // <= 5000  -> +1000
salesPersons[4].AddSuccessRevenue(5000);     // <= 5000  -> +1000
salesPersons[5].AddSuccessRevenue(5000.01);  // > 5000   -> +1500

foreach (SalesPerson salesPerson in salesPersons)
{
    salesPerson.PrintInfo();
}

Console.WriteLine("==============================================");

Console.WriteLine("Enter to reveal the Manager's Staff:");
Console.ReadLine();

Manager[] managers = new Manager[]
{
    new Manager("Mike", "Miller", 1000),
    new Manager("Sam", "Smith", 1000),
    new Manager("David", "Davis", 1000)
};

managers[0].AddBonus(0);      // expected 1000
managers[1].AddBonus(500);    // expected 1500
managers[2].AddBonus(200);
managers[2].AddBonus(300);    // expected 1500

foreach (Manager manager in managers)
{
    manager.PrintInfo();
}



#endregion