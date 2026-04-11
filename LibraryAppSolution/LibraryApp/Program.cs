//Console.WriteLine("Library App");
//Console.WriteLine("================================");
//Console.WriteLine("Enter the number to select the appropriate user:");
//Console.WriteLine("\n1.Admin \n2.Librarian \n3.Member");

//bool userChoice = int.TryParse(Console.ReadLine(), out int userRole);

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

menuController.InitApp();