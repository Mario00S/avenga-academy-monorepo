using TaxiManager9000.Domain.BaseEntity;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Enums;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class UIService : IUIService
    {
        private List<MenuChoice> _menuItems;
        public List<MenuChoice> MenuItems
        {
            get => _menuItems;
            set
            {
                if (_menuItems != null)
                {
                    _menuItems.Clear();
                }
                _menuItems = value;
            }
        }

        public int ChooseEntitiesMenu<T>(List<T> entities) where T : BaseEntity
        {
            while (true)
            {
                Console.WriteLine("Enter a number to choose one of the following:");
                for (int i = 0; i < entities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {entities[i].GetInfo()}");
                }
                int choise = ValidationHelper.ValidateNumberInput(Console.ReadLine(), entities.Count);
                if (choise == -1)
                {
                    ConsoleHelper.PrintError("Invalid choice! Try again..");
                    Console.Clear();
                    continue;
                }
                return choise;
            }
        }

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

        public int MainMenu(Role role)
        {
            while (true)
            {
                Console.Clear();
                ConsoleHelper.PrintTitle($"====== [{role.ToString()}] MENU ========");
                MenuItems = GetMenuOptionsForRole(role);
                int userChoice = ChooseMenu(MenuItems);
                if (userChoice == -1)
                {
                    ConsoleHelper.PrintError("Invalid choice! Try again...");
                    continue;
                }
                return userChoice;
            }
        }

        private List<MenuChoice> GetMenuOptionsForRole(Role role)
        {
            List<MenuChoice> menuItems = new List<MenuChoice>();
            switch (role)
            {
                case Role.Administrator:
                    menuItems = new List<MenuChoice>()
                    {
                        MenuChoice.AddNewUser,
                        MenuChoice.RemoveExistingUser,
                        MenuChoice.ChangePassword,
                        MenuChoice.Exit
                    };
                    break;
                case Role.Manager:
                    menuItems = new List<MenuChoice>()
                    {
                        MenuChoice.ListAllDrivers,
                        MenuChoice.TaxiLicenseStatus,
                        MenuChoice.DriverManager,
                        MenuChoice.ChangePassword,
                        MenuChoice.Exit
                    };
                    break;
                case Role.Maintenance:
                    menuItems = new List<MenuChoice>()
                    {
                        MenuChoice.ListAllCars,
                        MenuChoice.LicensePlateStatus,
                        MenuChoice.ChangePassword,
                        MenuChoice.Exit
                    };
                    break;
                default:
                    menuItems = new List<MenuChoice>();
                    break;
            }
            return menuItems;
        }
    }
}