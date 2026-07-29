using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    private readonly ICastRepository _castRepository;

    public MovieService(IMovieRepository repository, ICastRepository castRepository)
    {
        _repository = repository;
        _castRepository = castRepository;
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
        if (movie == null || movie.Quantity <= 0) 
        { 
            throw new InvalidOperationException("Movie not available");
        }
        movie.Quantity--;
        if (movie.Quantity == 0)
        {
            movie.IsAvailable = false;
        }
        _repository.Update(movie);
    }
    public IEnumerable<Movie> GetPagedAvailableMovies(int pageNumber, int pageSize)
    {
        return _repository.GetAvailableMovies()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _repository.GetAll();
    }

    public void MarkAvailable(int movieId)
    {
        var movie = _repository.GetById(movieId);
        if (movie == null)
        {
            throw new InvalidOperationException("Movie not found");
        }

        movie.Quantity++;

        if (movie.Quantity > 0)
        {
        movie.IsAvailable = true;

        }

        _repository.Update(movie);
    }

    public IEnumerable<Cast> GetCastForMovie(int movieId)
    {
        return _castRepository.GetByMovieId(movieId);
    }

}

