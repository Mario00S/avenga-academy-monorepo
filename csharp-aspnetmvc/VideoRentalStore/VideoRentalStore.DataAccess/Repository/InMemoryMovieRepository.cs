using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.DataAccess.Repository;

public class InMemoryMovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies;

    public InMemoryMovieRepository()
    {
        _movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "The Matrix", Genre = Genre.SciFi, IsAvailable = true },
            new Movie { Id = 2, Title = "Inception", Genre = Genre.SciFi, IsAvailable = false },
            new Movie { Id = 3, Title = "Titanic", Genre = Genre.Drama, IsAvailable = true },
            new Movie { Id = 4, Title = "The Godfather", Genre = Genre.Drama, IsAvailable = false },
            new Movie { Id = 5, Title = "Interstellar", Genre = Genre.SciFi, IsAvailable = true },
            new Movie { Id = 6, Title = "The Dark Knight", Genre = Genre.Action, IsAvailable = true },
            new Movie { Id = 7, Title = "Pulp Fiction", Genre = Genre.Drama, IsAvailable = false },
            new Movie { Id = 8, Title = "Avengers: Endgame", Genre = Genre.Action, IsAvailable = true }
        };
    }

    public IEnumerable<Movie> GetAll() => _movies;

    public Movie GetById(int id) => _movies.FirstOrDefault(m => m.Id == id);

    public void Add(Movie movie)
    {
        movie.Id = _movies.Max(m => m.Id) + 1;
        _movies.Add(movie);
    }

    public void Remove(int id)
    {
        var movie = GetById(id);
        if (movie != null)
            _movies.Remove(movie);
    }

    public void Update(Movie movie)
    {
        var existing = GetById(movie.Id);
        if (existing != null)
        {
            existing.Title = movie.Title;
            existing.Genre = movie.Genre;
            existing.IsAvailable = movie.IsAvailable;
        }
    }
}

