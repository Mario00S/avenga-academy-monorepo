using FirstMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace FirstMvcApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        //If the default source is not correct, use one of the following attributes to specify the source:
        //Model binding
        //[FromQuery] - Gets values from the query string.
        //[FromRoute] - Gets values from route data.
        //[FromForm] - Gets values from posted form fields.
        //[FromBody] - Gets values from the request body.
        //[FromHeader] - Gets values from HTTP headers.
        //For e.g. if [FromRoute] is configured in here public IActionResult Edit([FromRoute]int? id)
        //getting the id by querry would not be possible //edit?id=(id)

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";
            //var category = new Category { CategoryId = id.HasValue?id.Value:0 };
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int categoryId)
        {
            CategoriesRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
