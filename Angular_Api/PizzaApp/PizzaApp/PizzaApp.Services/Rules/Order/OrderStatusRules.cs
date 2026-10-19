using PizzaApp.Domain.Enums;

namespace PizzaApp.Services.Rules.Order;

public static class OrderStatusRules
{
    public static bool CanChange(OrderStatus currentStatus, OrderStatus newStatus, bool isAdmin)
    {
        if (!isAdmin)
        {
            return currentStatus == OrderStatus.Pending && newStatus == OrderStatus.Cancelled;
        }

        return (currentStatus, newStatus) switch
        {
            (OrderStatus.Pending, OrderStatus.Preparing) => true,
            (OrderStatus.Preparing, OrderStatus.Delivered) => true,
            (OrderStatus.Pending or OrderStatus.Preparing, OrderStatus.Cancelled) => true,
            _ => false,
        };
    }
}
