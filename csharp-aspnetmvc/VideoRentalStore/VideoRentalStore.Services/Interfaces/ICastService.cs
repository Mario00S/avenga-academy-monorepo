using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.Services.Interfaces;

public interface ICastService
{
    /// <summary>
    /// Gets cast members for a movie as DTOs.
    /// </summary>
    List<CastDto> GetCastByMovieId(int movieId);
}
