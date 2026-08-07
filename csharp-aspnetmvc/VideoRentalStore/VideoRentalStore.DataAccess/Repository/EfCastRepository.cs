using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Repository;

public class EfCastRepository : EfRepository<Cast>, ICastRepository
{
    private readonly VideoRentalDbContext _context;

    public EfCastRepository(VideoRentalDbContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Cast> GetByMovieId(int movieId)
    {
        return _context.Casts
            .Include(c => c.Movie) // eager load Movie
            .Where(c => c.Movie != null && c.Movie.Id == movieId)
            .ToList();
    }
}

