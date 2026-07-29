using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.Services.Interfaces;

public interface ICastService
{
    IEnumerable<Cast> GetCastByMovieId(int movieId);
}
