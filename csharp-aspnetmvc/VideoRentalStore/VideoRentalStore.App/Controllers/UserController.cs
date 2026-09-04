using Microsoft.AspNetCore.Mvc;
using VideoRentalStore.Models.ViewModels;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.App.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRentalService _rentalService;
        private readonly IMovieService _movieService;

        public UserController(IUserService userService, IRentalService rentalService, IMovieService movieService)
        {
            _userService = userService;
            _rentalService = rentalService;
            _movieService = movieService;
        }

        // GET: /User/Login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost("login")]
        public IActionResult Login(string cardNumber)
        {
            var user = _userService.ValidateUser(cardNumber);
            if (user != null)
            {
                //_userService.DowngradeIfExpired(user);
                //handled in UserService - ValidateUserMethod

                Response.Cookies.Append("UserId", user.Id.ToString(), new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
                });

                return RedirectToAction("Index", "Movies");
            }

            ViewBag.Error = "Invalid card number or subscription expired.";
            return View();
        }

        // GET: /User/Profile
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                return RedirectToAction("Login");
            }

            int userId = int.Parse(userIdCookie);
            var user = _userService.GetById(userId);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Fetch rentals for this user
            var rentals = _rentalService.GetRentalsByUserId(userId);

            // Fetch all movies (or just those needed)
            var movies = _movieService.GetAllMovies();

            var vm = new UserProfileViewModel
            {
                FullName = user.FullName,
                Age = user.Age,
                CardNumber = user.CardNumber,
                CreatedOn = user.CreatedOn,
                IsSubscriptionExpired = user.IsSubscriptionExpired,
                SubscriptionType = user.SubscriptionType,
                RentedMovies = rentals.Select(r =>
                {
                    var movie = movies.FirstOrDefault(m => m.Id == r.MovieId);

                    return new MovieViewModel
                    {
                        Title = r.MovieTitle ?? movie?.Title ?? "Unknown",
                        Genre = movie?.Genre.ToString() ?? "Unknown",
                        RentedOn = r.RentedOn,
                        ReturnedOn = r.ReturnedOn,
                        RentalId = r.Id
                    };
                }).ToList()
            };

            return View(vm); // pass the ViewModel instead of the domain User
        }

        [HttpPost("return")]
        public IActionResult Return(int rentalId)
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                return RedirectToAction("Login");
            }

            int userId = int.Parse(userIdCookie);

            var rental = _rentalService.GetById(rentalId);
            if (rental == null || rental.UserId != userId)
            {
                TempData["Error"] = "Invalid rental or unauthorized action.";
                return RedirectToAction("Profile");
            }

            // Mark rental as returned
            _rentalService.ReturnMovie(rentalId);

            // Mark movie as available again
            _movieService.MarkAvailable(rental.MovieId);

            TempData["Success"] = "Movie returned successfully.";
            return RedirectToAction("Profile");
        }




        // GET: /User/Logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserId");
            return RedirectToAction("Index", "Home");
        }
    }
}
