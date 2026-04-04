
#region task 1

//Task 1
//Give the user an option to input numbers
//After inputing each number ask them if they want to input another with a Y/N question
//Store all numbers in a QUEUE
//When the user is done adding numbers print the number in the order that the user entered them from the QUEUE

//Console.WriteLine("Enter a number");

bool reply = true;

Queue<int> userNumbers = new Queue<int>();

while (reply)
{
    Console.WriteLine("Enter a number");
    bool userInput = int.TryParse(Console.ReadLine(), out int userInt);
    string userReply;

    if (userInt > 0)
    {
        
        userNumbers.Enqueue(userInt);
    }


    do
    {
        Console.WriteLine("Do you want to enter another number? Y/N");
        userReply = Console.ReadLine().ToUpper();

        if (userReply != "Y" && userReply != "N")
        {
            Console.WriteLine("Not valid, Please enter Y or N");
        }

    } while (userReply != "Y" && userReply != "N");

    if (userReply == "N")
    {
        reply = false;
    }


}

Console.WriteLine($"The numbers that the user entered are:");
foreach (int number in userNumbers)
{
    Console.Write($" {number}");
}

#endregion
