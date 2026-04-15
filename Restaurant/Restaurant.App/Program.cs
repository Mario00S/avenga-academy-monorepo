using Restaurant.App;
using Restaurant.Domain;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Models;
using Restaurant.Services;
Console.WriteLine("============================================================TEst");

DataAccess dataAccess = new DataAccess();

Admin? admin = dataAccess.GetAdmin("test123", "test123");
Waiter? waiter = dataAccess.GetWaiter("test123", "test123");

Console.WriteLine(admin != null ? "Admin login works" : "Admin login failed");
Console.WriteLine(waiter != null ? "Waiter login works" : "Waiter login failed");

Console.WriteLine($"Customers count: {dataAccess.GetAllCustomers().Count}");
Console.WriteLine($"Menu items count: {dataAccess.GetAllMenuItems().Count}");
Console.WriteLine($"Orders count: {dataAccess.GetAllOrders().Count}");
Console.WriteLine($"Active orders count: {dataAccess.GetActiveOrders().Count}");
Console.WriteLine($"Completed orders count: {dataAccess.GetCompletedOrders().Count}");

Console.WriteLine("============================================================TEst");

MenuController menuController = new MenuController();
menuController.InitApp();