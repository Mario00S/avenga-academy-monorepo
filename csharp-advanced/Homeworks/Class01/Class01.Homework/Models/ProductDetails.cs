namespace Class01.Homework.Models;

public class ProductDetails
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }

    public ProductDetails(int id, string title, double price)
    {
        Id = id;
        Title = title;
        Price = price;
    }
}