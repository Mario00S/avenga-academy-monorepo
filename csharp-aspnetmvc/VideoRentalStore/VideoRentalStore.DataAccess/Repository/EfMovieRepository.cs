using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Repository
{
    public class EfMovieRepository : EfRepository<Movie>, IMovieRepository
    {
        private readonly VideoRentalDbContext _context;

        public EfMovieRepository(VideoRentalDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAvailableMovies()
        {
            return _context.Movies
                .Where(m => m.IsAvailable)
                .ToList();
        }

        public IEnumerable<Movie> GetPagedMovies(int pageNumber, int pageSize)
        {
            return _context.Movies
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
