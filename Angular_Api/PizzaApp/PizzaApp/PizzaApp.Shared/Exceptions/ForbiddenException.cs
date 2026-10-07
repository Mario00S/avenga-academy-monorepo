namespace PizzaApp.Shared.Exceptions;

public class ForbiddenException : AppException
{
    public ForbiddenException(string message)
        : base(message, StatusCodes.Forbidden)
    {
    }
}
