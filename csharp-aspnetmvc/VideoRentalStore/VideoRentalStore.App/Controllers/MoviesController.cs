using Microsoft.AspNetCore.Mvc;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.App.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var movies = _service.GetAvailableMovies();
            return View(movies);
        }
        [HttpGet("rent/{id}")]
        public IActionResult Rent(int id)
        {
            var movie = _service.GetMovieById(id);
            if (movie == null || !movie.IsAvailable)
                return NotFound();

            return View(movie);
        }

        //both methods take the same parameter that's why i cannot use the same name // compared to ToDoApp example Create method
        [HttpPost("rent/{id}")]
        public IActionResult RentConfirmed(int id)
        {
            //might change this, in the moment is a restriction for someone to acces without authorization by targeting the url /rent/5
            var userId = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "You must be logged in to rent movies.";
                return RedirectToAction("Index");
            }
            _service.RentMovie(id, int.Parse(userId));
            return RedirectToAction("Index");
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _service.GetMovieById(id);
            if (movie is null)
            {
                return NotFound();
            }
            return View(movie);
        }
    }
}
