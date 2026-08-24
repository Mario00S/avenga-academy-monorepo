using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Mapper;
using VideoRentalStore.Models.Dtos;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class RentalService : IRentalService
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IMovieRepository _movieRepository;

    public RentalService(IRentalRepository rentalRepository, IMovieRepository movieRepository)
    {
        _rentalRepository = rentalRepository;
        _movieRepository = movieRepository;
    }

    /// <summary>
    /// Gets a rental by identifier as a DTO.
    /// </summary>
    public RentalDto? GetById(int id)
    {
        var rental = _rentalRepository.GetById(id);
        if (rental is null)
        {
            return null;
        }

        return MapRentalToDto(rental);
    }

    /// <summary>
    /// Gets rentals for a user as DTOs.
    /// </summary>
    public List<RentalDto> GetByUser(int userId)
    {
        var rentals = _rentalRepository.GetByUserId(userId).ToList();
        var movies = _movieRepository.GetAll().ToList();

        return rentals.Select(rental =>
        {
            var movie = movies.FirstOrDefault(m => m.Id == rental.MovieId);
            return RentalMapper.MapToDto(rental, movie?.Title);
        }).ToList();
    }

    /// <summary>
    /// Creates a rental from a DTO.
    /// </summary>
    public void Create(RentalDto dto)
    {
        var rental = RentalMapper.MapToEntity(dto);
        ResolveMovieIdFromTitle(rental, dto.MovieTitle);
        _rentalRepository.Add(rental);
    }

    /// <summary>
    /// Updates a rental from a DTO.
    /// </summary>
    public void Update(RentalDto dto)
    {
        var existing = _rentalRepository.GetById(dto.Id);
        var rental = RentalMapper.MapToEntity(dto);

        if (existing is not null)
        {
            rental.MovieId = existing.MovieId;
            rental.UserId = existing.UserId;
        }

        ResolveMovieIdFromTitle(rental, dto.MovieTitle);
        _rentalRepository.Update(rental);
    }

    /// <summary>
    /// Gets rentals for a user as DTOs.
    /// </summary>
    public List<RentalDto> GetRentalsByUserId(int userId)
    {
        return GetByUser(userId);
    }

    /// <summary>
    /// Creates a rental for the given user and movie.
    /// </summary>
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

    /// <summary>
    /// Marks a rental as returned.
    /// </summary>
    public void ReturnMovie(int rentalId)
    {
        var rental = _rentalRepository.GetById(rentalId);
        if (rental != null)
        {
            rental.ReturnedOn = DateTime.Now;
            _rentalRepository.Update(rental);
        }
    }

    private RentalDto MapRentalToDto(Rental rental)
    {
        var movie = _movieRepository.GetById(rental.MovieId);
        return RentalMapper.MapToDto(rental, movie?.Title);
    }

    private void ResolveMovieIdFromTitle(Rental rental, string? movieTitle)
    {
        if (string.IsNullOrWhiteSpace(movieTitle))
        {
            return;
        }

        var movie = _movieRepository.GetAll()
            .FirstOrDefault(m => m.Title.Equals(movieTitle, StringComparison.OrdinalIgnoreCase));

        if (movie is not null)
        {
            rental.MovieId = movie.Id;
        }
    }
}
