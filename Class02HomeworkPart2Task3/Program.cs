//Task 3:
//Create new console application called “SwapNumbers”. Input 2 numbers from the console and then swap the values of 
//the variables so that the first variable has the second value and the second variable the first value. Please find example below:

//Test Data:
//Input the First Number: 5
//Input the Second Number: 8
//Expected Output:
//After Swapping:
//First Number: 8
//Second Number: 5

Console.WriteLine("Welcome to the app: SwapNumbers");

Console.WriteLine("Please enter the first number");
bool firstInputNumber = int.TryParse(Console.ReadLine(), out int firstIntNumber);
Console.WriteLine("Please enter the second number");
bool secondInputNumber = int.TryParse(Console.ReadLine(), out int secondIntNumber);

