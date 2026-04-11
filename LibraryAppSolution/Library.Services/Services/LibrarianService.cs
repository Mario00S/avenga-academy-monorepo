using Library.Domain;
using Library.Domain.Models;

namespace Library.Services.Services;

public class LibrarianService
{

    private DataAccess _dataAccess;

    public LibrarianService()
    {
        _dataAccess = new DataAccess();
    }

public Librarian? LibrarianLogin(string username, string password)
    {
        Librarian? librarianFromDb = _dataAccess.GetLibrarian(username,password);
        if (librarianFromDb == null)
        {
            throw new Exception("Invalid credentials. Try again!");
        }
        return librarianFromDb;
    }

public List<Member> GetAllMembers()
    {
        var getAllMembers = _dataAccess.GetAllMembers();
        return getAllMembers;
    }

    public string[] GetAllBooks()
    {
        return _dataAccess.GetAllBooks();
    }

}
