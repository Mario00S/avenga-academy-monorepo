using Class05.Homework.Models;

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