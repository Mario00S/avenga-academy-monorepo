using Library.Domain.Enums;
using Library.Domain.Models;
using Library.Services;
using Library.Services.Services;

namespace Library.App.Controller;

public class MenuController
{

    private Utils _utils;
    private AdminService _adminService;
    private LibrarianService _librarianService;
    private MemberService _memberService;


    public MenuController(
    Utils utils,
    AdminService adminService,
    LibrarianService librarianService,
    MemberService memberService)
    {
        _utils = utils ?? throw new ArgumentNullException(nameof(utils));
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _librarianService = librarianService ?? throw new ArgumentNullException(nameof(librarianService));
        _memberService = memberService ?? throw new ArgumentNullException(nameof(memberService));
    }


    public bool InitApp()
    {

        try
        {
            WelcomeMenu();
            int choice = _utils.GetValidOption(new int[] { 1, 2, 3 });

            Console.Clear();
            WriteInColor($"Welcome {(Role)choice}. Enter your credentials:\n", ConsoleColor.DarkCyan);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter username:");
            string username = _utils.GetStringInput();
            Console.WriteLine("Enter password:");
            string password = _utils.GetStringInput();
            Console.ResetColor();

            switch ((Role)choice)
            {
                case Role.Admin:
                    Admin? loggedAdmin = _adminService.AdminLogin(username, password);
                    WriteInColor($"Hello admin {loggedAdmin.GetFullName()}", ConsoleColor.Green);
                    while (!AdminUI(loggedAdmin)) ;
                    break;
                case Role.Librarian:
                    Librarian? loggedLibrarian = _librarianService.LibrarianLogin(username, password);
                    WriteInColor($"Hello librarian: {loggedLibrarian.GetFullName()}", ConsoleColor.Green);
                    while (!LibrarianUI(loggedLibrarian)) ;
                    break;
                case Role.Member:
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            WriteInColor(ex.Message, ConsoleColor.Red);
        }


        WriteInColor("Do you want to exit? 1.Yes 2.No", ConsoleColor.DarkCyan);
        int exitChoice = _utils.GetValidOption(new[] { 1, 2 });

        if (exitChoice == 1)
        {
            return true;
        }
        return false;
    }


    public bool AdminUI(Admin loggdInAdmin)
    {
        try
        {
            AdminMainMenu();
            int adminChoice = _utils.GetValidOption(new int[] { 1, 2, 3, 4 });
            if (adminChoice == 4)
            {
                return true;
            }
            bool adminActionCompleted = AdminActionMenu((Role)adminChoice, loggdInAdmin);
            if (!adminActionCompleted)
            {
                return false;
            }
            Console.ReadLine();
            WriteInColor("Would you like to continue? (Y/N)", ConsoleColor.DarkCyan);
            string input = _utils.GetStringInput();
            if (input.ToLower() == "y")
            {
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            WriteInColor(ex.Message, ConsoleColor.Red);
        }
        return false;
    }

    public void AdminMainMenu()
    {
        Console.Clear();
        WriteInColor("Welcome to the Admin menu.", ConsoleColor.DarkCyan);
        WriteInColor("\nSelect option: \n1. Manage Admins \n2. Manage Librarians \n3. Manage Members \n4. Logout", ConsoleColor.Cyan);
    }

    public bool AdminActionMenu(Role role, Admin loggedAdmin)
    {
        Console.Clear();
        WriteInColor($"Manage {role} menu.", ConsoleColor.DarkCyan);
        WriteInColor("\nSelect Action: \n1. Add \n2. Remove \n3. View users \n4. Go back", ConsoleColor.Cyan);
        int adminActionChoice = _utils.GetValidOption(new int[] { 1, 2, 3, 4 });
        switch (adminActionChoice)
        {
            case (int)AdminAction.CreateUser:
                CreateUserMenu(role);
                break;
            case (int)AdminAction.DeleteUser:
                DeleteUserMenu(role, loggedAdmin);
                break;
            case 3:
                ViewUsersMenu(role);
                break;
            case 4:
                return false;
        }
        return true;
    }


    public void CreateUserMenu(Role role)
    {
        Console.Clear();
        WriteInColor($"Enter new {role.ToString().ToLower()} data", ConsoleColor.DarkCyan);
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("Firstname:");
        string firstName = _utils.GetStringInput();

        Console.WriteLine("Lastname:");
        string lastname = _utils.GetStringInput();

        Console.WriteLine("Age:");
        string age = _utils.GetStringInput();

        Console.WriteLine("Username:");
        string username = _utils.GetStringInput();

        Console.WriteLine("Password:");
        string password = _utils.GetStringInput();

        Console.ResetColor();

        _adminService.CreateUser(firstName, lastname, age, username, password, role);

        WriteInColor($"\nUser {username} successfully created!", ConsoleColor.Green);
    }

    public void DeleteUserMenu(Role role, Admin loggedAdmin)
    {
        Console.Clear();
        WriteInColor($"Choose which {role} to delete:\n", ConsoleColor.DarkCyan);
        List<string> users = _adminService.GetUsersToRemove(role, loggedAdmin);
        if (users.Count == 0)
        {
            WriteInColor($"\nNo {role}'s available at the moment for deleting!", ConsoleColor.DarkYellow);
            return;
        }
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i]}");
        }
        int userToDeleteChoice = _utils.GetValidOption(Enumerable.Range(1, users.Count).ToArray());
        string selectedUser = users[userToDeleteChoice - 1];
        _adminService.DeleteUser(selectedUser, role);
        WriteInColor(@$"Successfully deleted {role}: ""{selectedUser}""", ConsoleColor.Green);
    }


    public void ViewUsersMenu(Role role)
    {
        Console.Clear();
        WriteInColor($"{role} list:\n", ConsoleColor.DarkCyan);

        switch (role)
        {
            case Role.Admin:
                var admins = _adminService.GetAllAdmins();
                foreach (var admin in admins)
                {
                    Console.WriteLine(admin.GetFullName());
                }
                break;

            case Role.Librarian:
                var librarians = _adminService.GetAllLibrarians();
                foreach (var librarian in librarians)
                {
                    Console.WriteLine(librarian.GetFullName());
                }
                break;

            case Role.Member:
                var members = _adminService.GetAllMembers();
                foreach (var member in members)
                {
                    Console.WriteLine(member.GetFullName());
                }
                break;
        }
    }


    public void LibrarianMainMenu()
    {
        Console.Clear();
        WriteInColor("Welcome to the Librarian menu.", ConsoleColor.DarkCyan);
        WriteInColor("\nSelect option: \n1. View Books \n2. View Members \n3. Logout", ConsoleColor.Cyan);
    }


    public bool LibrarianUI(Librarian loggedLibrarian)
    {
        try
        {
            LibrarianMainMenu();
            int choice = _utils.GetValidOption(new[] { 1, 2, 3 });

            switch (choice)
            {
                case 1:
                    ViewBooksMenu();
                    return false;

                case 2:
                    ViewMembersMenu();
                    return false;

                case 3:
                    return true;
            }
        }
        catch (Exception ex)
        {
            WriteInColor(ex.Message, ConsoleColor.Red);
        }

        return false;
    }


    public void ViewBooksMenu()
    {
        //Console.Clear();
        WriteInColor("Books list:\n", ConsoleColor.DarkCyan);

        string[] books = _librarianService.GetAllBooks();

        if (books.Length == 0)
        {
            WriteInColor("No books available at the moment.", ConsoleColor.DarkYellow);
            return;
        }

        foreach (string book in books)
        {
            Console.WriteLine(book);
        }
        Pause();
    }


    public void ViewMembersMenu()
    {
        //Console.Clear();
        WriteInColor("Members list:\n", ConsoleColor.DarkCyan);

        var members = _librarianService.GetAllMembers();

        foreach (var member in members)
        {
            Console.WriteLine(member.GetFullName());
        }
        Pause();
    }

    public void Pause()
    {
        WriteInColor("\nPress Enter to continue...", ConsoleColor.DarkCyan);
        Console.ReadLine();
    }

    public void WelcomeMenu()
    {
        WriteInColor("Welcome to Library App", ConsoleColor.DarkCyan);
        WriteInColor("\nChoose your role to login: \n1.Admin \n2.Librarian \n3.Member", ConsoleColor.Cyan);
    }



    public void WriteInColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
