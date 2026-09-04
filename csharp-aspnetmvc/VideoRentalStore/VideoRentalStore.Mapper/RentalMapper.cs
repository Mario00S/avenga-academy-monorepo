using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.Mapper;

public static class RentalMapper
{
    public static RentalDto MapToDto(Rental rental)
    {
        return new RentalDto
        {
            Id = rental.Id,
            MovieId = rental.MovieId,
            UserId = rental.UserId,
            MovieTitle = string.Empty,
            RentedOn = rental.RentedOn,
            ReturnedOn = rental.ReturnedOn
        };
    }

    public static RentalDto MapToDto(Rental rental, string? movieTitle)
    {
        return new RentalDto
        {
            Id = rental.Id,
            MovieId = rental.MovieId,
            UserId = rental.UserId,
            MovieTitle = movieTitle ?? string.Empty,
            RentedOn = rental.RentedOn,
            ReturnedOn = rental.ReturnedOn
        };
    }

    public static List<RentalDto> MapToDto(IEnumerable<Rental> rentals)
    {
        return rentals?.Select(MapToDto).ToList() ?? new List<RentalDto>();
    }

    public static Rental MapToEntity(RentalDto dto)
    {
        return new Rental
        {
            Id = dto.Id,
            MovieId = dto.MovieId,
            UserId = dto.UserId,
            RentedOn = dto.RentedOn,
            ReturnedOn = dto.ReturnedOn
        };
    }
}
