using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User? ValidateUser(string cardNumber)
    {
        var user = _userRepository.GetByCardNumber(cardNumber);
        if (user == null || user.IsSubscriptionExpired)
        {
            return null;
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
}
