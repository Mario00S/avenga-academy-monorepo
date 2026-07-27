using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Movie> GetAvailableMovies()
    {
        // Business rule: only return movies marked as available
        return _repository.GetAll().Where(m => m.IsAvailable);
    }

    public Movie GetMovieById(int id)
    {
        return _repository.GetById(id);
    }

    public void RentMovie(int movieId, int? userId)
    {
        if (userId == null)
        {
            throw new UnauthorizedAccessException("User must be logged in to remnt movies");
        }
        var movie = _repository.GetById(movieId);
        if (movie == null || !movie.IsAvailable)
            throw new InvalidOperationException("Movie not available");

        // Business rule: once rented, mark as unavailable
        movie.IsAvailable = false;
        _repository.Update(movie);
    }
}

