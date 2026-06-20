using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Enums;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Services.Services;

namespace TaxiManager9000.App
{
    internal class TaxiManagerUI
    {
        private readonly IUIService _uiService;
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IDriverService _driverService;

        public TaxiManagerUI()
        {
            _uiService = new UIService();
            _userService = new UserService();
            _carService = new CarService();
            _driverService = new DriverService();

            SeedData();
        }

        public void InitApp()
        {
            while (true)
            {
                Console.Clear();
                #region Login Menu

                if (_userService.CurrentUser is null)
                {
                    try
                    {
                        ConsoleHelper.PrintTitle("\n\t*** Taxi Manager 9000 ***\n");
                        //int choice = _uiService.ChooseMenu(new List<string> { "Login", "Exit" });
                        int choice = _uiService.ChooseMenu(["Login", "Exit"]);
                        if (choice == -1)
                        {
                            ConsoleHelper.PrintError("Invalid choice! Try again.");
                            continue;
                        }
                        if (choice == 2) break;

                        // Login Menu
                        User inputUser = _uiService.LogInMenu();
                        _userService.LogIn(inputUser.Username, inputUser.Password);
                        ConsoleHelper.PrintSuccess($"Welcome [{_userService.CurrentUser.Role}] {_userService.CurrentUser.Username}!");
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.PrintError(ex.ToString());
                        continue;
                    }
                }
                #endregion

                #region Main Menu
                int menuChoiceNumber = _uiService.MainMenu(_userService.CurrentUser.Role);
                if (menuChoiceNumber == -1)
                {
                    ConsoleHelper.PrintError("Invalid choice! Try again...");
                    continue;
                }
                MenuChoice mainMenuChoce = _uiService.MenuItems[menuChoiceNumber - 1];
                switch (mainMenuChoce)
                {
                    case MenuChoice.AddNewUser:
                        ConsoleHelper.PrintInColor("=== Add New User", ConsoleColor.Cyan);
                        string username = ConsoleHelper.GetInput("Username: ");
                        if (!ValidationHelper.ValidateUsername(username))
                        {
                            ConsoleHelper.PrintError($"{username} nust have at least 5 characters!.");
                        }
                        string password = ConsoleHelper.GetInput("Password: ");
                        if (!ValidationHelper.ValidatePassword(password))
                        {
                            ConsoleHelper.PrintError($"{username} nust have at least 5 characters!.");
                        }
                        int role = _uiService.ChooseMenu(new List<string>()
                        {
                            "Administrator",
                            "Manager",
                            "Maintenance"
                        });

                        try
                        {
                            _userService.CreateNewUser(username, password, (Role)role);
                            ConsoleHelper.PrintSuccess("Successfully created new user.");
                        }
                        catch (Exception ex)
                        {
                            ConsoleHelper.PrintError(ex.Message);
                            continue;
                        }
                        break;
                    case MenuChoice.RemoveExistingUser:
                        ConsoleHelper.PrintInColor("===== Remove Existing User", ConsoleColor.DarkRed);
                        List<User> users = _userService.GetAll().Where(x => x.Id != _userService.CurrentUser.Id).ToList();
                        int menuChoice = _uiService.ChooseEntitiesMenu(users);
                        if (menuChoice == -1) continue;
                        _userService.Remove(users[menuChoice - 1].Id);
                        break;
                    case MenuChoice.ListAllDrivers:
                        ConsoleHelper.PrintInColor("===== List All Drivers", ConsoleColor.Blue);
                    //Not needed this is covered in the GetMenuChoice() method in the UiService
                        //if (_userService.CurrentUser.Role != Role.Manager)
                        //{
                        //    ConsoleHelper.PrintError("Access denied! Only managers can list all drivers.");
                        //    continue;
                        //}

                        List<Driver> drivers = _driverService.GetAll();
                        if (drivers.Count == 0)
                        {
                            ConsoleHelper.PrintError("No drivers found");
                            continue;
                        }
                        foreach (Driver driver in drivers)
                        {
                            ConsoleHelper.PrintInColor(
                                $"{driver.FirstName} {driver.LastName} | Shift: {driver.Shift} " +
                                $"| Car: {(driver.Car != null ? driver.Car.Model : "No car assigned")} " +
                                $"| License: {driver.License} | Expiry: {driver.LicenseExpieryDate.ToShortDateString()}", ConsoleColor.Cyan
                                );
                        }
                        Console.ReadLine();
                        break;
                    case MenuChoice.TaxiLicenseStatus:
                        ConsoleHelper.PrintInColor("===== Taxi License Status", ConsoleColor.Cyan);

                        List<Driver> driversLiscenceStatus = _driverService.GetAll();
                        if (driversLiscenceStatus.Count == 0)
                        {
                            ConsoleHelper.PrintError("No drivers found!");
                            continue;
                        }

                        foreach (Driver driver in driversLiscenceStatus)
                        {
                            var (consoleColor, statusLabel) = LicenseStatusHelper.GetLicenseStatus(driver.LicenseExpieryDate);

                            ConsoleHelper.PrintInColor(
                                $"[{statusLabel}] Driver {driver.FirstName} {driver.LastName} with license {driver.License} expiring on {driver.LicenseExpieryDate.ToShortDateString()}",
                                consoleColor
                            );
                        }
                        Console.ReadLine();
                        break;
                    case MenuChoice.DriverManager:
                        ConsoleHelper.PrintInColor("===== Driver Manager", ConsoleColor.Blue);
                        List<string> subMenu = new List<string>()
                            {
                                "Assign Unassigned Drivers",
                                "Unassign Assigned Drivers",
                                "Back to Main Menu"
                            };

                        int subChoice = _uiService.ChooseMenu(subMenu);

                        switch (subChoice)
                        {
                            case 1:
                                ConsoleHelper.PrintInColor("===== Assign Unassigned Drivers", ConsoleColor.Blue);
                                // Step 1: Get all unassigned drivers
                                List<Driver> unassignedDrivers = _driverService.GetUnassignedDrivers();
                                if (unassignedDrivers.Count == 0)
                                {
                                    ConsoleHelper.PrintError("No unassigned drivers available!");
                                    break;
                                }

                                // Step 2: Let manager pick a driver
                                int driverChoice = _uiService.ChooseEntitiesMenu(unassignedDrivers);
                                Driver chosenDriver = unassignedDrivers[driverChoice - 1];

                                // Step 3: Pick a shift
                                List<string> shifts = new List<string>() { "Morning", "Afternoon", "Evening" };
                                int shiftChoice = _uiService.ChooseMenu(shifts);
                                Shift chosenShift = (Shift)shiftChoice; // assuming enum values map correctly

                                // Step 4: List available cars (valid license + no driver in chosen shift)
                                List<Car> availableCars = _carService.GetAvailableCars(chosenShift);
                                if (availableCars.Count == 0)
                                {
                                    ConsoleHelper.PrintError("No available cars for this shift!");
                                    break;
                                }

                                int carChoice = _uiService.ChooseEntitiesMenu(availableCars);
                                Car chosenCar = availableCars[carChoice - 1];

                                // Step 5: Assign driver to car + shift
                                _driverService.AssignDriver(chosenDriver, chosenCar, chosenShift);

                                ConsoleHelper.PrintInColor(
                                    $"Successfully assigned {chosenDriver.FirstName} {chosenDriver.LastName} " +
                                    $"to {chosenCar.Model} in {chosenShift} shift!",
                                    ConsoleColor.Green
                                );
                                break;
                            case 2:
                                ConsoleHelper.PrintInColor("===== Unassign Unassigned Drivers", ConsoleColor.Blue);
                                // Step 1: Get all assigned drivers
                                List<Driver> assignedDrivers = _driverService.GetAll()
                                    .Where(d => d.Car != null && d.Shift != Shift.NoShift)
                                    .ToList();

                                if (assignedDrivers.Count == 0)
                                {
                                    ConsoleHelper.PrintError("No drivers are currently assigned!");
                                    break;
                                }

                                // Step 2: Let manager pick a driver
                                int driverChoiceCase2 = _uiService.ChooseEntitiesMenu(assignedDrivers);
                                Driver chosenDriverCase2 = assignedDrivers[driverChoiceCase2 - 1];

                                // Step 3: Unassign driver
                                _driverService.UnassignDriver(chosenDriverCase2);

                                ConsoleHelper.PrintInColor(
                                    $"Successfully unassigned {chosenDriverCase2.FirstName} {chosenDriverCase2.LastName}.",
                                    ConsoleColor.Green
                                );
                                break;
                            case 3:
                                ConsoleHelper.PrintInColor("===== Back to Main Menu", ConsoleColor.Blue);
                                continue;
                                //using continue to go back
                        }
                        break;
                    case MenuChoice.ListAllCars:
                        ConsoleHelper.PrintInColor("===== List All Cars", ConsoleColor.Cyan);

                        List<Car> cars = _carService.GetAll();
                        if (cars.Count == 0)
                        {
                            ConsoleHelper.PrintError("No cars found");
                            continue;
                        }
                        foreach (Car car in cars)
                        {
                            double percentage = _carService.GetShiftCoveragePercentage(car);

                            ConsoleHelper.PrintInColor(
                                $"{car.Id}) {car.Model} with License Plate {car.LicensePlate} and utilized {percentage:F0}%",
                                ConsoleColor.Green
                            );
                        }
                        Console.ReadLine();
                        break;
                    case MenuChoice.LicensePlateStatus:
                        ConsoleHelper.PrintInColor("===== License Plate Status", ConsoleColor.Cyan);
                        List<Car> carsStatus = _carService.GetAll();
                        if (carsStatus.Count == 0)
                        {
                            ConsoleHelper.PrintError("No cars found!");
                            continue;
                        }

                        foreach (Car car in carsStatus)
                        {
                            var (consoleColor, statusLabel) = LicenseStatusHelper.GetLicenseStatus(car.LicensePlateExpieryDate);

                            ConsoleHelper.PrintInColor(
                                $"[{statusLabel}] Car Id {car.Id} - Plate {car.LicensePlate} expiring on {car.LicensePlateExpieryDate.ToShortDateString()}",
                                consoleColor
                            );
                        }
                        Console.ReadLine();
                        break;
                    case MenuChoice.ChangePassword:
                        ConsoleHelper.PrintInColor("===== Change Password", ConsoleColor.Blue);
                        string oldPassword = ConsoleHelper.GetInput("Enter old password: ");
                        string newPassword = ConsoleHelper.GetInput("Enter new password: ");
                        if (!ValidationHelper.ValidateStringInput(newPassword) || !ValidationHelper.ValidateStringInput(oldPassword))
                        {
                            ConsoleHelper.PrintError("Please enter values!");
                            continue;
                        }
                        bool changeSucc = _userService.ChangePassword(oldPassword, newPassword);
                        if (changeSucc)
                        {
                            ConsoleHelper.PrintSuccess("Successfully changed password.");
                        }
                        else
                        {
                            ConsoleHelper.PrintError("Password change failed! Try again.");
                        }
                        break;
                    case MenuChoice.Exit:
                        ConsoleHelper.PrintInColor("===== Exit", ConsoleColor.Green);
                        _userService.CurrentUser = null;
                        continue;
                    default:
                        break;


                }
                #endregion
            }




        }
        private void SeedData()
        {
            User administrator = new User("bob123", "bob123", Role.Administrator);
            User manager = new User("JillWayne", "jillawesome1", Role.Manager);
            User manager2 = new User("manager123", "manager123", Role.Manager);
            User maintenances = new User("GregGregsky", "supergreg1", Role.Maintenance);
            User maintenances2 = new User("maint123", "maint123", Role.Maintenance);
            List<User> seedUsers = new List<User>() { administrator, manager, manager2, maintenances, maintenances2 };
            _userService.Seed(seedUsers);

            Car car1 = new Car("Auris (Toyota)", "AFW950", new DateTime(2024, 3, 1));   // expired (Red)
            Car car2 = new Car("Auris (Toyota)", "CKE480", new DateTime(2024, 4, 15));  // expired (Red)
            Car car3 = new Car("Transporter (Volkswagen)", "GZDR69", DateTime.Now.AddMonths(2)); // expires in 2 months (Yellow)
            Car car4 = new Car("Mondeo (Ford)", "5RIP283", DateTime.Now.AddMonths(3)); // expires in 3 months (Yellow)
            Car car5 = new Car("Premier (Peugeot)", "2AR9907", new DateTime(2027, 5, 9)); // valid far future (Green)
            Car car6 = new Car("Vito (Mercedes)", "6RND294", new DateTime(2027, 11, 11)); // valid far future (Green)

            List<Car> seedCars = new List<Car>() { car1, car2, car3, car4, car5, car6 };
            _carService.Seed(seedCars);


            Driver driver1 = new Driver("Romario", "Walsh", Shift.NoShift, null, "LC12456123", new DateTime(2023, 11, 5));
            Driver driver2 = new Driver("Kathleen", "Rankin", Shift.Morning, car1, "LC54435234", new DateTime(2022, 1, 12));
            Driver driver3 = new Driver("Ashanti", "Mooney", Shift.Evening, car1, "LC65803245", new DateTime(2022, 5, 19));
            Driver driver4 = new Driver("Zakk", "Hook", Shift.Afternoon, car1, "LC20897583", new DateTime(2023, 9, 28));
            Driver driver5 = new Driver("Xavier", "Kelly", Shift.NoShift, null, "LC15636280", new DateTime(2024, 6, 1));
            Driver driver6 = new Driver("Joy", "Shelton", Shift.Evening, car2, "LC47845611", new DateTime(2023, 7, 3));
            Driver driver7 = new Driver("Kristy", "Riddle", Shift.Morning, car3, "LC19006543", new DateTime(2026, 8, 12));
            Driver driver8 = new Driver("Stuart", "Mayer", Shift.Evening, car3, "LC53187767", new DateTime(2028, 10, 10));
            List<Driver> seedDrivers = new List<Driver>() { driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8 };
            _driverService.Seed(seedDrivers);


            // Assign drivers to cars and shifts properly, needed for the All Cars menu for the percentage calculation
            _driverService.AssignDriver(driver2, car1, Shift.Morning);
            _driverService.AssignDriver(driver3, car1, Shift.Evening);
            _driverService.AssignDriver(driver4, car1, Shift.Afternoon);
            _driverService.AssignDriver(driver6, car2, Shift.Evening);
            _driverService.AssignDriver(driver7, car3, Shift.Morning);
            _driverService.AssignDriver(driver8, car3, Shift.Evening);
            //needs to inherit from IServiceBase to get the Seed method
        }
    }

}