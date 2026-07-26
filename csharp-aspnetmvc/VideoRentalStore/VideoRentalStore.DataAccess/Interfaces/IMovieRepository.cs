using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Remove(int id);
        void Update(Movie movie);
    }
}
