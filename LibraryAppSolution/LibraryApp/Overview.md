# Library Management Console App

A role-based C# console application for managing a simple library system.  
The application supports different user experiences for **Admin**, **Librarian**, and **Member** roles.

## Overview

This project was built as a console-based library management system with role-specific menus and actions.

The application allows:
- User login by role.
- Admin management of users.
- Librarian access to books and members.
- Member access to current borrowed book and borrowing history.

The project uses a simple in-memory database structure and follows a layered approach where:
- The **menu/UI layer** handles console interaction.
- The **service layer** handles logic.
- The **data layer** stores the app data.

---

## Roles

### Admin
The Admin can manage users in the system.

Admin actions include:
- Add users.
- Remove users.
- View users by role:
  - Admins
  - Librarians
  - Members

### Librarian
The Librarian can view library-related information.

Librarian actions include:
- View all books.
- View all members.
- Logout

### Member
The Member can view personal borrowing information.

Member actions include:
- View available books.
- View currently borrowed book.
- View borrowing history.
- Logout

---

## Project Structure

A simplified structure of the application looks like this:

```text
LibraryAppSolution
│
├── Models
│   ├── User.cs
│   ├── Admin.cs
│   ├── Librarian.cs
│   ├── Member.cs
│   └── Enums
│
├── Data
│   └── Database.cs
│
├── Services
│   ├── AdminService.cs
│   ├── LibrarianService.cs
│   ├── MemberService.cs
│   └── UtilityService.cs / Utils.cs
│
├── UI
│   └── Menu / AppScreen / ConsoleUI class
│
└── Program.cs
```

---

## Main Concepts

### 1. Role-based navigation
After login, the application sends the user to the correct menu depending on their role.

Example:
- Admin -> Admin menu
- Librarian -> Librarian menu
- Member -> Member menu

This keeps the application organized and makes each user flow easier to manage.

### 2. Separation of concerns
The app separates responsibilities into different layers:

- **UI/Menu classes**  
  Responsible for:
  - Showing menus
  - Reading user input
  - Printing output
  - Calling service methods

- **Service classes**  
  Responsible for:
  - Business logic
  - Retrieving data
  - Validating operations

- **Database class**  
  Responsible for:
  - Holding in-memory collections of users and books

This makes the code cleaner and easier to extend later.

---

## Data Model

### Database
The application uses a simple in-memory `Database` class.

Example data stored in the database:
- `List<Admin> Admins`
- `List<Librarian> Librarians`
- `List<Member> Members`
- `string[] Books`

Example books:
- The Hobbit
- 1984
- Pride and Prejudice
- The Great Gatsby
- Moby Dick
- Harry Potter
- The Alchemist

### Member-specific data
Each member can contain personal borrowing information such as:
- `CurrentlyBorrowedBook`
- `ReturnedBooksDaysKept`

Example:
- `CurrentlyBorrowedBook` stores the active borrowed book as a string.
- `ReturnedBooksDaysKept` stores book titles and how many days they were kept.

---

## Features Implemented

### Authentication / Login
The application supports login using role-specific credentials.

Each role is authenticated and redirected to its own workflow.

### Admin features
The admin can:
- Create users
- Delete users
- View lists of users by role

### Librarian features
The librarian can:
- View all members
- View all books

### Member features
The member can:
- View all books
- See the current borrowed book
- See borrowing history

---

## Menu Flow

### Main application flow
1. Start the application.
2. Enter login credentials.
3. Validate user by role.
4. Redirect to the correct menu.
5. Execute role-specific actions.
6. Return to menu or logout.

### Admin flow
1. Admin logs in.
2. Admin chooses which role to manage.
3. Admin selects an action:
   - Add
   - Remove
   - View users
   - Go back

### Librarian flow
1. Librarian logs in.
2. Librarian sees the menu:
   - View books
   - View members
   - Logout

### Member flow
1. Member logs in.
2. Member sees the menu:
   - View books
   - View current borrowed book
   - View history of borrowed books
   - Logout

---

## Example Methods

### View users by role
The admin can print users depending on the selected role.

```csharp
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

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey(true);
}
```

### View books
Books are stored as a `string[]` in the database, so the logic is simple.

```csharp
public void ViewBooksMenu()
{
    Console.Clear();
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
}
```

### Member current book
The member service exposes the current borrowed book.

```csharp
public string CurrentBook(Member loggedMember)
{
    return loggedMember.CurrentlyBorrowedBook;
}
```

### Member history
The member service exposes borrowing history.

```csharp
public Dictionary<string, int> HistoryOfBooks(Member loggedMember)
{
    return loggedMember.ReturnedBooksDaysKept;
}
```

---

## Validation and Utility Logic

The application uses helper or utility methods for:
- Reading valid numeric options
- Preventing invalid menu choices
- Printing colored console messages

Example responsibilities of utility methods:
- Accept only specific menu options
- Improve user feedback in the console
- Reduce repeated code across menus

---

## Design Decisions

### Why separate menus by role
Each role has different responsibilities, so separate menus make the code easier to understand and maintain.

### Why use services
Service classes avoid placing all logic inside the menu/UI class.  
This keeps the console interaction layer simpler.

### Why books are stored as strings
At the current stage of the project, books are represented as strings for simplicity.  
This is enough for displaying book titles and testing role-based functionality.

### Why member history uses a dictionary
A dictionary is useful because it stores:
- The book title as the key
- The number of days kept as the value

This makes borrowing history easy to display.

---

## Known Limitations

This project currently uses an in-memory database, so:
- Data resets when the application is restarted.
- There is no persistent file or real database storage yet.

Other current limitations:
- Books are simple strings, not full `Book` objects.
- There is no advanced borrow/return workflow yet.
- There is no due-date management.
- There is no search/filter functionality.

---

## Future Improvements

Possible next steps for the project:
- Create a `Book` class with:
  - Title
  - Author
  - Genre
  - Availability
- Add borrow and return functionality
- Store data in JSON, XML, or a real database
- Improve error handling
- Add unit tests
- Refactor menus into smaller UI classes if the project grows
- Add book search
- Add admin reporting features

---

## Example Test Accounts

You can document sample accounts here if needed:

- Admin account
- Librarian account
- Member account

Example member test data may include:
- No current borrowed book
- Empty borrowing history
- A current borrowed book
- Existing borrowing history

---

## Learning Goals of the Project

This project helped practice:
- C# classes and objects
- Lists, arrays, and dictionaries
- Switch statements and menu navigation
- Role-based logic
- Separation of concerns
- Service-based design
- Console application structure

---

## Summary

This application is a solid foundation for a beginner-to-intermediate console project.  
It demonstrates how to build a role-based library system using C#, with clear separation between menus, services, and data storage.


## Tech Stack

- C#
- .NET Console Application
- Object-Oriented Programming
- In-memory data storage

## How to Run

1. Open the solution in Visual Studio.
2. Build the project.
3. Run the console application.
4. Log in with one of the test users.
5. Navigate through the menus by entering the allowed options.