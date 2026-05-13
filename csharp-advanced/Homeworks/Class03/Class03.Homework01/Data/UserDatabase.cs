namespace Class03.Homework01.Data;

public static class UserDatabase
{
    public static List<User> Users { get; set; } = new List<User>();

    //static method should be the same name as the class
    static UserDatabase()
    {


        Users = new List<User>()
            {
                new User {Id = 1, Name = "bobsky", Age = 25},
                new User {Id = 2, Name = "john", Age = 35},
            };
    }

    //additional method for retriving the users
    public static void ListUsers()
    {
        for (int i = 0; i < Users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Users[i].Name}");
        }
    }

    //will return only one user

    public static User Search(this string name)
    {
        foreach (User user in Users)
        {
            if (user.Name == name)
            {
                return user;
            }
        }
        return null;
    }

    //will return only one user
    public static User Search(this int id)
    {
        foreach (User user in Users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        return null;
    }

    //using list if we want to return all mathcing for e.g. Users(not unique)
    public static List<User> SearchByAge(int age)
    {
        List<User> matches = new List<User>();

        foreach (User user in Users)
        {
            if (user.Age == age)
            {
                matches.Add(user);
            }
        }

        return matches;
    }
}
