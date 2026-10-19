using PizzaApp.Api.Extensions;
using PizzaApp.DataAccess;
using PizzaApp.Mappers;
using PizzaApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration)
    .AddMappers()
    .AddServices()
    .AddApi(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(_ => { });

if (app.Environment.IsDevelopment())
{
    app.MapApiDocs();
}

app.UseHttpsRedirection();

app.UseCors(CorsExtensions.FrontendPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
