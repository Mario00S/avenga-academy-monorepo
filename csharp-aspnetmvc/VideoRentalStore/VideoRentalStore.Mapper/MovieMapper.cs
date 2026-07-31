using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Models.ViewModels;

namespace VideoRentalStore.Mapper;

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
    public static MovieFilterViewModel MapMoviesToFilterViewModel(
           IEnumerable<Movie> movies,
           int currentPage,
           int totalMovies,
           string? title = null,
           Genre? genre = null,
           string? castName = null,
           int pageSize = 10)
    {
        return new MovieFilterViewModel
        {
            Movies = movies,
            CurrentPage = currentPage,
            TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize),
            TitleFilter = title,
            GenreFilter = genre,
            CastFilter = castName
            };
        }
    }
