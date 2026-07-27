using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Interfaces;

public interface IUserRepository : IRepository<User>
{
    User GetByCardNumber(string cardNumber);
    IEnumerable<User> GetActiveUsers();
}
