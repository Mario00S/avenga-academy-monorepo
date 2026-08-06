using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.DataAccess.Repository
{
    public class EfRentalRepository : EfRepository<Rental>, IRentalRepository
    {
        private readonly VideoRentalDbContext _context;

        public EfRentalRepository(VideoRentalDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Rental> GetByUserId(int userId)
        {
            return _context.Rentals
                .Where(r => r.UserId == userId)
                .ToList();
        }

        public IEnumerable<Rental> GetByMovieId(int movieId)
        {
            return _context.Rentals
                .Where(r => r.MovieId == movieId)
                .ToList();
        }

        public int GetMonthlyRentalCount(int userId, DateTime monthReference)
        {
            return _context.Rentals
                .Where(r => r.UserId == userId &&
                            r.RentedOn.Year == monthReference.Year &&
                            r.RentedOn.Month == monthReference.Month)
                .Count();
        }
    }
}
