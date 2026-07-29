using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Interfaces
{
    public interface ICastRepository : IRepository<Cast>
    {
        IEnumerable<Cast> GetByMovieId(int movieId);
        // Returning IEnumerable here because the repository only needs to expose a read-only sequence of Casts,
        // while ICollection in the Movie entity allows EF Core to add/remove Cast members directly.
    }
}
