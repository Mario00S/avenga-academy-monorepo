using Library.App.Controller;
using Library.Services;
using Library.Services.Services;

var utils = new Utils();
var adminService = new AdminService();
var librarianService = new LibrarianService();
var memberService = new MemberService();

var menuController = new MenuController(
    utils,
    adminService,
    librarianService,
    memberService);

//menuController.InitApp();

while (!menuController.InitApp())
{
    Console.Clear();
}