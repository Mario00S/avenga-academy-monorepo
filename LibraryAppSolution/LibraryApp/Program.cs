Console.WriteLine("Library App");
Console.WriteLine("================================");
Console.WriteLine("Enter the number to select the appropriate user:");
Console.WriteLine("\n1.Admin \n2.Librarian \n3.Member");

bool userChoice = int.TryParse(Console.ReadLine(), out int userRole);