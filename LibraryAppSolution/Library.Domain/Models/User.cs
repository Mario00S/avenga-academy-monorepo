using Library.Domain.Enums;

namespace Library.Domain.Models;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public User(string fName, string lName, string username, string password, int age)
    {
        FirstName = fName;
        LastName = lName;
        Username = username;
        Password = password;
        Age = age;
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}
