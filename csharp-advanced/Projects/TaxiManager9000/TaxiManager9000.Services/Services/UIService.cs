using TaxiManager9000.Domain.Models;
using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class UIService : IUIService
    {
        public int ChooseMenu<T>(List<T> items) // ["Login", "Exit"]
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {items[i]}");
            }
            int choice = ValidationHelper.ValidateNumberInput(Console.ReadLine(), items.Count);
            return choice;
        }

        public User LogInMenu()
        {
            Console.Clear();
            ConsoleHelper.PrintInColor("Enter your credentials:", ConsoleColor.Cyan);
            string? username = ConsoleHelper.GetInput("Username: ");
            string? password = ConsoleHelper.GetInput("Password: ");
            if (!ValidationHelper.ValidateStringInput(username) || !ValidationHelper.ValidateStringInput(password))
            {
                throw new Exception("Please enter valid inputs!");
            }

            return new User
            {
                Username = username,
                Password = password
            };
        }
    }
}
