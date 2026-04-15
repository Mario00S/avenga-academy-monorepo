
#region exercise 4
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Now executing Exercise number 4");
//EXERCISE 4
//On one tree there are 12 branches with n apples on them.
//One basket can hold m apples.

//n = 8
//m = 5
//If a user enters the number of trees, calculate how many baskets are needed to collect all apples.

int numOfBranches = 12;
int applesPerBranch = 8;
int applesPerTree = numOfBranches * applesPerBranch;
int basketCapacity = 5;

Console.WriteLine("Please enter the number of trees, (whole number)");
bool isParsedUserInput = int.TryParse(Console.ReadLine(), out int numOfUserTrees);



int totalApples = numOfUserTrees * applesPerTree;
// -1 makes exact divisions stay correct, while any leftover apples still add one more basket.
// Example: 95 apples = 19 baskets exactly, but 96 apples = 20 baskets, so -1 prevents exact cases from becoming too high.
int totalBaskets = (totalApples + basketCapacity - 1) / basketCapacity;


if (isParsedUserInput && numOfUserTrees > 0)
{
    Console.WriteLine("The user needs: " + totalBaskets + " number of baskets to collect all the apples");
    Console.WriteLine("The user has a total of: " + totalApples + " apples, and a total of: " + numOfUserTrees + " trees");
}
else
{
    Console.WriteLine("Invalid Input");
}

#endregion

#region exercise 5

//Create two variables and initialize them
//Determine which number is larger
//Determine whether the larger number is even or odd
//Output example:

//The larger number from the two is X
//And the number is even/odd

Console.WriteLine("This is exercise Number 5, you will need to enter two numbers in order to see which one is larger, and see if that number is even or odd");
Console.WriteLine("Please enter the first number");
bool ex5Input1 = int.TryParse(Console.ReadLine(), out int ex5Num1);
Console.WriteLine("Please enter the second number");
bool ex5Input2 = int.TryParse(Console.ReadLine(), out int ex5Num2);
int largerNumber;


if (ex5Input1 && ex5Input2)
{
    if (ex5Num1 == ex5Num2)
    {
        Console.WriteLine("The numbers are equal: " + ex5Num1);
    }
    else
    {
        if (ex5Num1 > ex5Num2)
        {
            largerNumber = ex5Num1;
        }
        else
        {
            largerNumber = ex5Num2;
        }

        Console.WriteLine("The larger number from the two is " + largerNumber);

        if (largerNumber % 2 == 0)
        {
            Console.WriteLine("And the number is even");
        }
        else
        {
            Console.WriteLine("And the number is odd");
        }
    }
}
else
{
    Console.WriteLine("Invalid Input");
}


#endregion

#region exercise 6

//EXERCISE 6
//Ask the user to enter a number from 1 to 3:

//1 → “You got a new car!”
//2 → “You got a new plane!”
//3 → “You got a new bike!”
//Any other input → error message

Console.WriteLine("Wellcome to exercise 6");
Console.WriteLine("Please enter a number from 1 to 3");
bool ex6UserInput = int.TryParse(Console.ReadLine(), out int ex6IntInput);

if (ex6UserInput)
{
    switch (ex6IntInput)
    {
        case 1:
            Console.WriteLine("You've got a new car!");
            break;
        case 2:
            Console.WriteLine("You've got a new plane!");
            break;
        case 3:
            Console.WriteLine("You've got a new bike!");
            break;
        default:
            Console.WriteLine("Please enter: 1, 2 or 3");
            break;
    }

}
else {
    Console.WriteLine("this is not a valid number");
}

#endregion