using Class06.HomeworkPart01.Models;

#region requirements

//Task 3
//Create an ATM application. 
//A customer should be able to authenticate with card number and pin and should be greeted with a message greeting them by full name. After that they can choose one of the following:

//Balance checking
//Cash withdrawal
//Cash deposition
//In order for the ATM app to work we need Customers.

//Bonus: The balance and pin should not be public
//Bonus: Ask the customer if they want another action
//Bonus: Add an option to register a new card

//🧠 Design Hint – Separate Methods
//This task is too big for one method.
//Split it into logical parts:

//Authentication(card + pin)
//ATM menu
//Balance operations
//Deposit / Withdraw
//Repeating actions
//🤖 Copilot – Step by Step Guidance
//Step 1 – Customer model

//Create a Customer class with properties and methods that protect sensitive data.

//Step 2 – Seed data

//Create a collection of customers with predefined data.

//Step 3 – Authentication

//Create a method that authenticates a customer by card number and pin.

//Step 4 – ATM menu

//Create a method that displays ATM options and returns the selected action.

//Step 5 – Transactions

//Create separate methods for balance check, withdrawal and deposit.

//Step 6 – Program loop

//Add logic that allows the customer to perform multiple actions or log out.

//✅ Validation & Reflection
//Is the user input validated, so invalid values are not accepted?
//Is the ATM menu easy to extend with new options?


#endregion

#region workspace

Customer[] customers = new Customer[]
{
    new Customer("1111-2222-3333-4444", 1234, 500, "Mario"),
    new Customer("2222-3333-4444-5555", 1235, 1200, "Bob"),
    new Customer("11", 11, 10000, "Test")
};

//var checkBalance = customers[0].getBalance();
//Console.WriteLine($"The customer: {customers[0].getCustomerName()} has a balance of {customers[0].getBalance()}");

Customer? Authentication()
{
    int attempts = 0;
    

    while (attempts < 3)
    {
        bool foundCustomer = false;

        Console.WriteLine("Please enter your cardnumber");
        string cardNumberInput = Console.ReadLine();
        Console.WriteLine("Please enter your PIN");
        bool userPinInput = int.TryParse(Console.ReadLine(), out int pinNumberInput);

        foreach (Customer customer in customers)
        {
            if (userPinInput && cardNumberInput == customer.CardNumber && pinNumberInput == customer.getPin())
            {
                Console.WriteLine($"Welcome {customer.CustomerName}");
                //isAuthenticated = true;
                foundCustomer = true;
                return customer;
            }


        }

        if (!foundCustomer)
        {

            attempts++;
            Console.WriteLine($"Invalid input, remaining attempts: {3 - attempts}");
        }
    }
    Console.WriteLine("Too many unsuccessful attempts, the card has been blocked");
    return null;
}

Customer? authenticatedCustomer = Authentication();

if (authenticatedCustomer != null)
{
    Menu(authenticatedCustomer);
}


//double Withdraw(Customer authenticatedCustomer)
//{
//    bool withdrawInput = double.TryParse(Console.ReadLine(), out double withdrawInt);
//    double currentBalance = authenticatedCustomer.getBalance();
//    double withdrawnBalance = currentBalance - withdrawInt;


//    if (withdrawInput)
//    {
//        if (withdrawInt > 0 && withdrawInt <= currentBalance)
//        {
            
//            return withdrawnBalance;
//        }
//        else if(withdrawnBalance < currentBalance)
//        {
//            Console.WriteLine("No funds to withdraw");
//        }
//    }


//    return currentBalance;
//}



void Menu(Customer authenticatedCustomer)
{

    bool showMenu = true;

    while (showMenu)
    {

        Console.WriteLine("Select an action: \n1.Check Balance \n2.Withdraw \n3.Deposit \n4.Exit");
        bool userMenuInput = int.TryParse(Console.ReadLine(), out int menuInt);
        

        switch (menuInt)
        {
            case 1:
                Console.WriteLine($"Your balance is: {authenticatedCustomer.getBalance()}");
                break;
            case 2:
                Console.WriteLine("Insert a sum that you want to withdraw: ");
                bool withdrawTemp = double.TryParse(Console.ReadLine(), out double withdrawDoubleValue);
                Console.WriteLine($"You current balance is: {authenticatedCustomer.Withdraw(withdrawDoubleValue)} ");
                break;
            case 3:
                Console.WriteLine("Insert a sum that you want to deposit: ");
                bool depositTemp = double.TryParse(Console.ReadLine(), out double depositDoubleValue);
                Console.WriteLine($"Your current Balance is: {authenticatedCustomer.Deposit(depositDoubleValue)}");
                break;
            case 4:
                showMenu = false;
                Console.WriteLine("Always with you, the best bank in the world");
                break;

            default:
                Console.WriteLine("invalid option");
                break;

        }
    }


}




#endregion