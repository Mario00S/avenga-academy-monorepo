using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class RentalService : IRentalService
{
    private readonly IRentalRepository _rentalRepository;

    public RentalService(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }

    public IEnumerable<Rental> GetRentalsByUserId(int userId)
    {
        return _rentalRepository.GetByUserId(userId);
    }

    public void RentMovie(int userId, int movieId)
    {
        //check if the movie is rented and not returned yet
        var existingRental = _rentalRepository
            .GetByUserId(userId)
            .FirstOrDefault(r => r.MovieId == movieId && r.ReturnedOn == default);

        if (existingRental != null)
        {
            throw new InvalidOperationException("You have already rented this movie");
        }

        var rental = new Rental
        {
            UserId = userId,
            MovieId = movieId,
            RentedOn = DateTime.Now
        };
        _rentalRepository.Add(rental);
    }

    public void ReturnMovie(int rentalId)
    {
        var rental = _rentalRepository.GetById(rentalId);
        if (rental != null)
        {
            rental.ReturnedOn = DateTime.Now;
            _rentalRepository.Update(rental);
        }
    }
}

