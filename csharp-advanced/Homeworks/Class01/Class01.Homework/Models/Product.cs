using Class01.Homework.Enums;

namespace Class01.Homework.Models;

// Class Product
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
}

