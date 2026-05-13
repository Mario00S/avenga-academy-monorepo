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

    public static User Search(string name)
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

    public static User Search(int id)
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
}
