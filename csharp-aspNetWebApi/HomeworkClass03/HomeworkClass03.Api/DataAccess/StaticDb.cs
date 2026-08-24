using HomeworkClass03.Api.Models;

namespace HomeworkClass03.Api.DataAccess;

public static class StaticDb
{
    public static List<Book> books = new()
    {
        new Book { Author = "Robert C. Martin", Title = "Clean Code" },
        new Book { Author = "Robert C. Martin", Title = "The Clean Coder" },
        new Book { Author = "Andrew Hunt & David Thomas", Title = "The Pragmatic Programmer" },
        new Book { Author = "Erich Gamma et al.", Title = "Design Patterns: Elements of Reusable Object-Oriented Software" },
        new Book { Author = "Martin Fowler", Title = "Refactoring: Improving the Design of Existing Code" },
        new Book { Author = "Jon Skeet", Title = "C# in Depth" },
        new Book { Author = "Joseph Albahari & Ben Albahari", Title = "C# 10 in a Nutshell" },
        new Book { Author = "Jeffrey Richter", Title = "CLR via C#" },
        new Book { Author = "Mark J. Price", Title = "C# 10 and .NET 6 – Modern Cross-Platform Development" },
        new Book { Author = "Adam Freeman", Title = "Pro ASP.NET Core MVC" }
    };
}

