using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
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

    public IEnumerable<Movie> GetPagedAvailableMovies(int pageNumber, int pageSize)
    {
        return _repository.GetAvailableMovies()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }


    public IEnumerable<Movie> FilterMovies(string? title, Genre? genre, string? castName)
    {
        Console.WriteLine($"DEBUG Service Inputs: title={title}, genre={genre}, castName={castName}");

        var movies = _repository.GetAvailableMovies();

        // 🔹 Cast filter using GetCastForMovie
        if (!string.IsNullOrWhiteSpace(castName))
        {
            movies = movies.Where(m =>
            {
                var castMembers = GetCastForMovie(m.Id).ToList();
                Console.WriteLine($"DEBUG {m.Title} cast = {string.Join(", ", castMembers.Select(c => c.Name))}");
                return castMembers.Any(c => c.Name.Contains(castName, StringComparison.OrdinalIgnoreCase));
            });
        }

        // 🔹 Title filter
        if (!string.IsNullOrWhiteSpace(title))
        {
            movies = movies.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        // 🔹 Genre filter
        if (genre.HasValue)
        {
            movies = movies.Where(m => m.Genre == genre.Value);
        }

        var result = movies.ToList();
        Console.WriteLine($"DEBUG Result count: {result.Count}");

        if (!result.Any())
        {
            Console.WriteLine("DEBUG: No movies matched the filters.");            
        }
        return result;
    }




    public IEnumerable<Movie> GetPagedFilteredMovies
        (string? title, Genre? genre, string? castName, int pageNumber, int pageSize)
    {
        var filteredMovies = FilterMovies(title, genre, castName);

        return filteredMovies
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

}

