using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Mapper;
using VideoRentalStore.Models.Dtos;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRentalRepository _rentalRepository;

    public UserService(IUserRepository userRepository, IRentalRepository rentalRepository)
    {
        _userRepository = userRepository;
        _rentalRepository = rentalRepository;
    }

    /// <summary>
    /// Gets a user by identifier as a DTO.
    /// </summary>
    public UserDto? GetById(int id)
    {
        var user = _userRepository.GetById(id);
        if (user is null)
        {
            return null;
        }

        return UserMapper.MapToDto(user);
    }

    /// <summary>
    /// Gets all users as DTOs.
    /// </summary>
    public List<UserDto> GetAll()
    {
        var users = _userRepository.GetAll();
        return UserMapper.MapToDto(users);
    }

    /// <summary>
    /// Creates a user from a DTO.
    /// </summary>
    public void Create(UserDto dto)
    {
        var user = UserMapper.MapToEntity(dto);
        _userRepository.Add(user);
    }

    /// <summary>
    /// Updates a user from a DTO.
    /// </summary>
    public void Update(UserDto dto)
    {
        var existing = _userRepository.GetById(dto.Id);
        var user = UserMapper.MapToEntity(dto);

        if (existing is not null)
        {
            user.SubscriptionExpiresAt = existing.SubscriptionExpiresAt;
            user.RemainingFreeRentals = existing.RemainingFreeRentals;
        }

        _userRepository.Update(user);
    }

    /// <summary>
    /// Validates a user by card number and returns a DTO when found.
    /// </summary>
    public UserDto? ValidateUser(string cardNumber)
    {
        var user = _userRepository.GetByCardNumber(cardNumber);
        if (user == null)
        {
            return null;
        }

        DowngradeIfExpired(user);
        return UserMapper.MapToDto(user);
    }

    /// <summary>
    /// Downgrades an expired subscription to Free.
    /// </summary>
    public void DowngradeIfExpired(UserDto dto)
    {
        var user = _userRepository.GetById(dto.Id);
        if (user is null)
        {
            return;
        }

        DowngradeIfExpired(user);
    }

    /// <summary>
    /// Determines whether the user is allowed to rent based on subscription rules.
    /// </summary>
    public bool CanRent(UserDto dto)
    {
        var user = _userRepository.GetById(dto.Id);
        if (user is null)
        {
            return false;
        }

        return CanRent(user);
    }

    /// <summary>
    /// Decrements remaining free rentals for a Free-tier user.
    /// </summary>
    public void DecrementFreeRental(UserDto dto)
    {
        var user = _userRepository.GetById(dto.Id);
        if (user is null)
        {
            return;
        }

        DecrementFreeRental(user);
    }

    private void DowngradeIfExpired(User user)
    {
        if (user.IsSubscriptionExpired)
        {
            user.SubscriptionType = SubscriptionType.Free;
            user.SubscriptionExpiresAt = null;
            _userRepository.Update(user);
        }
    }

    private bool CanRent(User user)
    {
        //// Handle expired subscriptions
        ///moved into DowngradeIfExpired
        //if (user.IsSubscriptionExpired)
        //{
        //    user.SubscriptionType = SubscriptionType.Free;
        //}

        switch (user.SubscriptionType)
        {
            case SubscriptionType.Free:
                return user.RemainingFreeRentals > 0;
            case SubscriptionType.Basic:
                // Count rentals in current month (repository call needed)
                int rentalsThisMonth = _rentalRepository.GetMonthlyRentalCount(user.Id, DateTime.UtcNow);
                return rentalsThisMonth < 5;
            case SubscriptionType.Premium:
                return true; // unlimited
            default:
                return false;
        }
    }

    private void DecrementFreeRental(User user)
    {
        if (user.SubscriptionType == SubscriptionType.Free && user.RemainingFreeRentals > 0)
        {
            user.RemainingFreeRentals--;
            _userRepository.Update(user);
        }
    }
}
