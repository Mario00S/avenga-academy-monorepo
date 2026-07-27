using Microsoft.AspNetCore.Mvc;
using VideoRentalStore.Models.ViewModels;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.App.ViewComponents;

public class UserMenuViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public UserMenuViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public IViewComponentResult Invoke()
    {
        var cookie = HttpContext.Request.Cookies["UserId"];
        if (string.IsNullOrEmpty(cookie))
            return View(new UserMenuViewModel());

        if (!int.TryParse(cookie, out var userId))
            return View(new UserMenuViewModel());

        var user = _userService.GetById(userId);
        var model = new UserMenuViewModel
        {
            FullName = user?.FullName
        };

        return View(model);
    }
}