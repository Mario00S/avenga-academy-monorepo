using FirstMvcApp.Models;
using FirstMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts();

            var productViewModels = products
                .Select(p => new ProductViewModel(p))
                .ToList();

            return View(productViewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = CategoriesRepository.GetCategories();
            ViewBag.Categories = categories;
            return View();
        }


        [HttpPost]
        public IActionResult Add(Product product)
        {
            ProductsRepository.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = ProductsRepository.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            ProductsRepository.UpdateProduct(id, product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = ProductsRepository.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = ProductsRepository.GetProductsByCategoryId(categoryId);

            return PartialView("_Products", products);
        }

    }
}
