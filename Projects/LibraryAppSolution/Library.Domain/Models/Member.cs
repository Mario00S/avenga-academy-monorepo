using Library.Domain.Enums;

namespace Library.Domain.Models;

public class Member : User
{
    public string CurrentlyBorrowedBook { get; set; }
    public Dictionary<string, int> ReturnedBooksDaysKept { get; set; }

    public Member(string username, string password)
        :base(username, password)
    {
        Role = Role.Member;
    }

    public Member(string fName, string lName, string username, string password, int age)
        :base(fName, lName, username, password, age)
    {
        Role = Role.Member;
    }
}
