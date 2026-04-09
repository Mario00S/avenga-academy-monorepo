using Library.Domain.Enums;
using Library.Domain.Models;

namespace Library.Domain;

public class DataAccess
{

    private Database _db;

    public DataAccess()
    {
        _db = new Database();
    }

    public Admin? GetAdmin(string username, string password)
    {
        Admin? adminFromDb = _db.Admins
            .FirstOrDefault(x => x.Username == username && x.Password == password);
        return adminFromDb;
    }

    public Librarian? GetTrainer(string username, string password)
    {
        Librarian? librarianFromDb = _db.Librarians
            .FirstOrDefault(x => x.Username == username && x.Password == password);
        return librarianFromDb;
    }

    public Member? GetMember(string username, string password)
    {
        Member? memberFromDb = _db.Members
        .FirstOrDefault(x => x.Username == username && x.Password == password);
        return memberFromDb;
    }

    public bool CheckIfUserExists(string username, Role role)
    {
        switch (role)
        {
            case Role.Admin:
                return _db.Admins.Any(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
            case Role.Librarian:
                return _db.Librarians.Any(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
            case Role.Member:
                return _db.Members.Any(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
            default:
                return false;
        }
    }


    public List<string> GetUsernames(Role role, Admin loggedAdmin)
    {
        switch (role)
        {
            case Role.Admin:
                return _db.Admins.Where(x => x.Username != loggedAdmin.Username).Select(x => x.Username).ToList();
            case Role.Librarian:
                return _db.Librarians.Select(x => x.Username).ToList();
            case Role.Member:
                return _db.Members.Select(x => x.Username).ToList();
            default:
                throw new Exception("Error occured while retriving usernames from database");
        }
    }


    public void CreateNewUser(string firstName, string lastName, string age, string username, string password, Role role)
    {
        switch (role)
        {
            case Role.Admin:
                Admin newAdmin = new Admin(firstName, lastName, username, password, int.Parse(age));
                _db.Admins.Add(newAdmin);
                break;
            case Role.Librarian:
                Librarian newLibrarian = new Librarian(firstName, lastName, username, password, int.Parse(age));
                _db.Librarians.Add(newLibrarian);
                break;
            case Role.Member:
                Member newMember = new Member(firstName, lastName, username, password, int.Parse(age));
                _db.Members.Add(newMember);
                break;
            default:
                break;
        }

    }


    public bool DeleteUser(string username, Role role)
    {
        switch (role)
        {
            case Role.Admin:
                Admin? adminFromDb = _db.Admins
                    .FirstOrDefault(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                return _db.Admins.Remove(adminFromDb);
            case Role.Librarian:
                Librarian? librarianFromDb = _db.Librarians
    .FirstOrDefault(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                return _db.Librarians.Remove(librarianFromDb);
            case Role.Member:
                Member? memberFromDb = _db.Members
    .FirstOrDefault(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                return _db.Members.Remove(memberFromDb);
            default:
                return false;
        }
    }

}
