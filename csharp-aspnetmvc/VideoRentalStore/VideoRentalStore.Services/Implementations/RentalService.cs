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

    public Rental? GetById(int rentalId)
    {
        return _rentalRepository.GetById(rentalId);
    }

    public IEnumerable<Rental> GetRentalsByUserId(int userId)
    {
        return _rentalRepository.GetByUserId(userId);
    }

    public void RentMovie(int userId, int movieId)
    {
        var existingRental = _rentalRepository
    .GetByUserId(userId)
    .FirstOrDefault(r => r.MovieId == movieId && r.ReturnedOn == null);

        if (existingRental != null)
        {
            throw new InvalidOperationException("Movie already rented by user");
        }

        var rental = new Rental
        {
            UserId = userId,
            MovieId = movieId,
            RentedOn = DateTime.Now,
            ReturnedOn = null
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

