using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Models;

public class Order
{
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Waiter Waiter { get; set; }
        public List<MenuItem> Items { get; set; } = new();
    public double TotalPrice  => Items.Sum(x => x.Price);
    public OrderStatus Status { get; set; }


    public Order(int id, Customer customer, Waiter waiter, List<MenuItem> items, OrderStatus status)
    {
        Id = id;
        Customer = customer;
        Waiter = waiter;
        Items = items;
        //TotalPrice = totalPrice;
        Status = status;
    }
}

