using FirstMvcApp.Models;

namespace FirstMvcApp.ViewModels;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public ProductViewModel(Product product)
    {
        ProductId = product.ProductId;
        ProductName = product.Name;
        Price = (int)(product.Price ?? 0);
        Quantity = product.Quantity ?? 0;

        if (product.CategoryId.HasValue)
        {
            var category = CategoriesRepository.GetCategoryById(product.CategoryId.Value);
            CategoryName = category?.Name ?? "Unknown";
        }
        else
        {
            CategoryName = "Unknown";
        }
    }
}
