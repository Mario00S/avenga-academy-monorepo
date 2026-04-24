using Restaurant.Domain.Enums;
using Restaurant.Domain.Models;

namespace Restaurant.Domain;

public class Database
{
    public List<Customer> Customers { get; set; } = new();
    public List<Waiter> Waiters { get; set; } = new();
    public List<MenuItem> MenuItems { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<Admin> Admins { get; set; }


    public Database()
    {
        SeedData();
    }


    private void SeedData()
    {
        Customers = new List<Customer>
    {
        new Customer("John", "Smith"),
        new Customer("Emily", "Johnson"),
        new Customer("Michael", "Brown"),
        new Customer("Sarah", "Davis"),
        new Customer("David", "Wilson"),
        new Customer("Jessica", "Moore"),
        new Customer("Daniel", "Taylor"),
        new Customer("Ashley", "Anderson"),
        new Customer("Matthew", "Thomas"),
        new Customer("Amanda", "Jackson")
    };

        Waiters = new List<Waiter>
{
    new Waiter("James", "Miller", "test123", "test123"),

    new Waiter("Olivia", "Martinez", "waiter1", "pass1")
    {
        WorkingDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Wednesday,
            DayOfWeek.Friday
        }
    },

    new Waiter("Ethan", "Garcia", "waiter2", "pass2")
    {
        WorkingDays = new List<DayOfWeek>
        {
            DayOfWeek.Tuesday,
            DayOfWeek.Thursday,
            DayOfWeek.Saturday
        }
    },

    new Waiter("Sophia", "Rodriguez", "waiter3", "pass3")
    {
        WorkingDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Sunday
        }
    },

    new Waiter("Noah", "Lee", "waiter4", "pass4")
    {
        WorkingDays = new List<DayOfWeek>
        {
            DayOfWeek.Wednesday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday
        }
    }
};

        Admins = new List<Admin>
    {
        new Admin("William", "Harris", "test123", "test123"),
        new Admin("Emma", "Clark", "admin1", "admin1"),
        new Admin("Benjamin", "Lewis", "admin2", "admin2")
    };

        MenuItems = new List<MenuItem>
    {
        new MenuItem("Burger", 250, MenuCategory.Food),
        new MenuItem("Pizza", 350, MenuCategory.Food),
        new MenuItem("Caesar Salad", 220, MenuCategory.Food),
        new MenuItem("Fries", 120, MenuCategory.Food),
        new MenuItem("Coke", 100, MenuCategory.Drink),
        new MenuItem("Water", 80, MenuCategory.Drink),
        new MenuItem("Coffee", 90, MenuCategory.Drink),
        new MenuItem("Ice Cream", 150, MenuCategory.Desert)
    };

        Orders = new List<Order>
    {
       new Order(1, Customers[0], Waiters[0], new List<MenuItem> { MenuItems[0], MenuItems[4] }, OrderStatus.Active),
new Order(2, Customers[1], Waiters[1], new List<MenuItem> { MenuItems[1], MenuItems[5] }, OrderStatus.Completed),
new Order(3, Customers[2], Waiters[2], new List<MenuItem> { MenuItems[2], MenuItems[6] }, OrderStatus.Active),
new Order(4, Customers[3], Waiters[3], new List<MenuItem> { MenuItems[0], MenuItems[3], MenuItems[4] }, OrderStatus.Completed),
new Order(5, Customers[4], Waiters[4], new List<MenuItem> { MenuItems[1], MenuItems[7] }, OrderStatus.Active),
new Order(6, Customers[5], Waiters[0], new List<MenuItem> { MenuItems[3], MenuItems[4], MenuItems[7] }, OrderStatus.Completed),
new Order(7, Customers[6], Waiters[1], new List<MenuItem> { MenuItems[2], MenuItems[5] }, OrderStatus.Active),
new Order(8, Customers[7], Waiters[2], new List<MenuItem> { MenuItems[0], MenuItems[1], MenuItems[5] }, OrderStatus.Completed),
new Order(9, Customers[8], Waiters[3], new List<MenuItem> { MenuItems[7], MenuItems[6] }, OrderStatus.Active),
new Order(10, Customers[9], Waiters[4], new List<MenuItem> { MenuItems[1], MenuItems[3], MenuItems[4] }, OrderStatus.Completed),
new Order(11, Customers[0], Waiters[2], new List<MenuItem> { MenuItems[7], MenuItems[5] }, OrderStatus.Completed),
new Order(12, Customers[3], Waiters[0], new List<MenuItem> { MenuItems[2], MenuItems[4], MenuItems[7] }, OrderStatus.Active)
    };
    }


}
