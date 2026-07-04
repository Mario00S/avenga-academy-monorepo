namespace FirstMvcApp.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
            new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
            new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
            new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
        };

        //old implementation that caused a bug, needed to add a check in a scenario if there are no products, for e.g. if i delete all the in memory ones and add a new product after that
        //public static void AddProduct(Product product)
        //{
        //    var maxId = _products.Max(x => x.ProductId);
        //    product.ProductId = maxId + 1;
        //    _products.Add(product);
        //}

        public static void AddProduct(Product product)
        {
            int newId = _products.Any() ? _products.Max(x => x.ProductId) + 1 : 1;
            product.ProductId = newId;
            _products.Add(product);
        }

        public static List<Product> GetProducts() => _products;

        public static Product? GetProductById(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                return new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CategoryId = product.CategoryId                    
                };
            }

            return null;
        }

        public static void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return;

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;
            }
        }

        public static void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public static List<Product> GetProductsByCategoryId(int categoryId)
        {
            return _products
                .Where(x => x.CategoryId == categoryId)
                .ToList();
        }
        //public static List<Product> GetProductsByCategoryId(int categoryId)
        //{
        //    var products = _products.Where(x => x.CategoryId == categoryId);
        //    if (products != null)
        //    {
        //        return new List<Product>();
        //    }
        //}
    }
}
