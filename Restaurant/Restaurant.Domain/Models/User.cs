using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Models;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }


    public User(string firstName, string lastName, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
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
