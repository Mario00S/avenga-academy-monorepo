using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Mapper;
using VideoRentalStore.Models.Dtos;
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

    /// <summary>
    /// Gets movie details by identifier.
    /// </summary>
    public MovieDetailsDto? GetById(int id)
    {
        var movie = _repository.GetById(id);
        if (movie is null)
        {
            return null;
        }

        return MovieMapper.MapToDetailsDto(movie);
    }

    /// <summary>
    /// Gets all movies as list DTOs.
    /// </summary>
    public List<MovieListDto> GetAll()
    {
        var movies = _repository.GetAll();
        return MovieMapper.MapToListDto(movies);
    }

    /// <summary>
    /// Creates a movie from a details DTO.
    /// </summary>
    public void Create(MovieDetailsDto dto)
    {
        var movie = MovieMapper.MapToEntity(dto);
        _repository.Add(movie);
    }

    /// <summary>
    /// Updates a movie from a details DTO.
    /// </summary>
    public void Update(MovieDetailsDto dto)
    {
        var movie = MovieMapper.MapToEntity(dto);
        _repository.Update(movie);
    }

    /// <summary>
    /// Deletes a movie by identifier.
    /// </summary>
    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    /// <summary>
    /// Gets all movies as list DTOs.
    /// </summary>
    public List<MovieListDto> GetAllMovies()
    {
        return GetAll();
    }

    /// <summary>
    /// Gets available movies as list DTOs.
    /// </summary>
    public List<MovieListDto> GetAvailableMovies()
    {
        // Business rule: only return movies marked as available
        var movies = _repository.GetAll().Where(m => m.IsAvailable);
        return MovieMapper.MapToListDto(movies);
    }

    /// <summary>
    /// Gets movie details by identifier.
    /// </summary>
    public MovieDetailsDto? GetMovieById(int id)
    {
        return GetById(id);
    }

    /// <summary>
    /// Decrements quantity and marks the movie unavailable when stock reaches zero.
    /// </summary>
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

    /// <summary>
    /// Increments quantity and marks the movie available.
    /// </summary>
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

    /// <summary>
    /// Gets cast members for a movie as DTOs.
    /// </summary>
    public List<CastDto> GetCastForMovie(int movieId)
    {
        return _castRepository.GetByMovieId(movieId)
            .Select(c => new CastDto
            {
                Name = c.Name,
                Role = c.Role.ToString()
            })
            .ToList();
    }

    /// <summary>
    /// Gets a page of available movies as list DTOs.
    /// </summary>
    public List<MovieListDto> GetPagedAvailableMovies(int pageNumber, int pageSize)
    {
        var movies = _repository.GetAvailableMovies()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return MovieMapper.MapToListDto(movies);
    }

    /// <summary>
    /// Filters available movies and returns list DTOs.
    /// </summary>
    public List<MovieListDto> FilterMovies(string? title, Genre? genre, string? castName)
    {
        var result = FilterDomainMovies(title, genre, castName);
        return MovieMapper.MapToListDto(result);
    }

    /// <summary>
    /// Gets a page of filtered movies as list DTOs.
    /// </summary>
    public List<MovieListDto> GetPagedFilteredMovies(
        string? title, Genre? genre, string? castName, int pageNumber, int pageSize)
    {
        var filteredMovies = FilterDomainMovies(title, genre, castName);

        var paged = filteredMovies
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return MovieMapper.MapToListDto(paged);
    }

    private List<Movie> FilterDomainMovies(string? title, Genre? genre, string? castName)
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
}
