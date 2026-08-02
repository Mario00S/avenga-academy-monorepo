using System.Linq;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.DataAccess.Repository;

public class InMemoryUserRepository : InMemoryRepository<User>, IUserRepository
{
    public InMemoryUserRepository()
    {
        _entities.AddRange(new List<User>
    {
        new User { Id = 1, FullName = "Alice Johnson", Age = 25, CardNumber = "CARD001", CreatedOn = DateTime.Now, SubscriptionType = SubscriptionType.Free, SubscriptionExpiresAt = null },
        new User { Id = 2, FullName = "Bob Smith", Age = 32, CardNumber = "CARD002", CreatedOn = DateTime.Now.AddDays(-10), SubscriptionType = SubscriptionType.Basic, SubscriptionExpiresAt = DateTime.UtcNow.AddDays(-1) }, // expired
        new User { Id = 3, FullName = "Charlie Brown", Age = 28, CardNumber = "CARD003", CreatedOn = DateTime.Now.AddMonths(-2), SubscriptionType = SubscriptionType.Premium, SubscriptionExpiresAt = DateTime.UtcNow.AddMonths(1) }, // active
        new User { Id = 4, FullName = "Diana Prince", Age = 30, CardNumber = "CARD004", CreatedOn = DateTime.Now.AddYears(-1), SubscriptionType = SubscriptionType.Premium, SubscriptionExpiresAt = DateTime.UtcNow.AddDays(10) }, // active
        new User { Id = 5, FullName = "Ethan Hunt", Age = 35, CardNumber = "CARD005", CreatedOn = DateTime.Now.AddDays(-45), SubscriptionType = SubscriptionType.Free, SubscriptionExpiresAt = null },
        new User { Id = 6, FullName = "Fiona Gallagher", Age = 27, CardNumber = "CARD006", CreatedOn = DateTime.Now.AddMonths(-6), SubscriptionType = SubscriptionType.Basic, SubscriptionExpiresAt = DateTime.UtcNow.AddDays(20) }, // active
        new User { Id = 7, FullName = "George Miller", Age = 40, CardNumber = "CARD007", CreatedOn = DateTime.Now.AddYears(-2), SubscriptionType = SubscriptionType.Premium, SubscriptionExpiresAt = DateTime.UtcNow.AddDays(-5) }, // expired
        new User { Id = 8, FullName = "Hannah Baker", Age = 22, CardNumber = "CARD008", CreatedOn = DateTime.Now.AddDays(-3), SubscriptionType = SubscriptionType.Basic, SubscriptionExpiresAt = DateTime.UtcNow.AddDays(15) } // active
    });
    }

    //later to be used if i Get an Admin panel
    public IEnumerable<User> GetActiveUsers()
    {
        throw new NotImplementedException();
    }

    public User GetByCardNumber(string cardNumber)
    {
        return _entities.FirstOrDefault(u => u.CardNumber == cardNumber);
    }
    public void Update(User entity)
    {
        var existing = _entities.FirstOrDefault(u => u.Id == entity.Id);
        if (existing != null)
        {
            // Replace the object reference in the list
            int index = _entities.IndexOf(existing);
            _entities[index] = entity;
        }
    }

}
