using Library.Domain;
using Library.Domain.Enums;
using Library.Domain.Models;

namespace Library.Services.Services;

public class AdminService
{
    private DataAccess _dataAccess;

    public AdminService()
    {
        _dataAccess = new DataAccess();
    }

    //Login
    public Admin? AdminLogin(string username, string password)
    {
        Admin? adminFromDb = _dataAccess.GetAdmin(username, password);
        if (adminFromDb == null)
        {
            throw new Exception("Invalid credentials. Try again!");
        }
        return adminFromDb;
    }

    public void CreateUser(string firstName, string lastName, string age, string username, string password, Role role)
    {
        bool userExists = _dataAccess.CheckIfUserExists(username, role);
        if (userExists)
        {
            throw new Exception($@"{role.ToString()} with ""{username}"" already exists!");
        }
        _dataAccess.CreateNewUser(firstName, lastName, age, username, password, role);
    }


    public void DeleteUser(string username, Role role)
    {
        bool userExists = _dataAccess.CheckIfUserExists(username, role);
        if (!userExists)
        {
            throw new Exception($"Cannot delete user that doesn't exists!");
        }
        _dataAccess.DeleteUser(username, role);
    }

    public List<string> GetUsersToRemove(Role role, Admin loggedAdmin)
    {
        return _dataAccess.GetUsernames(role, loggedAdmin);
    }


    public List<Admin> GetAllAdmins()
    {
        return _dataAccess.GetAllAdmins();
    }

    public List<Librarian> GetAllLibrarians()
    {
        return _dataAccess.GetAllLibrarians();
    }

    public List<Member> GetAllMembers()
    {
        return _dataAccess.GetAllMembers();
    }
}
