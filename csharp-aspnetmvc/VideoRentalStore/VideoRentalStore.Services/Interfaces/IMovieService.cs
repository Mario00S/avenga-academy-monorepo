using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Services.Interfaces;

public interface IMovieService
{
    IEnumerable<Movie> GetAllMovies();
    IEnumerable<Movie> GetAvailableMovies();
    Movie GetMovieById(int id);
    void RentMovie(int movieId, int? userId);
    //user can be nullable doing this due to error in the service
    IEnumerable<Movie> GetPagedAvailableMovies(int pageNumber, int pageSize);
    IEnumerable<Movie> GetPagedFilteredMovies
        (string? title, Genre? genre, string? castName, int pageNumber, int pageSize);
    void MarkAvailable(int movieId);
    IEnumerable<Cast> GetCastForMovie(int movieId);
    IEnumerable<Movie> FilterMovies(string? title, Genre? genre, string? castName);
}

