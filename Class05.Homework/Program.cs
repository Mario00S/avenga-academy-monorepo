using Class05.Homework.Models;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

#region Exercise 1 requirements

//Create a class Human.

//Add properties:

//FirstName
//LastName
//Age
//Create a method GetPersonStats that:

//Returns the full name
//Returns the age
//Ask the user for input, create an object and print the result in the console.

#endregion

#region Exercise 1 workSpace

Console.WriteLine("Please enter your Name, Last Name and Age");

Console.WriteLine("Enter your First Name");
string personFirstName = Console.ReadLine();
Console.WriteLine("Enter your Last Name");
string personLastName = Console.ReadLine();
Console.WriteLine("Enter your age");
bool personAge = int.TryParse(Console.ReadLine(), out int personAgeInt);

Console.WriteLine("Press Enter to reveal your details");
Console.ReadLine();
Human newPerson = new Human(personFirstName, personLastName, personAgeInt);

Console.WriteLine(newPerson.GetPersonStats());

#endregion

#region Exercise 2 Requirements
//Create a class Dog.

//Add properties:

//Name
//Race
//Color
//Add methods:

//Eat → prints “The dog is now eating.”
//Play → prints “The dog is now playing.”
//ChaseTail → prints “The dog is now chasing its tail.”
//Ask the user to:

//Enter dog data
//Choose one of the actions
//Call the selected method.

#endregion

#region Exercise 2 Workspace

Console.WriteLine("==========");
Console.WriteLine("Enter dog data: name // race // color \n enter name:");
string dogName = Console.ReadLine();
Console.WriteLine("Enter dog's race:");
string dogRace = Console.ReadLine();
Console.WriteLine("Enter dog's color:");
string dogColor = Console.ReadLine();

Dog newDog = new Dog(dogName, dogRace, dogColor);

Console.WriteLine(newDog.Play());
Console.WriteLine(newDog.Eat());
Console.WriteLine(newDog.ChaseTail());

#endregion

#region Exercise 3 requirements

//Create a class Student with properties:

//Name
//Academy
//Group
//Create an array with 5 Student objects.

//Ask the user to enter a name:

//If the student exists → print the information
//If not → print an error message

#endregion

#region Exercise 3 Workspace

Student[] students = new Student[5];

Student firstStudent = new Student("Aron", "Avenga Academy", "G1");
students[0] = firstStudent;
Student secondStudent = new Student("Bob", "Seavus Academy", "G2");
students[1] = secondStudent;
Student thirdStudent = new Student("Caroline", "Qunshift Academy", "G3");
students[2] = thirdStudent;
Student fourthStudent = new Student("Dan", "Avenga Academy", "G1");
students[3] = fourthStudent;
Student fifthStudent = new Student("Elizabeth", "Avenga Academy", "G1");
students[4] = fifthStudent;

Console.WriteLine("==========");
Console.WriteLine("Please enter a student name:");

bool studentFound = false;
string studentNameInput = Console.ReadLine();


foreach (Student student in students)
{
    if (student.Name == studentNameInput)
    {
        studentFound = true;
        Console.WriteLine($"The student: {student.Name} is a enroled at the {student.Academy} academy in the {student.Group} group");
        break;
    }
}


if (studentFound == false)
{
    Console.WriteLine("No such student");
}


#endregion