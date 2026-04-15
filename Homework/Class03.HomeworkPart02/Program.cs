#region task 1 requirements

//Task 1
//Make a console application called SumOfEven. Inside it create an array of 6 integers. 
//Get numbers from the input, find and print the sum of the even numbers from the array:

//Test Data:
//Enter integer no.1:
//4
//Enter integer no.2:
//3
//Enter integer no.3:
//7
//Enter integer no.4:
//3
//Enter integer no.5:
//2
//Enter integer no.6:
//8
//Expected Output:
//The result is: 14

#endregion


#region task 1 workspace

using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Task 1 - Sum of even");

int[] array1 = new int [6];
int sum = 0;


for (int i = 0; i < array1.Length; i++)
{
    Console.WriteLine($"Enter number: {i + 1} of 6");
    bool userInput1 = int.TryParse(Console.ReadLine(), out int userInt1);
    bool isValid1 = userInput1 && userInt1 >= 1 && userInt1 <= 999;

//Using while loop to repeat until a valid number is inputed
//Needed to copy the same logic 
    while (!isValid1)
    {
      Console.WriteLine("Please enter a valid number");
        userInput1 = int.TryParse(Console.ReadLine(), out userInt1);
        isValid1 = userInput1 && userInt1 >= 1 && userInt1 <= 999;
    }

        array1[i] = userInt1;

        if (userInt1 % 2 == 0)
        {
            sum += userInt1;
        }

}

Console.WriteLine($"The result is: {sum}");


#endregion

#region task 2 requirements

//Task 2
//Make a new console application called StudentGroup
//Make 2 arrays called studentsG1 and studentsG2 and fill them with 5 student names.
//Get a number from the console between 1 and 2 and print the students from that group in the console.
//Ex: studentsG1["Zdravko", "Petko", "Stanko", "Branko", "Trajko"]
//Test Data:
//Enter student group: (there are 1 and 2 )
//1
//Expected Output:
//The Students in G1 are:
//Zdravko
//Petko
//Stanko
//Branko
//Trajko
#endregion


#region task 2 WorkSpace
Console.WriteLine("============");
Console.WriteLine("Exercise no.2:");
Console.WriteLine("Entere a number: \\1 or 2\\ to access the required student group");
string[] studentsG1 = ["Jim", "John", "James", "Jack", "Jordan"];
string[] studentsG2 = ["Jenna", "Joana", "Julia", "Jaquline", "Jennifer"];

bool userInput2 = int.TryParse(Console.ReadLine(), out int userInt2);
bool isValidG1 = userInt2 == 1;
bool isValidG2 = userInt2 == 2;

if (isValidG1)
{
    Console.WriteLine("The students in G1 are:");
    foreach (var student in studentsG1)
    {
        Console.WriteLine(student);
    }
}
else if (isValidG2)
{
    Console.WriteLine("The students in G2 are:");
    foreach (string student in studentsG2)
    {
        Console.WriteLine(student);
    }
    
}
else
{
    Console.WriteLine("Invalid input");
}


#endregion