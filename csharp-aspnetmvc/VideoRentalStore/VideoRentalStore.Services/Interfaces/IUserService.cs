using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Gets a user by identifier as a DTO.
    /// </summary>
    UserDto? GetById(int id);

    /// <summary>
    /// Gets all users as DTOs.
    /// </summary>
    List<UserDto> GetAll();

    /// <summary>
    /// Creates a user from a DTO.
    /// </summary>
    void Create(UserDto dto);

    /// <summary>
    /// Updates a user from a DTO.
    /// </summary>
    void Update(UserDto dto);

    /// <summary>
    /// Validates a user by card number and returns a DTO when found.
    /// </summary>
    UserDto? ValidateUser(string cardNumber);

    /// <summary>
    /// Determines whether the user is allowed to rent based on subscription rules.
    /// </summary>
    bool CanRent(UserDto dto);

    /// <summary>
    /// Decrements remaining free rentals for a Free-tier user.
    /// </summary>
    void DecrementFreeRental(UserDto dto);

    /// <summary>
    /// Downgrades an expired subscription to Free.
    /// </summary>
    void DowngradeIfExpired(UserDto dto);
}
