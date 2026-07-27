using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.DataAccess.Repository;

public class InMemoryMovieRepository : InMemoryRepository<Movie>, IMovieRepository
{
    public InMemoryMovieRepository()
    {
        _entities.AddRange(new List<Movie>
            {
                new Movie { Id = 1, Title = "The Matrix", Genre = Genre.SciFi, IsAvailable = true },
                new Movie { Id = 2, Title = "Inception", Genre = Genre.SciFi, IsAvailable = false },
                new Movie { Id = 3, Title = "Titanic", Genre = Genre.Drama, IsAvailable = true },
                new Movie { Id = 4, Title = "The Godfather", Genre = Genre.Drama, IsAvailable = false },
                new Movie { Id = 5, Title = "Interstellar", Genre = Genre.SciFi, IsAvailable = true },
                new Movie { Id = 6, Title = "The Dark Knight", Genre = Genre.Action, IsAvailable = true },
                new Movie { Id = 7, Title = "Pulp Fiction", Genre = Genre.Drama, IsAvailable = false },
                new Movie { Id = 8, Title = "Avengers: Endgame", Genre = Genre.Action, IsAvailable = true }
            });
    }
    public IEnumerable<Movie> GetAvailableMovies()
    {
       return _entities.Where(m => m.IsAvailable);
    }
}

