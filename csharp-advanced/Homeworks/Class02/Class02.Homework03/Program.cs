//Task #3 - Shape abstract class
//This task contrasts with Task 2. There you used an interface (a contract only). Here you use an abstract class so subclasses can share state and helper logic.

//Create an abstract class Shape with two abstract methods:

//abstract double CalculateArea();
//abstract double CalculatePerimeter();
//Create three subclasses:

//Rectangle - fields Width, Height.
//Circle - field Radius.
//Triangle - fields SideA, SideB, SideC (use Heron's formula for area).
//Add a non -abstract method DisplayInfo() in the base Shape class that prints the shape's area and perimeter - this shows why an abstract class is useful (shared behavior across subclasses).

//In Program.cs, create one of each and call DisplayInfo() on them.

using Class02.Homework03.Domain.BaseEntity;
using Class02.Homework03.Domain.Models;

Rectangle rect = new() { Width = 5, Height = 3 };
Circle circ = new() { Radius = 4 };
Triangle tri = new() { SideA = 3, SideB = 4, SideC = 5 };


Shape[] shapes = new Shape[]
{
    rect, circ, tri
};
Console.WriteLine("Display Info method");
Console.ReadLine();
foreach (var shape in shapes)
{
    shape.DisplayInfo();
}
Console.ReadLine();
Console.WriteLine("Caulate Area and Perimeter methods:");
Console.ReadLine();

foreach (var shape in shapes)
{
    Console.WriteLine($"The {shape.GetType().Name} has an area value: {shape.CalculateArea()} and perimeter value: {shape.CalculatePerimeter()}");   
}
Console.ReadLine();
