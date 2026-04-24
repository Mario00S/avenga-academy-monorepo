namespace Class08.HomeworkPart02.Models;

using HomeworkPart02.Enums;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
    public int Stock { get; set; }
    public string Brand { get; set; }
    public ProductCategory Category { get; set; }

    public Product(int id, string title, string description, double price, double rating, int stock, string brand, ProductCategory category)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Rating = rating;
        Stock = stock;
        Brand = brand;
        Category = category;
    }

    //public static void  PrintFunction(
    //IEnumerable<Product> productsToPrint,
    //Func<Product, string> selector)
    //{
    //    foreach (var product in productsToPrint)
    //    {
    //        Console.WriteLine(selector(product));
    //    }
    //}
}
