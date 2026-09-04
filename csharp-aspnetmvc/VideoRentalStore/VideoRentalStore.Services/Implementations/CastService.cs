using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Models.Dtos;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class CastService : ICastService
{
    private readonly ICastRepository _repository;

    public CastService(ICastRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets cast members for a movie as DTOs.
    /// </summary>
    public List<CastDto> GetCastByMovieId(int movieId)
    {
        return _repository.GetByMovieId(movieId)
            .Select(c => new CastDto
            {
                Id = c.Id,
                MovieId = c.MovieId,
                Name = c.Name,
                Role = c.Role
            })
            .ToList();
    }
}
