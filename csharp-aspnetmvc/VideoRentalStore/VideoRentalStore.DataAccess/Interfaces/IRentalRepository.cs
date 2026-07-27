using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        IEnumerable<Rental> GetByUserId(int userId);
        IEnumerable<Rental> GetByMovieId(int movieId);
    }
}
