using Class03.Homework01.Data;

while (true)
{
    UserDatabase.ListUsers();

    Console.WriteLine("\n1. Search by ID");
    Console.WriteLine("2. Search by Name");
    Console.WriteLine("3. Search by Age");
    Console.WriteLine("0. Exit");

    Console.WriteLine("Choose: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
                Console.Write("Enter ID: ");

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    User? userById = UserDatabase.Search(id);

                    if (userById != null)
                    {
                        Console.WriteLine($"Found: {userById.Name} (Age: {userById.Age})");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID input.");
                }

                break;
            }
        case "2":
            {
                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid input.");
                    break;
                }

                User? userByName = UserDatabase.Search(name);

                if (userByName != null)
                {
                    Console.WriteLine($"Found: {userByName.Name} (Age: {userByName.Age})");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }

                break;
            }
        case "3":
            {
                Console.Write("Enter Age: ");

                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    List<User> usersByAge = UserDatabase.SearchByAge(age);

                    if (usersByAge.Count > 0)
                    {
                        foreach (User user in usersByAge)
                        {
                            Console.WriteLine($"- {user.Name} (ID: {user.Id})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No users found with that age.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid age input.");
                }

                break;
            }
        case "0":
            return;
        default:
            break;
    }
    Console.WriteLine("\nPress any key...");
    Console.ReadKey();
}