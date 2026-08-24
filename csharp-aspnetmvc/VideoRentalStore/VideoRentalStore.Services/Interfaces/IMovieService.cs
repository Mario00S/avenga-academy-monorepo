using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.Services.Interfaces;

public interface IMovieService
{
    /// <summary>
    /// Gets movie details by identifier.
    /// </summary>
    MovieDetailsDto? GetById(int id);

    /// <summary>
    /// Gets all movies as list DTOs.
    /// </summary>
    List<MovieListDto> GetAll();

    /// <summary>
    /// Creates a movie from a details DTO.
    /// </summary>
    void Create(MovieDetailsDto dto);

    /// <summary>
    /// Updates a movie from a details DTO.
    /// </summary>
    void Update(MovieDetailsDto dto);

    /// <summary>
    /// Deletes a movie by identifier.
    /// </summary>
    void Delete(int id);

    /// <summary>
    /// Gets all movies as list DTOs.
    /// </summary>
    List<MovieListDto> GetAllMovies();

    /// <summary>
    /// Gets available movies as list DTOs.
    /// </summary>
    List<MovieListDto> GetAvailableMovies();

    /// <summary>
    /// Gets movie details by identifier.
    /// </summary>
    MovieDetailsDto? GetMovieById(int id);

    /// <summary>
    /// Decrements quantity and marks the movie unavailable when stock reaches zero.
    /// </summary>
    void RentMovie(int movieId, int? userId);

    /// <summary>
    /// Gets a page of available movies as list DTOs.
    /// </summary>
    List<MovieListDto> GetPagedAvailableMovies(int pageNumber, int pageSize);

    /// <summary>
    /// Gets a page of filtered movies as list DTOs.
    /// </summary>
    List<MovieListDto> GetPagedFilteredMovies(
        string? title, Genre? genre, string? castName, int pageNumber, int pageSize);

    /// <summary>
    /// Increments quantity and marks the movie available.
    /// </summary>
    void MarkAvailable(int movieId);

    /// <summary>
    /// Gets cast members for a movie as DTOs.
    /// </summary>
    List<CastDto> GetCastForMovie(int movieId);

    /// <summary>
    /// Filters available movies and returns list DTOs.
    /// </summary>
    List<MovieListDto> FilterMovies(string? title, Genre? genre, string? castName);
}
