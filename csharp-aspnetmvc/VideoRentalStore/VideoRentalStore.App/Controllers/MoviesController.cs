using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("rent")]
        public IActionResult RentConfirmed(int id)
        {
            _service.RentMovie(id, userId: 1);
            return RedirectToAction("Index");
        }
    }
}
