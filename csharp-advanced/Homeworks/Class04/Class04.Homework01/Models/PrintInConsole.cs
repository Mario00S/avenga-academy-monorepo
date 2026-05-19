namespace Class04.Homework01.Models;

//Task 1
//Create class PrintInConsole that will have multiple methods to print in console: Print(), PrintCollection().
//Make these methods to be valid for more than one type and use them accordingly with different types.

public static class PrintInConsole
{

    public static void PrintCollection<T>(this IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Console.Write(item + " ");
        }
    }

    public static void Print<T>(this T item)
    {
        Console.WriteLine(item);
    }

}
