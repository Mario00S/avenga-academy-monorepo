using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
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
    public User? ValidateUser(string cardNumber)
    {
        var user = _userRepository.GetByCardNumber(cardNumber);
        if (user == null)
        {
            return null;
        }

        if (user.IsSubscriptionExpired)
        {
            user.SubscriptionType = SubscriptionType.Free;
            user.SubscriptionExpiresAt = null;
            _userRepository.Update(user);
        }
        return user;
    }
    //not needed unless i make admin menu or profile page
    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public User? GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public void DowngradeIfExpired(User user)
    {
        if (user.IsSubscriptionExpired)
        {
            user.SubscriptionType = SubscriptionType.Free;
            user.SubscriptionExpiresAt = null;
            _userRepository.Update(user);
        }
    }

    public bool CanRent(User user)
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

    public void Update(User user)
    {
        _userRepository.Update(user);
    }

    public void DecrementFreeRental(User user)
    {
        if (user.SubscriptionType == SubscriptionType.Free && user.RemainingFreeRentals > 0)
        {
            user.RemainingFreeRentals--;
            _userRepository.Update(user);
        }
    }

}
