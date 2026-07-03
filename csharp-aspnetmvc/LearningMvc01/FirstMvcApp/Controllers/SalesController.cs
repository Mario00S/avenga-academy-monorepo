using FirstMvcApp.Models;
using FirstMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(salesViewModel);
        }
    }
}
