namespace VideoRentalStore.DataAccess.Repository;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Base;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly VideoRentalDbContext _context;
    private readonly DbSet<T> _dbSet;

    public EfRepository(VideoRentalDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public T? GetById(int id) => _dbSet.Find(id);

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
