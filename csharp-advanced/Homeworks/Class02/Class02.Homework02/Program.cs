using Class02.Homework02.Domain.Interfaces;
using Class02.Homework02.Domain.Models;
//Task #2 - Shape interface
//Create an interface Shape with one method:

//double GetArea();
//Create three classes that implement Shape:

//Rectangle - fields Width, Height. Area = Width * Height.
//Circle - field Radius. Area = π * Radius².
//Triangle - fields Base, Height. Area = 0.5 * Base * Height.
//In Program.cs, store all three in a Shape[] array and print each area in a loop.

//declare variables
Rectangle newRectangle = new Rectangle
{ Height = 10.5,
  Width = 2      
};

Triangle newTriangle = new Triangle
{
    Base = 10.5,
    Height = 2
};

Circle newCircle = new Circle
{
    Radius = 10.5
};

Console.WriteLine($"The rectangle height is: {newRectangle.Height}, the width: {newRectangle.Width} and the area is:");
Console.WriteLine(newRectangle.GetArea());

Console.WriteLine($"The triangle base is {newTriangle.Base}, the height is {newTriangle.Height} and the area is:");
Console.WriteLine(newTriangle.GetArea());

Console.WriteLine($"The circle radius is {newCircle.Radius} and the area is: {newCircle.GetArea()}");

IShape[] allElements = { newRectangle, newTriangle, newCircle };

foreach (var element in allElements)
{
    Console.WriteLine($"{element.GetType().Name} {element.GetArea()}");
}