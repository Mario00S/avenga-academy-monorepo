using Restaurant.Domain;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Models;
using Restaurant.Service;
using Restaurant.Services;

namespace Restaurant.App;

public class MenuController
{
    private AuthService _authService;
    private OrderService _orderService;
    private MenuItemService _menuItemService;
    private DataAccess _dataAccess;

    public MenuController()
    {
        _authService = new AuthService();
        _orderService = new OrderService();
        _menuItemService = new MenuItemService();
        _dataAccess = new DataAccess();
    }

    public void InitApp()
    {
        bool appRunning = true;

        while (appRunning)
        {
            Console.Clear();
            Console.WriteLine("=== RESTAURANT APP ===");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Guest Order");
            Console.WriteLine("0. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowStaffLoginMenu();
                    break;
                case "2":
                    ShowGuestOrderMenu();
                    break;
                case "0":
                    appRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    private void ShowStaffLoginMenu()
    {
        Console.Clear();
        Console.WriteLine("=== STAFF LOGIN ===");
        Console.WriteLine("1. Admin Login");
        Console.WriteLine("2. Waiter Login");
        Console.WriteLine("0. Back");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LoginAdmin();
                break;
            case "2":
                LoginWaiter();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid option.");
                Pause();
                break;
        }
    }

    private void LoginAdmin()
    {
        Console.Clear();
        Console.WriteLine("=== ADMIN LOGIN ===");

        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Admin? admin = _authService.LoginAdmin(username, password);

        if (admin == null)
        {
            Console.WriteLine("Invalid admin credentials.");
            Pause();
            return;
        }

        ShowAdminMenu(admin);
    }

    private void LoginWaiter()
    {
        Console.Clear();
        Console.WriteLine("=== WAITER LOGIN ===");

        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Waiter? waiter = _authService.LoginWaiter(username, password);

        if (waiter == null)
        {
            Console.WriteLine("Invalid waiter credentials.");
            Pause();
            return;
        }

        ShowWaiterMenu(waiter);
    }

    private void ShowAdminMenu(Admin admin)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine($"=== ADMIN MENU | {admin.FirstName} {admin.LastName} ===");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. View Active Orders");
            Console.WriteLine("3. View Completed Orders");
            Console.WriteLine("4. View Menu Items");
            Console.WriteLine("0. Logout");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintOrders(_orderService.GetAllOrders());
                    break;
                case "2":
                    PrintOrders(_orderService.GetActiveOrders());
                    break;
                case "3":
                    PrintOrders(_orderService.GetCompletedOrders());
                    break;
                case "4":
                    PrintMenuItems(_menuItemService.GetAllMenuItems());
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    private void ShowWaiterMenu(Waiter waiter)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine($"=== WAITER MENU | {waiter.FirstName} {waiter.LastName} ===");
            Console.WriteLine("1. View My Orders");
            Console.WriteLine("2. View Active Orders");
            Console.WriteLine("3. View Menu Items");
            Console.WriteLine("0. Logout");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintOrders(_orderService.GetOrdersByWaiter(waiter));
                    break;
                case "2":
                    PrintOrders(_orderService.GetActiveOrders());
                    break;
                case "3":
                    PrintMenuItems(_menuItemService.GetAllMenuItems());
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    private void ShowGuestOrderMenu()
    {
        Console.Clear();
        Console.WriteLine("=== GUEST ORDER ===");

        Customer? customer = CreateGuestCustomer();
        if (customer == null)
        {
            return;
        }

        List<MenuItem> selectedItems = SelectMenuItems();
        if (selectedItems.Count == 0)
        {
            Console.WriteLine("No items selected.");
            Pause();
            return;
        }

        Waiter assignedWaiter = _dataAccess.GetAllWaiters().First();

        Order newOrder = _orderService.CreateOrder(customer, assignedWaiter, selectedItems);

        Console.WriteLine();
        Console.WriteLine("Order created successfully.");
        Console.WriteLine($"Order Id: {newOrder.Id}");
        Console.WriteLine($"Customer: {newOrder.Customer.FirstName} {newOrder.Customer.LastName}");
        Console.WriteLine($"Waiter: {newOrder.Waiter.FirstName} {newOrder.Waiter.LastName}");
        Console.WriteLine($"Total: {newOrder.TotalPrice}");

        Pause();
    }

    private Customer? CreateGuestCustomer()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("First name and last name are required.");
            Pause();
            return null;
        }

        return new Customer(firstName, lastName);
    }

    private List<MenuItem> SelectMenuItems()
    {
        List<MenuItem> allItems = _menuItemService.GetAllMenuItems();
        List<MenuItem> selectedItems = new List<MenuItem>();

        Console.Clear();
        Console.WriteLine("=== MENU ITEMS ===");

        for (int i = 0; i < allItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allItems[i].Name} - {allItems[i].Price} den. - {allItems[i].Category}");
        }

        Console.WriteLine();
        Console.WriteLine("Enter item numbers separated by comma (example: 1,3,5):");

        string input = Console.ReadLine();
        string[] parts = input.Split(',');

        foreach (string part in parts)
        {
            bool isParsed = int.TryParse(part.Trim(), out int itemNumber);

            if (isParsed && itemNumber >= 1 && itemNumber <= allItems.Count)
            {
                selectedItems.Add(allItems[itemNumber - 1]);
            }
        }

        return selectedItems;
    }

    private void PrintMenuItems(List<MenuItem> items)
    {
        Console.Clear();
        Console.WriteLine("=== MENU ITEMS ===");

        foreach (MenuItem item in items)
        {
            Console.WriteLine($"{item.Name} - {item.Price} den. - {item.Category}");
        }

        Pause();
    }

    private void PrintOrders(List<Order> orders)
    {
        Console.Clear();
        Console.WriteLine("=== ORDERS ===");

        if (orders.Count == 0)
        {
            Console.WriteLine("No orders found.");
            Pause();
            return;
        }

        foreach (Order order in orders)
        {
            Console.WriteLine($"Id: {order.Id}");
            Console.WriteLine($"Customer: {order.Customer.FirstName} {order.Customer.LastName}");
            Console.WriteLine($"Waiter: {order.Waiter.FirstName} {order.Waiter.LastName}");
            Console.WriteLine($"Status: {order.Status}");
            Console.WriteLine($"Total: {order.TotalPrice}");
            Console.WriteLine("---------------------------");
        }

        Pause();
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}