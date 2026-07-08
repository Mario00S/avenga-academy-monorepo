using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDo.App.Models;
//Renamed the model due to conflicts with the namespace
namespace ToDo.App.Controllers
{
    public class HomeController : Controller
    {
        private ToDoContext _context;

        public HomeController(ToDoContext ctx) => _context = ctx;

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            //keeping this one as a property instead of a method DueFilterValues
            ViewBag.DueFilters = Filters.DueFilterValues;

            IQueryable<ToDoModel> query = _context.ToDos
                .Include(t => t.Category).Include(t => t.Status);

            if (filters.HasCategory)
            {
                query = query.Where(t => t.CategoryId == filters.CategoryId);
            }

            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            if (filters.HasDue)
            {
                var today = DateTime.Today;
                if (filters.IsPast)
                {
                    query = query.Where(t => t.DueDate < today);
                }
                else if (filters.IsFuture)
                {
                    query = query.Where(t => t.DueDate > today);
                }else if (filters.IsToday)
                {
                    query = query.Where(t => t.DueDate == today);
                }               
            }
            var tasks = query.OrderBy(t => t.DueDate).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            var task = new ToDoModel { StatusId = "open" };
            return View(task);
        }

        [HttpPost]
        public IActionResult Add(ToDoModel task)
        {
            if (ModelState.IsValid)
            {
                _context.ToDos.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Statuses = _context.Statuses.ToList();               
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter); //oposite of split method
            return RedirectToAction("Index", new { ID = id });// Split takes one string and breaks it into an array using a delimiter.
                                                              // Join does the opposite: it takes an array of strings and combines them
                                                              // back into a single string with a delimiter in between each element.
                                                              // Example: "work-today-open".Split('-') => ["work","today","open"]
                                                              // string.Join('-', ["work","today","open"]) => "work-today-open"
        }

        [HttpPost]
        public IActionResult MarkComplete([FromRoute]string id, ToDoModel selected)
        {
            selected = _context.ToDos.Find(selected.Id)!;

            if (selected != null)
            {
                selected.StatusId = "closed";
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { Id = id });
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var toDelete = _context.ToDos.Where(t => t.StatusId == "closed").ToList();

            foreach (var task in toDelete)
            {
                _context.ToDos.Remove(task);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", new { Id = id });
        }
    }
}
