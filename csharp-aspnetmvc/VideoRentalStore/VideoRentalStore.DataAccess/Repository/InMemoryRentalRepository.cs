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
                new Rental { Id = 1, UserId = 1, MovieId = 2, RentedOn = DateTime.Now.AddDays(-5) }, // Alice rented Inception
                new Rental { Id = 2, UserId = 3, MovieId = 5, RentedOn = DateTime.Now.AddDays(-2) }, // Charlie rented Interstellar
                new Rental { Id = 3, UserId = 4, MovieId = 8, RentedOn = DateTime.Now.AddDays(-1) }, // Diana rented Avengers: Endgame
                new Rental { Id = 4, UserId = 6, MovieId = 10, RentedOn = DateTime.Now.AddDays(-7) }, // Fiona rented Spirited Away
                new Rental { Id = 5, UserId = 8, MovieId = 19, RentedOn = DateTime.Now.AddDays(-3) }  // Hannah rented Amélie
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
    }
}
