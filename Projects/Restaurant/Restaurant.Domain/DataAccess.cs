using Restaurant.Domain.Enums;
using Restaurant.Domain.Models;

namespace Restaurant.Domain;

public class DataAccess
{
    private Database _db;

    public DataAccess()
    {
        _db = new Database();
    }

    public Admin? GetAdmin(string username, string password)
    {
        Admin? adminFromDb = _db.Admins
            .FirstOrDefault(x => x.Username == username && x.Password == password);

        return adminFromDb;
    }

    public Waiter? GetWaiter(string username, string password)
    {
        Waiter? waiterFromDb = _db.Waiters
            .FirstOrDefault(x => x.Username == username && x.Password == password);

        return waiterFromDb;
    }

    public List<Waiter> GetAllWaiters()
    {
        return _db.Waiters;
    }

    public List<Admin> GetAllAdmins()
    {
        return _db.Admins;
    }

    public List<MenuItem> GetAllMenuItems()
    {
        return _db.MenuItems;
    }

    public List<Customer> GetAllCustomers()
    {
        return _db.Customers;
    }

    public List<Order> GetAllOrders()
    {
        return _db.Orders;
    }

    public List<Order> GetActiveOrders()
    {
        List<Order> activeOrders = _db.Orders
            .Where(x => x.Status == OrderStatus.Active)
            .ToList();

        return activeOrders;
    }

    public List<Order> GetCompletedOrders()
    {
        List<Order> completedOrders = _db.Orders
            .Where(x => x.Status == OrderStatus.Completed)
            .ToList();

        return completedOrders;
    }

    public List<Order> GetOrdersByWaiter(Waiter waiter)
    {
        List<Order> waiterOrders = _db.Orders
            .Where(x => x.Waiter == waiter)
            .ToList();

        return waiterOrders;
    }

    public List<Order> GetOrdersByCustomer(Customer customer)
    {
        List<Order> customerOrders = _db.Orders
            .Where(x => x.Customer == customer)
            .ToList();

        return customerOrders;
    }

    public void AddOrder(Order order)
    {
        _db.Orders.Add(order);
    }
}