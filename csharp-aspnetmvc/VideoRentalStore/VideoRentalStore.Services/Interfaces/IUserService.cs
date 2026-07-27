using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.Services.Interfaces;

public interface IUserService
{
    User? ValidateUser(string cardNumber);
    User? GetById(int id);
    IEnumerable<User> GetAll();
}
