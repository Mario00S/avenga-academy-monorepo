using Restaurant.Domain;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Models;

namespace Restaurant.Services;

public class OrderService
{
    private DataAccess _dataAccess;

    public OrderService()
    {
        _dataAccess = new DataAccess();
    }

    public List<Order> GetAllOrders()
    {
        return _dataAccess.GetAllOrders();
    }

    public List<Order> GetActiveOrders()
    {
        return _dataAccess.GetActiveOrders();
    }

    public List<Order> GetCompletedOrders()
    {
        return _dataAccess.GetCompletedOrders();
    }

    public List<Order> GetOrdersByWaiter(Waiter waiter)
    {
        return _dataAccess.GetOrdersByWaiter(waiter);
    }

    public List<Order> GetOrdersByCustomer(Customer customer)
    {
        return _dataAccess.GetOrdersByCustomer(customer);
    }

    public Order CreateOrder(Customer customer, Waiter waiter, List<MenuItem> items)
    {
        if (customer == null)
        {
            throw new Exception("Customer cannot be null.");
        }

        if (waiter == null)
        {
            throw new Exception("Waiter cannot be null.");
        }

        if (items == null || items.Count == 0)
        {
            throw new Exception("Order must contain at least one menu item.");
        }

        int newOrderId = GenerateNewOrderId();

        Order newOrder = new Order(newOrderId, customer, waiter, items, OrderStatus.Active);

        _dataAccess.AddOrder(newOrder);

        return newOrder;
    }

    public Order? CompleteOrder(int orderId)
    {
        Order? order = _dataAccess.GetAllOrders()
            .FirstOrDefault(x => x.Id == orderId);

        if (order == null)
        {
            return null;
        }

        if (order.Status == OrderStatus.Completed)
        {
            return order;
        }

        order.Status = OrderStatus.Completed;
        return order;
    }

    private int GenerateNewOrderId()
    {
        List<Order> orders = _dataAccess.GetAllOrders();

        if (orders.Count == 0)
        {
            return 1;
        }

        int lastId = orders.Max(x => x.Id);
        return lastId + 1;
    }
}