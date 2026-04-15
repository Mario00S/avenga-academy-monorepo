#region requirements
//Task 1
//Create new console application called“RealCalculator” that takes two numbers from the input and asks what operation would the user want to be done ( +, - , * , / ). Then it returns the result.

//Test Data:
//Enter the First number: 10
//Enter the Second number: 15
//Enter the Operation: +
//Expected Output:
//The result is: 25
#endregion

#region workSpace

Console.WriteLine("Welcome to the Real Calculator");
Console.WriteLine("In order to execute the operations of the calculator, follow the instructions");

//number1
Console.WriteLine("Enter the first number");
bool firstNumberInput = int.TryParse(Console.ReadLine(), out int firstIntNumber);
//operator
Console.WriteLine("Enter one of the following operators: \n (+, -, *, /)");
//using if statement in order to remove the null warning, the workaround is to return an empty string instead
string cOperator = Console.ReadLine() ?? "";
//number2
Console.WriteLine("Enter the second Number");
bool secondNumberInput = int.TryParse(Console.ReadLine(), out int secondIntNumber);



if (firstNumberInput && secondNumberInput)
{
    switch (cOperator)
    {
        case "+":
            Console.WriteLine("The result is: " + (firstIntNumber + secondIntNumber));
            break;
        case "-":
            Console.WriteLine("The result is: " + (firstIntNumber - secondIntNumber));
            break;
        case "*":
            Console.WriteLine("The result is: " + (firstIntNumber * secondIntNumber));
            break;
        case "/":
            if (secondIntNumber != 0)
            Console.WriteLine("The result is: " + (firstIntNumber / secondIntNumber));
            else
                Console.WriteLine("Cannot divide by zero");
                break;   
        default:
            Console.WriteLine("Invalid Operator");
            break;
    }

}
else
{
    Console.WriteLine("Invalid input number");
}
#endregion