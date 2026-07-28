using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.Services.Interfaces;

public interface IRentalService
{
    IEnumerable<Rental> GetRentalsByUserId(int userId);
    void RentMovie(int userId, int movieId);
    void ReturnMovie(int rentalId);
    Rental? GetById(int rentalId);
}

