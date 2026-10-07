namespace PizzaApp.Shared.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message)
        : base(message, StatusCodes.NotFound)
    {
    }
}
