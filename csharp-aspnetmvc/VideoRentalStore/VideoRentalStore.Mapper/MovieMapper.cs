using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Models.ViewModels;

namespace VideoRentalStore.Mapper
{
    public static class MovieMapper
    {
        public static MovieDetailsViewModel MapMovieToDetails(Movie movie, IEnumerable<Cast> castMembers)
        {
            return new MovieDetailsViewModel
            {
                Movie = movie,
                CastMembers = castMembers.ToList()
            };
        }
    }
}
