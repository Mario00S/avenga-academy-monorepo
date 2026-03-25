#region exercise 3 requirements

//In the existing Console Application:

//Create a new method called Substrings
//Inside the method use the string:
//"Hello from Avenga Codecademy 2024"
//Ask the user to enter a number n
//Print the first n characters
//Print the length of the new string
//Try to handle all scenarios

#endregion

#region exercise 3 workSpace

using System.Globalization;

static void Substrings()
{
    string text = "Hello from Avenga Codecademy 2024";

   
    Console.WriteLine("Enter a number");
    Console.WriteLine($"The number can be from 1 up to {text.Length}");

    bool userInput = int.TryParse(Console.ReadLine(), out int userInt);

    if (userInput)
    {
        if (userInt >=1 && userInt <= text.Length)
        {
         string newText = text.Substring(0, userInt);
            Console.WriteLine($"The first {userInt} characters of the text are: {newText}");
            Console.WriteLine($"The text contains {newText.Length} characters");
        }
        else
        {
            Console.WriteLine("Please insert appropriate number");
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}

Substrings();
#endregion

#region exercise 4 requirements

//Print the date that is 3 days from now
//Print the date that is 1 month from now
//Print the date that is 1 month and 3 days from now
//Print the date 1 year and 2 months ago
//Print only the current month
//Print only the current year

#endregion

#region exercise 4 workSpace
Console.WriteLine("====================");
Console.WriteLine("Printing Dates");

DateTime todayDate = DateTime.Today;
Console.WriteLine($"The today's date is {todayDate}");
Console.WriteLine($"The date 3 days from now is {todayDate.AddDays(3)}");
Console.WriteLine($"The date that is 1 month from now is: \n {todayDate.AddMonths(1)}");
Console.WriteLine($"The date that is 1 month and 3 days from now is: \n {todayDate.AddDays(3).AddMonths(1)}");
Console.WriteLine($"The date 1 year and 2 months ago was: \n {todayDate.AddYears(-1).AddMonths(-2)}");
Console.WriteLine($"The current month is {todayDate.Month}");
Console.WriteLine($"The current year is {todayDate.Year}");


#endregion


#region homework.md Task requirements

//Make a method called AgeCalculator
//The method will have one input parameter, your birthday date
//The method should return your age
//Show the age of a user after he inputs a date
//Note: take into consideration if the birthday is today, after or before today

#endregion

#region homework.md task workspace

static int AgeCalculator(DateTime birthDate)
{
    
    DateTime today = DateTime.Today;
    int age = today.Year - birthDate.Year;

    if (today < birthDate.AddYears(age))
    {
        age--;
        //Console.WriteLine("The birthday has not happened this year");
    }

    //Console.WriteLine($"The user has {age} years");
    return age;
}

Console.WriteLine("Please insert your birth date in the following format: dd.MM.yyyy");
string userDateInput = Console.ReadLine();
bool userInput = DateTime.TryParseExact(userDateInput, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate);

if (userInput)
{
   int age = AgeCalculator(birthDate);
    Console.WriteLine($"The user has {age} years");
}
else
{
    Console.WriteLine("Invalid input");
}

#endregion
