using Microsoft.AspNetCore.Mvc;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Mapper;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.App.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        //if there are  5+ services it's a sign that the controller is owerpopulated
        //fine for now
        private readonly IRentalService _rentalService;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public MoviesController(IMovieService movieService, IRentalService rentalService, IUserService userService)
        {
            _rentalService = rentalService;
            _movieService = movieService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;
            var movieDtos = _movieService.GetPagedAvailableMovies(page, pageSize);
            int totalMovies = _movieService.GetAvailableMovies().Count;

            var movies = movieDtos.Select(MovieMapper.MapToEntity);
            var vm = MovieMapper.MapMoviesToFilterViewModel(movies, page, totalMovies);
            return View(vm);
        }

        [HttpGet("filter")]
        public IActionResult Filter(string? title, Genre? GenreFilter, string? castName, int page = 1)
        {
            Console.WriteLine($"DEBUG: title={title}, genre={GenreFilter}, castName={castName}");
            int pageSize = 10;
            var movieDtos = _movieService.GetPagedFilteredMovies(title, GenreFilter, castName, page, pageSize);
            int totalMovies = _movieService.FilterMovies(title, GenreFilter, castName).Count;

            if (totalMovies == 0)
            {
                TempData["Error"] = "No movies matched your search criteria.";
            }

            var movies = movieDtos.Select(MovieMapper.MapToEntity);
            var vm = MovieMapper.MapMoviesToFilterViewModel(movies, page, totalMovies, title, GenreFilter, castName);
            return View("Index", vm);
        }


        [HttpGet("rent/{id}")]
        public IActionResult Rent(int id)
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                TempData["Error"] = "You must be logged in.";
                return RedirectToAction("Index");
            }

            int userId = int.Parse(userIdCookie);

            var user = _userService.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }

            var movieDto = _movieService.GetMovieById(id);
            if (movieDto == null)
            {
                return NotFound();
            }

            // Check if this user already rented the movie
            var existingRental = _rentalService
                .GetRentalsByUserId(userId)
                .FirstOrDefault(r => r.MovieId == id && r.ReturnedOn == null);

            if (existingRental != null)
            {
                ViewBag.AlreadyRented = true;
            }

            if (!_userService.CanRent(user))
            {
                ViewBag.CannotRent = true;
            }

            var movie = MovieMapper.MapToEntity(movieDto);
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

            var user = _userService.GetById(userId);
            if (user == null)
            {
                TempData["Error"] = "User not found.";
                return RedirectToAction("Index");
            }

            // Ensure subscription is valid before checking rental rules
            _userService.DowngradeIfExpired(user);

            // Enforce subscription rules before renting
            if (!_userService.CanRent(user))
            {
                TempData["Error"] = "You cannot rent this movie. Subscription expired or rental limit reached.";
                return RedirectToAction("Index");
            }

            try
            {
                //add movie - rent movie
                _rentalService.RentMovie(userId, id);

                //mark as unavailable
                _movieService.RentMovie(id, userId);
                TempData["Sucess"] = "Movie Rented Successfully";

                // If Free tier, decrement remaining rentals
                _userService.DecrementFreeRental(user);
                // Debug: re-fetch the user to confirm persistence
                var updatedUser = _userService.GetById(user.Id);
                Console.WriteLine($"Remaining rentals after update: user {updatedUser?.Id}, subscription {updatedUser?.SubscriptionType}");
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
            var movieDto = _movieService.GetMovieById(id);
            if (movieDto is null)
            {
                return NotFound();
            }

            var movie = MovieMapper.MapToEntity(movieDto);
            var castDtos = _movieService.GetCastForMovie(id);
            var cast = castDtos.Select(c => new Cast
            {
                Id = c.Id,
                MovieId = c.MovieId,
                Name = c.Name,
                Role = c.Role
            });
            var viewModel = MovieMapper.MapMovieToDetails(movie, cast);

            return View(viewModel);
        }
    }
}
