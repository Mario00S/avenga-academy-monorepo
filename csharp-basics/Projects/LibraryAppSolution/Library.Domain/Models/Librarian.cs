using Library.Domain.Enums;

namespace Library.Domain.Models;

public class Librarian : User
{

    public Librarian(string fName, string lName, string username, string password, int age)
        :base(fName, lName, username, password, age)
    {
        Role = Role.Librarian;
    }

    public Librarian(string username, string password)
        :base(username, password)
    {
        Role = Role.Librarian;
    }

}
