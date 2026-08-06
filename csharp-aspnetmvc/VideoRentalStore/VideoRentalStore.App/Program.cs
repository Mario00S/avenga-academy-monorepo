using Microsoft.EntityFrameworkCore;
using VideoRentalStore.DataAccess;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.DataAccess.Repository;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Implementations;
using VideoRentalStore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add EF Core DI
builder.Services.AddDbContext<VideoRentalDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IMovieRepository, EfMovieRepository>();
builder.Services.AddScoped<IRentalRepository, EfRentalRepository>();
builder.Services.AddScoped<ICastRepository, EfCastRepository>();



//comenting due to Ef usage instead
//Dependency Injection - trying with add signleton because of inMemory Db
//builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
//builder.Services.AddSingleton<IMovieRepository, InMemoryMovieRepository>();
//builder.Services.AddSingleton<IRentalRepository, InMemoryRentalRepository>();
//builder.Services.AddSingleton<ICastRepository>(sp =>
//{
//    var movieRepo = sp.GetRequiredService<IMovieRepository>();
//    return new InMemoryCastRepository(movieRepo.GetAll());
//});
// Register CastRepository with factory so it receives movies entity to be investigated, probably due to inMemory aproach atm

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<ICastService, CastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
