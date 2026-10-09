namespace PizzaApp.Services.Abstractions;

public interface ICurrentUser
{
    string Id { get; }
    bool IsAdmin { get; }
}
