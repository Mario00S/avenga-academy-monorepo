using FirstMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            var category = new Category { CategoryId = id.HasValue?id.Value:0 };

            return View(category);
            //if (id.HasValue)
            //{
            //    return new ContentResult { Content = id.ToString() };
            //}
            //else
            //{
            //    return new ContentResult { Content = "null content" };
            //}
        }
    }
}
