using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.Services.Interfaces;

public interface IMovieService
{
    /// <summary>
    /// Gets a movie by identifier as a DTO.
    /// </summary>
    MovieDto? GetById(int id);

    /// <summary>
    /// Gets all movies as DTOs.
    /// </summary>
    List<MovieDto> GetAll();

    /// <summary>
    /// Creates a movie from a DTO.
    /// </summary>
    void Create(MovieDto dto);

    /// <summary>
    /// Updates a movie from a DTO.
    /// </summary>
    void Update(MovieDto dto);

    /// <summary>
    /// Deletes a movie by identifier.
    /// </summary>
    void Delete(int id);

    /// <summary>
    /// Gets all movies as DTOs.
    /// </summary>
    List<MovieDto> GetAllMovies();

    /// <summary>
    /// Gets available movies as DTOs.
    /// </summary>
    List<MovieDto> GetAvailableMovies();

    /// <summary>
    /// Gets a movie by identifier as a DTO.
    /// </summary>
    MovieDto? GetMovieById(int id);

    /// <summary>
    /// Decrements quantity and marks the movie unavailable when stock reaches zero.
    /// </summary>
    void RentMovie(int movieId, int? userId);

    /// <summary>
    /// Gets a page of available movies as DTOs.
    /// </summary>
    List<MovieDto> GetPagedAvailableMovies(int pageNumber, int pageSize);

    /// <summary>
    /// Gets a page of filtered movies as DTOs.
    /// </summary>
    List<MovieDto> GetPagedFilteredMovies(
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
    /// Filters available movies and returns DTOs.
    /// </summary>
    List<MovieDto> FilterMovies(string? title, Genre? genre, string? castName);
}
