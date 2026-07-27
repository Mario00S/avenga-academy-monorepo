namespace VideoRentalStore.DataAccess.Repository;

using System.Collections.Generic;
using System.Linq;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Base;
using VideoRentalStore.Domain.Entities;

public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly List<T> _entities = new();

    public IEnumerable<T> GetAll() => _entities;

    public T GetById(int id) => _entities.FirstOrDefault(e => e.Id == id);

    public void Add(T entity)
    {
        entity.Id = _entities.Any() ? _entities.Max(e => e.Id) + 1 : 1;
        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        var existing = GetById(entity.Id);
        if (existing != null)
        {
            _entities.Remove(existing);
            _entities.Add(entity);
        }
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
            _entities.Remove(entity);
    }
}

