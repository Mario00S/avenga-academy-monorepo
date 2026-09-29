namespace Lamazon.Domain.Entities;

public class ProductCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int ProductCategoryStatusId { get; set; }

    // Navigation property to ProductCategoryStatus
    public ProductCategoryStatus ProductCategoryStatus { get; set; }

    // Navigation property to Products
    public ICollection<Product> Products { get; set; } = [];
}