//using System.Diagnostics.Metrics;

//Task 2
//Create new console application called “AverageNumber” that takes four numbers as input to calculate and print the average.

//Test Data:
//Enter the First number: 10
//Enter the Second number: 15
//Enter the third number: 20
//Enter the four number: 30
//Expected Output:
//The average of 10, 15, 20 and 30 is: 18

Console.WriteLine("Welcome to the Average Number App");
Console.WriteLine("Please enter the first number");
bool firstInputNumber = int.TryParse(Console.ReadLine(), out int firstIntNumber);
Console.WriteLine("Please enter the second number");
bool secondInputNumber = int.TryParse(Console.ReadLine(), out int secondIntNumber);
Console.WriteLine("Please enter the third number");
bool thirdInputNumber = int.TryParse(Console.ReadLine(), out int thirdIntNumber);
Console.WriteLine("Please enter the fourth number");
bool fourthInputNumber = int.TryParse(Console.ReadLine(), out int fourthIntNumber);

int average = (firstIntNumber + secondIntNumber + thirdIntNumber + fourthIntNumber) / 4;
Console.WriteLine("the average number is: " + average);