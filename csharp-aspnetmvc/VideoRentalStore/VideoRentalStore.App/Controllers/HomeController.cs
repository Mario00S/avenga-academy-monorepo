using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoRentalStore.App.Models;

namespace VideoRentalStore.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (Request.Cookies["UserId"] != null)
            {
                // Redirect logged-in users to Movies
                return RedirectToAction("Index", "Movies");
            }

            return View();
        }

        //to be used if i implenet Admin menu
        //public ActionResult Dashboard()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
