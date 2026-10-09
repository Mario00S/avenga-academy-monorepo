using PizzaApp.Api.Extensions;
using PizzaApp.DataAccess;
using PizzaApp.Mappers;
using PizzaApp.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi(builder.Configuration);
builder.Services.AddDataAccess(builder.Configuration)
    .AddServices()
    .AddMappers();

var app = builder.Build();

// if we want to use our own exception handler, we can configure it here
//with the _=> {} instead of the default exception handler
app.UseExceptionHandler(_ => { });

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().AllowAnonymous();
    app.MapScalarApiReference().AllowAnonymous();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
