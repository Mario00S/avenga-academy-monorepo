using Library.Domain.Enums;

namespace Library.Domain.Models;

public class Admin : User
{
    public Admin(string fName, string lName, string username, string password, int age)
        :base(fName, lName, username, password, age)
    {
        Role = Role.Admin;
    }

    public Admin(string username, string password)
        :base(username, password)
    {
        Role = Role.Admin;
    }

}
