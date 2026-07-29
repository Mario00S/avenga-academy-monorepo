using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Services.Interfaces;

namespace VideoRentalStore.Services.Implementations;

public class CastService : ICastService
{
    private readonly ICastRepository _repository;

    public CastService(ICastRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Cast> GetCastByMovieId(int movieId)
    {
        return _repository.GetByMovieId(movieId);
    }
}
