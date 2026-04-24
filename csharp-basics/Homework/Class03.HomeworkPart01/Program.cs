#region requirements exercise 3

//EXERCISE 3
//Declare 5 arrays with 5 elements in them:

//With words
//With decimal values
//With characters from keyboard
//With true/false values
//With arrays, each holding 2 whole numbers

#endregion

#region exercise 3 workspace

//words
using static System.Runtime.InteropServices.JavaScript.JSType;

string[] words = new string[] {"C#", "java", "C++", "python", "Ruby" };

//decimal values
double[] dNumbersValue = new double[5];

dNumbersValue[0] = 10.154;
dNumbersValue[1] = 0.123;
dNumbersValue[2] = -15.154;
dNumbersValue[3] = 010.154;
dNumbersValue[4] = 1210.11;

char[] cKeyboard = ['a', 'z', 'b', 'y', 'c'];

bool[] bValues = [true, false, true, true, true];

int[][] numbersArray = new int[][] 
{ 
    new int[] {1,2},
    new int[] {3,4},
    new int[] {4,5},
    new int[] {5,6},
    new int[] {7,8}
};


#endregion

#region exercise 4 requirements

//EXERCISE 4
//Declare a new array of integers with 5 elements
//Initialize the array elements with values from input
//Sum all the values and print the result in the console

#endregion

#region exercise 4 workspace

int[] exercise4IntArray = new int[5];
int sum = 0;

for (int i = 0; i < exercise4IntArray.Length; i++)
{
    Console.WriteLine("Please enter the " + (i + 1) + " number:");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int number))
    {
        exercise4IntArray[i] = number;
        sum += number;
    }
    else
    {
        Console.WriteLine("Invalid input, please restart the app and try again");
        break;
    }
}

Console.Write("The numbers inputed are: ");
for (int i = 0; i < exercise4IntArray.Length; i++)
{
    Console.Write(exercise4IntArray[i] + " ");
}

Console.WriteLine();
Console.WriteLine($"The sum of the numbers entered is: {sum}");
#endregion


#region exercise 5 requirements

//EXERCISE 5
//Create an array with names
//Give an option to the user to enter a name from the keyboard
//After entering the name put it in the array
//Ask the user if they want to enter another name(Y / N)
//Do the same process over and over until the user enters N
//Print all the names after user enters N

#endregion


#region exercise 5 WorkSpace

Console.WriteLine("Exercise 5");


string[] names = new string[10];
int index = 0;

string answer;

do
{
    Console.WriteLine("Please enter a name");

    if (index < names.Length)
    {
        names[index] = Console.ReadLine();
        index++;
    }

    //names[index] = Console.ReadLine();
    //index++;
    Console.WriteLine("Do you want to ener another name, enter: Y or N");
    answer = Console.ReadLine().ToUpper();

}
while (answer != "N");

//print
for (int i = 0; i < index; i++)
{
    Console.WriteLine(names[i]);
}




#endregion