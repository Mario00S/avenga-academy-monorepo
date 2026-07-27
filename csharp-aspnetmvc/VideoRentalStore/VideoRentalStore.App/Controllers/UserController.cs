using Microsoft.AspNetCore.Mvc;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.App.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            if (user != null && !user.IsSubscriptionExpired)
            {
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

            ViewData["UserName"] = user.FullName;
            return View(user);
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
