using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Models;

public class Admin : User
{
    public Admin(string firstName, string lastName, string username, string password)
        :base(firstName, lastName, username, password)
    {
        Role = Role.Admin;
    }

    public Admin(string username, string password)
        :base(username, password)
    {
        Role = Role.Admin;
    }
}
