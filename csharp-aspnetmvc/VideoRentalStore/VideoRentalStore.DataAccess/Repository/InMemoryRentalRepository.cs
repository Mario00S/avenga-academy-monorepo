using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Repository
{
    public class InMemoryRentalRepository : InMemoryRepository<Rental>, IRentalRepository
    {
        public InMemoryRentalRepository()
        {
            _entities.AddRange(new List<Rental>
        {
            // Free tier (Alice) → only 2 rentals so far
            new Rental { Id = 1, UserId = 1, MovieId = 2, RentedOn = DateTime.UtcNow.AddDays(-5) },
            new Rental { Id = 2, UserId = 1, MovieId = 3, RentedOn = DateTime.UtcNow.AddDays(-15) },

            // Basic tier (Bob) → already rented 5 movies this month (limit reached)
            new Rental { Id = 3, UserId = 2, MovieId = 5, RentedOn = DateTime.UtcNow.AddDays(-2) },
            new Rental { Id = 4, UserId = 2, MovieId = 6, RentedOn = DateTime.UtcNow.AddDays(-3) },
            new Rental { Id = 5, UserId = 2, MovieId = 7, RentedOn = DateTime.UtcNow.AddDays(-7) },
            new Rental { Id = 6, UserId = 2, MovieId = 8, RentedOn = DateTime.UtcNow.AddDays(-10) },
            new Rental { Id = 7, UserId = 2, MovieId = 9, RentedOn = DateTime.UtcNow.AddDays(-12) },

            // Premium tier (Charlie) → multiple rentals across months
            new Rental { Id = 8, UserId = 3, MovieId = 10, RentedOn = DateTime.UtcNow.AddDays(-1) },
            new Rental { Id = 9, UserId = 3, MovieId = 11, RentedOn = DateTime.UtcNow.AddMonths(-2) },

            // Basic tier (Hannah) → only 2 rentals this month (still allowed)
            new Rental { Id = 10, UserId = 8, MovieId = 19, RentedOn = DateTime.UtcNow.AddDays(-3) },
            new Rental { Id = 11, UserId = 8, MovieId = 20, RentedOn = DateTime.UtcNow.AddDays(-6) }
        });
        }
        public IEnumerable<Rental> GetByUserId(int userId)
        {
            return _entities.Where(r => r.UserId == userId);
        }

        public IEnumerable<Rental> GetByMovieId(int movieId)
        {
            return _entities.Where(r => r.MovieId == movieId);
        }

        public int GetMonthlyRentalCount(int userId, DateTime monthReference)
        {
            return _entities
        .Where(r => r.UserId == userId &&
                    r.RentedOn.Year == monthReference.Year &&
                    r.RentedOn.Month == monthReference.Month)
        .Count();
        }
    }
}
