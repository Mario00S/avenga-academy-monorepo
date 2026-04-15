#region Part 1
#region part 1 requirements

//## Part 1: Basic Loops

//- [ ] **Task 1: Count from 1 to N**  
//Ask the user to enter a number. Print all numbers from `1` to that number.  
//Use a `for` loop.

//- [ ] **Task 2: Count Backwards**  
//Ask the user to enter a number. Print all numbers from that number down to `1`.  
//Use a `while` loop.

//- [ ] **Task 3: Print Even Numbers**  
//Ask the user to enter a number. Print all even numbers from `2` up to that number.

//- [ ] **Task 4: Print Odd Numbers**  
//Ask the user to enter a number. Print all odd numbers from `1` up to that number.
#endregion

#region Part 1 WorkSpace

#region part 1 Workspace - Task 1

using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Task #1");
Console.WriteLine("Enter a number: || It will print all numbers from `1` to that number");


bool userInput1 = int.TryParse(Console.ReadLine(), out int userIntNum);
Console.WriteLine("===========================");


if (userInput1 && userIntNum > 1 && userIntNum <= 999)
{

    for (int i = 1; i <= userIntNum; i++)
        Console.WriteLine(i);
}
else
{
    Console.WriteLine("Invalid Input");
}
#endregion


#region task 2 workspace

Console.WriteLine("=============================");
Console.WriteLine("Taks #2");
Console.WriteLine("Enter a number, in order to print all numbers from that number down to 1");


bool userInput2 = int.TryParse(Console.ReadLine(), out int userIntNum2);
int counter2 = userIntNum2;
Console.WriteLine("=============================");


if (userInput2 && userIntNum2 >= 1 && userIntNum2 <= 999)
{
    while (counter2 >= 1)
    {
        Console.WriteLine(counter2);
        counter2--;
    }
}
else
{
    Console.WriteLine("Invalid Input");
}

//for loop
//if (userInput2 && userIntNum2 > 1 && userIntNum2 <= 999) 
//{
//    for (int i = userIntNum2; i >= 1; i--)
//        Console.WriteLine(i);
//    }
//else
//{
//    Console.WriteLine("Invalid input");
//}
#endregion

#region task 3 Wrokspace

Console.WriteLine("===================");
Console.WriteLine("Task 3, Enter a number, All even numbers from 2 up to that number will be printed");

bool userInput3 = int.TryParse(Console.ReadLine(), out int userIntNum3);
Console.WriteLine("===================");

if (userInput3 && userIntNum3 >= 2 && userIntNum3 <= 999)
{
    for (int i = 2; i <= userIntNum3; i += 2)
    {
        Console.WriteLine(i);
    }

}
else
{
    Console.WriteLine("Invalid Input");
}
#endregion

#region task 4 Workspace

Console.WriteLine("===========");
Console.WriteLine("Task 4, Enter a number, All odd numbers from 1 up to that number will be printed");

bool userInput4 = int.TryParse(Console.ReadLine(), out int userIntNum4);
bool isValidTask4 = userInput4 && userIntNum4 >= 1 && userIntNum4 <= 999;
Console.WriteLine("===========");

if (isValidTask4)
{
    for (int i = 1; i <= userIntNum4; i += 2)
    {
        Console.WriteLine(i);
    }
}
else
{
    Console.WriteLine("Invalid input");
}




#endregion


#endregion
#endregion

#region Part 2
#region part 2 requirements

//- [ ] **Task 5: Skip Divisible Numbers**  
//Ask the user to enter a number. Print all numbers from `1` to that number, except numbers divisible by `3` or `7`.  
//Use `continue`.

//- [ ] **Task 6: Stop at 100**  
//Ask the user to enter a number. Print numbers from `1` up to that number.  
//If the counter reaches `100`, print `The limit is reached` and stop the loop.  
//Use `break`.

//- [ ] **Task 7: Valid Input with Do-While**  
//Ask the user to enter a number between `1` and `10`.  
//Keep asking until the user enters a valid number.  
//Use a `do-while` loop.

#endregion

#region Part 2 Workspace

#region Task 5

Console.WriteLine("==========");
Console.WriteLine("Task 5");
Console.WriteLine("Enter a number, Will print all numbers from 1 to that number except numbers divisible by 3 or 7");


bool userInput5 = int.TryParse(Console.ReadLine(), out int userIntNum5);
bool isValid5 = userInput5 && userIntNum5 >= 1 && userIntNum5 <= 999;
Console.WriteLine("==========");

if (isValid5)
{
    for (int i = 1; i < userIntNum5; i++)
    {
        if (i % 3 == 0 || i % 7 == 0)
        {
            continue;
        }
        Console.WriteLine(i);
    }


}
else
{
    Console.WriteLine("Invalid Input");
}




#endregion

#region Task 6
Console.WriteLine("==========");
Console.WriteLine("Task 6");
Console.WriteLine("Enter number, will print the numbers up to 100");

bool userInput6 = int.TryParse(Console.ReadLine(), out int userIntNum6);
bool isValid6 = userInput6 && userIntNum6 >= 1 && userIntNum6 <= 999;
Console.WriteLine("==========");

if (isValid6)
{
    for (int i = 1; i <= userIntNum6; i++)
    {
        if (i == 100)
        {
            Console.WriteLine("The limit is reached");
            break;
        }
        Console.WriteLine(i);
    }

}
else
{
    Console.WriteLine("Invalid Input");
}



#endregion

#region Task 7

Console.WriteLine("=========");
Console.WriteLine("Task 7");


int userIntNum7;
bool isValid7;



Console.WriteLine("=========");


do
{
    Console.WriteLine("Enter a number between 1 and 10");

    bool userInput7 = int.TryParse(Console.ReadLine(), out userIntNum7);
    isValid7 = userInput7 && userIntNum7 >= 1 && userIntNum7 <= 10;

    if (!isValid7)
    {
        Console.WriteLine("Invalid input");
    }

}
while (!isValid7);

#endregion

#endregion
#endregion


#region part 3

#region part 3 requirements

//- [ ] **Task 8: Sum of Numbers**  
//Ask the user to enter a number. Calculate and print the sum of all numbers from `1` to that number.

//- [ ] **Task 9: Multiplication Table**  
//Ask the user to enter a number. Print the multiplication table for that number from `1` to `10`.

//- [ ] **Task 10: Number Statistics**  
//Ask the user to enter `5` numbers one by one. At the end, print:
//  - how many are even
//  - how many are odd
//  - the total sum

//Do not use an array in this task.

#endregion

#region part 3 Workspace

#region task 8

Console.WriteLine("=========");
Console.WriteLine("Task 8");
Console.WriteLine("Please enter a number, it will print the sum of all numbers from `1` to that number");

bool userInput8 = int.TryParse(Console.ReadLine(), out int userIntNum8);
bool isValid8 = userInput8 && userIntNum8 >= 1 && userIntNum8 <= 999;

int sum8 = 0;

if (isValid8)
{
    for (int i = 1; i <= userIntNum8; i++)
    {
        sum8 += i;
    }
    Console.WriteLine("The sum is: " + sum8);
}
else
{
    Console.WriteLine("Invalid Input");
}


#endregion

#region task 9

Console.WriteLine("=========");
Console.WriteLine("Task 9");
Console.WriteLine("Enter a number, it will print the multiplication table for that number from 1 to 10");

bool userInput9 = int.TryParse(Console.ReadLine(), out int userIntNum9);
bool isValid9 = userInput9 && userIntNum9 >= 1 && userIntNum9 <= 10;
Console.WriteLine("=========");

if (isValid9)
{
    for (int i = 1; i < 10; i++)
    {
        int result = userIntNum9 * i;
        Console.WriteLine($"{userIntNum9} x {i} = {result}");
    }
}
else
{
    Console.WriteLine("Invalid Input");
}

#endregion

#region Task 9

Console.WriteLine("========");
Console.WriteLine("Task 10");
Console.WriteLine("Enter 5 numbers, it will make a sum of total, sum of even, sum of odd numbers");
int sum10 = 0;
int evenNumbers10 = 0;
int oddNumbers10 = 0;
Console.WriteLine("========");

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine("Enter number: " + i);
    bool userInput10 = int.TryParse(Console.ReadLine(), out int userIntNum10);
    bool isValid10 = userInput10 && userIntNum10 >= 1 && userIntNum10 <= 999;
    

    if (isValid10)
    {
       
        sum10 += userIntNum10;
    }

    if (userIntNum10 % 2 == 0)
    {
        evenNumbers10 += userIntNum10;
    }
    else
    {
        oddNumbers10 += userIntNum10;
    }

}
Console.WriteLine("Print sum: " + sum10);
Console.WriteLine("Print even: " + evenNumbers10);
Console.WriteLine("Print odd: " + oddNumbers10);





#endregion

#endregion


#endregion