using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;
using VideoRentalStore.Models.Dtos;
using VideoRentalStore.Models.ViewModels;

namespace VideoRentalStore.Mapper;

public static class MovieMapper
{
    public static MovieDetailsDto MapToDetailsDto(Movie movie)
    {
        return new MovieDetailsDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre.ToString(),
            Language = movie.Language.ToString(),
            ReleaseDate = movie.ReleaseDate,
            Length = movie.Length,
            AgeRestriction = movie.AgeRestriction,
            CastMembers = movie.CastMembers?.Select(c => c.Name).ToList() ?? new List<string>()
        };
    }

    public static MovieListDto MapToListDto(Movie movie)
    {
        return new MovieListDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre.ToString(),
            Language = movie.Language.ToString(),
            IsAvailable = movie.IsAvailable
        };
    }

    public static List<MovieDetailsDto> MapToDetailsDto(IEnumerable<Movie> movies)
    {
        return movies?.Select(MapToDetailsDto).ToList() ?? new List<MovieDetailsDto>();
    }

    public static List<MovieListDto> MapToListDto(IEnumerable<Movie> movies)
    {
        return movies?.Select(MapToListDto).ToList() ?? new List<MovieListDto>();
    }

    public static Movie MapToEntity(MovieDetailsDto dto)
    {
        return new Movie
        {
            Id = dto.Id,
            Title = dto.Title,
            Genre = string.IsNullOrWhiteSpace(dto.Genre)
                ? default
                : Enum.Parse<Genre>(dto.Genre),
            Language = string.IsNullOrWhiteSpace(dto.Language)
                ? default
                : Enum.Parse<Language>(dto.Language),
            ReleaseDate = dto.ReleaseDate,
            Length = dto.Length,
            AgeRestriction = dto.AgeRestriction,
            CastMembers = dto.CastMembers?
                .Select(name => new Cast { Name = name })
                .ToList() ?? new List<Cast>()
        };
    }

    public static Movie MapToEntity(MovieListDto dto)
    {
        return new Movie
        {
            Id = dto.Id,
            Title = dto.Title,
            Genre = string.IsNullOrWhiteSpace(dto.Genre)
                ? default
                : Enum.Parse<Genre>(dto.Genre),
            Language = string.IsNullOrWhiteSpace(dto.Language)
                ? default
                : Enum.Parse<Language>(dto.Language),
            IsAvailable = dto.IsAvailable
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
}
