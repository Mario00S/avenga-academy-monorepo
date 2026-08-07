using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Repository
{
    public class EfUserRepository : EfRepository<User>, IUserRepository
    {
        private readonly VideoRentalDbContext _context;

        public EfUserRepository(VideoRentalDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> GetActiveUsers()
        {
            return _context.Users
                .Where(u => !u.IsSubscriptionExpired)
                .ToList();
        }

        public User? GetByCardNumber(string cardNumber)
        {
            return _context.Users
                .FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        // Override Update to ensure EF tracks changes correctly
        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
