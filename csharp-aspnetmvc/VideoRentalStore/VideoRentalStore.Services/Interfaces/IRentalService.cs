using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.Services.Interfaces;

public interface IRentalService
{
    /// <summary>
    /// Gets a rental by identifier as a DTO.
    /// </summary>
    RentalDto? GetById(int id);

    /// <summary>
    /// Gets rentals for a user as DTOs.
    /// </summary>
    List<RentalDto> GetByUser(int userId);

    /// <summary>
    /// Creates a rental from a DTO.
    /// </summary>
    void Create(RentalDto dto);

    /// <summary>
    /// Updates a rental from a DTO.
    /// </summary>
    void Update(RentalDto dto);

    /// <summary>
    /// Gets rentals for a user as DTOs.
    /// </summary>
    List<RentalDto> GetRentalsByUserId(int userId);

    /// <summary>
    /// Creates a rental for the given user and movie.
    /// </summary>
    void RentMovie(int userId, int movieId);

    /// <summary>
    /// Marks a rental as returned.
    /// </summary>
    void ReturnMovie(int rentalId);
}
