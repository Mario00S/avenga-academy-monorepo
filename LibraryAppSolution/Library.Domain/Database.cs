using Library.Domain.Models;
namespace Library.Domain;

public class Database
{
    public List<Admin> Admins { get; set; } = new List<Admin>();
    public List<Librarian> Librarians { get; set; } = new List<Librarian>();
    public List<Member> Members { get; set; } = new List<Member>();

    public string[] Books { get; set; } = 
        {"The Hobbit",
        "1984",
        "Pride and Prejudice",
        "The Great Gatsby",
        "Moby Dick",
        "Harry Potter",
        "The Alchemist"
    };

    public Database()
    {
        SeedData();
    }


    private void SeedData()
    {
        var books = Books;

        Admins = new List<Admin>()
    {
        new Admin("Michael", "Smith", "msmith123", "msmith123", 28),
        new Admin("John", "Johnson", "jjohnson123", "jjohnson123", 23),
        new Admin("David", "Brown", "dbrown123", "dbrown123", 32),
        new Admin("James", "Miller", "jmiller123", "jmiller123", 31),
    };

        Librarians = new List<Librarian>()
    {
        new Librarian("Emily", "Davis", "edavis123", "edavis123", 26),
        new Librarian("Sarah", "Wilson", "swilson123", "swilson123", 29),
    };

        Members = new List<Member>()
    {
        new Member("Jennifer", "Taylor", "jtaylor123", "jtaylor123", 20)
        {
            CurrentlyBorrowedBook = books[1],
            ReturnedBooksDaysKept = new Dictionary<string, int>()
            {
                { books[3], 12 },
                { books[2], 9 },
                { books[0], 15 },
            }
        },

        new Member("Matthew", "Anderson", "manderson123", "manderson123", 22)
        {
            CurrentlyBorrowedBook = books[4],
            ReturnedBooksDaysKept = new Dictionary<string, int>()
            {
                { books[1], 7 },
                { books[0], 10 },
            }
        },

        new Member("Jessica", "Thomas", "jthomas123", "jthomas123", 28)
        {
            CurrentlyBorrowedBook = books[6],
            ReturnedBooksDaysKept = new Dictionary<string, int>()
            {
            }
        },

        new Member("Daniel", "Moore", "dmoore123", "dmoore123", 35)
        {
            CurrentlyBorrowedBook = books[5],
            ReturnedBooksDaysKept = new Dictionary<string, int>()
            {
                { books[6], 14 },
                { books[4], 21 },
                { books[3], 8 },
                { books[1], 11 },
            }
        },

        new Member("Amanda", "Jackson", "ajackson123", "ajackson123", 19)
        {
            CurrentlyBorrowedBook = books[2],
            ReturnedBooksDaysKept = new Dictionary<string, int>()
            {
                { books[0], 6 },
                { books[3], 10 },
            }
        }
    };
    }

}
