var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//test
var baseUrl = builder.Configuration["MarketCheck:BaseUrl"];
Console.WriteLine($"Loaded BaseUrl: {baseUrl}");

//DI for the HttpClient
//instead of making new instances each time //httpClient = new HttpClient(); The runtime will handle this and pass it into the controller
builder.Services.AddHttpClient();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
