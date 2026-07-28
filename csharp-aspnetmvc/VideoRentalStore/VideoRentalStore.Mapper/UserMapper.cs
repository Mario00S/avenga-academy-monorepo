using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Models.ViewModels;

namespace VideoRentalStore.Mapper;

public static class UserMapper
{
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
