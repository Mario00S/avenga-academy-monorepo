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

Console.WriteLine("Task 01");
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

//Task 2
//Create a class Vehicle that has one method DisplayInfo().
//Create class Car, MotorBike, Boat, Airplane that will inherit from Vehicle and will implement the respective method.
//Vehicle car = new Car();
//Vehicle motorBike = new MotorBike();
//Vehicle boat = new Boat();
//Vehicle plane = new Airplane();

//car.DisplayInfo();
//motorBike.DisplayInfo();
//boat.DisplayInfo();
//plane.DisplayInfo()

//// in console we should display
//// Im a car and i drive on 4 wheels :)
//// Im a motorbike and i drive on 2 wheels :)
//// Im a boat and i do not have wheels :(
//// Im a plane i have couple of wheels :)
Console.WriteLine("Task 02");
Vehicle car = new Car();
Vehicle motorBike = new MotorBike();
Vehicle boat = new Boat();
Vehicle plane = new Airplane();

car.DisplayInfo();
motorBike.DisplayInfo();
boat.DisplayInfo();
plane.DisplayInfo();

//Task 3
//From the previous task get the implementation and DO NOT CHANGE the implementation of the classes.
//Now we need to EXTEND the functionalities with a couple of methods:
//Car objects should have Drive() method;
//MotorBike should have Wheelie() method;
//Boat should have Sail() method;
//Airplane should have Fly() method;
//// this goes after the code from the previous task
//car.Drive();
//motorBike.Wheelie();
//boat.Sail();
//plane.Fly();
////Console output
//// The car is driving
//// The motorbike is driving on one wheel
//// The boat is sailing
//// The airplane is flying

Console.WriteLine("Extension methods");
car.Drive();
motorBike.Wheelie();
boat.Sail();
plane.Fly();
Console.ReadLine();

Console.WriteLine("Extension methods, wrong intentonally");
car.Fly();
car.Sail();
motorBike.Fly();
boat.Wheelie();
plane.Drive();
plane.Sail();
Console.ReadLine();