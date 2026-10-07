namespace PizzaApp.Shared.Exceptions;

public class BadRequestException : AppException
{
    public IReadOnlyList<string> Errors { get; set; } = [];
    public BadRequestException(string message, IEnumerable<string>? errors = null)
        : base(message, StatusCodes.BadRequest)
    {
        Errors = errors?.ToList() ?? [];
    }
}
