using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Models.Dtos;
using VideoRentalStore.Models.ViewModels;

namespace VideoRentalStore.Mapper;

public static class MovieMapper
{
    public static MovieDto MapToDto(Movie movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            Language = movie.Language,
            IsAvailable = movie.IsAvailable,
            ReleaseDate = movie.ReleaseDate,
            Length = movie.Length,
            AgeRestriction = movie.AgeRestriction,
            Quantity = movie.Quantity,
            CastMembers = movie.CastMembers?
                .Select(MapCastToDto)
                .ToList() ?? new List<CastDto>()
        };
    }

    public static List<MovieDto> MapToDto(IEnumerable<Movie> movies)
    {
        return movies?.Select(MapToDto).ToList() ?? new List<MovieDto>();
    }

    public static MovieDto MapToDetailsDto(Movie movie) => MapToDto(movie);

    public static MovieDto MapToListDto(Movie movie) => MapToDto(movie);

    public static List<MovieDto> MapToDetailsDto(IEnumerable<Movie> movies) => MapToDto(movies);

    public static List<MovieDto> MapToListDto(IEnumerable<Movie> movies) => MapToDto(movies);

    public static Movie MapToEntity(MovieDto dto)
    {
        return new Movie
        {
            Id = dto.Id,
            Title = dto.Title,
            Genre = dto.Genre,
            Language = dto.Language,
            IsAvailable = dto.IsAvailable,
            ReleaseDate = dto.ReleaseDate,
            Length = dto.Length,
            AgeRestriction = dto.AgeRestriction,
            Quantity = dto.Quantity,
            CastMembers = dto.CastMembers?
                .Select(MapCastToEntity)
                .ToList() ?? new List<Cast>()
        };
    }

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

    private static CastDto MapCastToDto(Cast cast)
    {
        return new CastDto
        {
            Id = cast.Id,
            MovieId = cast.MovieId,
            Name = cast.Name,
            Role = cast.Role
        };
    }

    private static Cast MapCastToEntity(CastDto dto)
    {
        return new Cast
        {
            Id = dto.Id,
            MovieId = dto.MovieId,
            Name = dto.Name,
            Role = dto.Role
        };
    }
}
