using Microsoft.AspNetCore.Mvc;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.App.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {

        private readonly IRentalService _rentalService;
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService, IRentalService rentalService)
        {
            _rentalService = rentalService;
            _movieService = movieService;
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;
            var movies = _movieService.GetPagedAvailableMovies(page, pageSize);
            int totalMovies = _movieService.GetAvailableMovies().Count();
            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize);
            return View(movies);
        }
        [HttpGet("rent/{id}")]
        public IActionResult Rent(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null || !movie.IsAvailable)
                return NotFound();

            return View(movie);
        }

        //both methods take the same parameter that's why i cannot use the same name // compared to ToDoApp example Create method
        [HttpPost("rent/{id}")]
        public IActionResult RentConfirmed(int id)
        {
            //might change this, in the moment is a restriction for someone to acces without authorization by targeting the url /rent/5
            var userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                TempData["Error"] = "You must be logged in to rent movies.";
                return RedirectToAction("Index");
            }
            int userId = int.Parse(userIdCookie);

            //add movie - rent movie
            //_rentalService.RentMovie(userId, id);
            //mark as unavailable
            //_rentalService.RentMovie(id, userId);

            try
            {
                _rentalService.RentMovie(userId, id);
                TempData["Sucess"] = "Movie rented successfully";
            }
            catch (InvalidOperationException ex)
            {

                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie is null)
            {
                return NotFound();
            }
            return View(movie);
        }
    }
}
