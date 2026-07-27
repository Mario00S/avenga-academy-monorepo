using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetAvailableMovies();
    }
}
