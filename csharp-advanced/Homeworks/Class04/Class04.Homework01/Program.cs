//Task 1
//Create class PrintInConsole that will have multiple methods to print in console: Print(), PrintCollection().
//Make these methods to be valid for more than one type and use them accordingly with different types.

//single Values
using Class04.Homework01.Models;

string message = "Hello";
int number = 42;
double price = 99.5;
char letter = 'A';
bool isActive = true;

Console.WriteLine("Printing single values using the Print method");
message.Print();
number.Print();
price.Print();
letter.Print();
isActive.Print();
Console.ReadLine();

//collections
List<string> names = new List<string> { "Ana", "Bob", "Elena" };
List<int> numbers = new List<int> { 1, 2, 3, 4 };
List<double> grades = new List<double> { 8.5, 9.0, 10.0 };
List<char> letters = new List<char> { 'X', 'Y', 'Z' };
Console.WriteLine("Printing the collections with the PrintCollection method");
names.PrintCollection();
numbers.PrintCollection();
grades.PrintCollection();
letters.PrintCollection();
Console.ReadLine();