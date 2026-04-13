using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Models;

public class Waiter : User
{
    public bool OnShift { get; set; }

    public Waiter(string firstName, string lastName, string username, string password)
        :base(firstName, lastName, username, password)
    {
        Role = Role.Waiter;
        OnShift = false;
    }

    public Waiter(string username, string password)
        :base(username, password)
    {
        Role = Role.Waiter;
    }

}
