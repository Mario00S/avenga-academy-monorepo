using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Models.Dtos;
using VideoRentalStore.Models.ViewModels;

namespace VideoRentalStore.Mapper;

public static class UserMapper
{
    public static UserDto MapToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Age = user.Age,
            CardNumber = user.CardNumber,
            CreatedOn = user.CreatedOn,
            SubscriptionExpiresAt = user.SubscriptionExpiresAt,
            RemainingFreeRentals = user.RemainingFreeRentals,
            SubscriptionType = user.SubscriptionType,
            IsSubscriptionExpired = user.IsSubscriptionExpired
        };
    }

    public static List<UserDto> MapToDto(IEnumerable<User> users)
    {
        return users?.Select(MapToDto).ToList() ?? new List<UserDto>();
    }

    public static User MapToEntity(UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Age = dto.Age,
            CardNumber = dto.CardNumber,
            CreatedOn = dto.CreatedOn,
            SubscriptionExpiresAt = dto.SubscriptionExpiresAt,
            RemainingFreeRentals = dto.RemainingFreeRentals,
            SubscriptionType = dto.SubscriptionType
        };
    }

    public static UserProfileViewModel MapUserToProfile(User user, IEnumerable<Rental> rentals, IEnumerable<Movie> movies)
    {
        var rentedMovies = rentals.Select(r =>
        {
            var movie = movies.FirstOrDefault(m => m.Id == r.MovieId);
            return new MovieViewModel
            {
                Title = movie?.Title ?? "Unknown",
                Genre = movie?.Genre.ToString() ?? "Unknown",
                RentedOn = r.RentedOn,
                ReturnedOn = r.ReturnedOn,
                RentalId = r.Id
            };
        }).ToList();

        return new UserProfileViewModel
        {
            FullName = user.FullName,
            Age = user.Age,
            CardNumber = user.CardNumber,
            CreatedOn = user.CreatedOn,
            IsSubscriptionExpired = user.IsSubscriptionExpired,
            SubscriptionType = user.SubscriptionType,
            RentedMovies = rentedMovies
        };
    }
}
