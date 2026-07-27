using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.Services.Interfaces;

public interface IMovieService
{
    IEnumerable<Movie> GetAvailableMovies();
    Movie GetMovieById(int id);
    void RentMovie(int movieId, int? userId);
    //user can be nullable doing this due to error in the service
}

