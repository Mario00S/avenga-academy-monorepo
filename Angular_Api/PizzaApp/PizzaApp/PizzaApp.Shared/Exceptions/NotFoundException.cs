namespace PizzaApp.Shared.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string entityName, object id)
        : base($"{entityName} with id {id} was not found.", StatusCodes.NotFound)
    {
    }

    public NotFoundException(string message)
        : base(message, StatusCodes.NotFound)
    {
    }
}
