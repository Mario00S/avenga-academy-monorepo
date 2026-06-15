using TaxiManager9000.DataAccess;
using TaxiManager9000.DataAccess.Interfaces;
using TaxiManager9000.Domain.BaseEntity;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        private IGenericDb<T> _db;

        protected ServiceBase()
        {
            _db = new GenericDb<T>();
        }

        public List<T> GetAll()
        {
            return _db.GetAll();
        }

        public T GetById(int id)
        {
            return _db.GetById(id);
        }

        public List<T> GetFiltered(Func<T, bool> filter)
        {
            return _db.FilterBy(filter);
        }

        public void Insert(T entity)
        {
            _db.Add(entity);
        }

        public bool Update(T entity)
        {
            return _db.Update(entity);
        }

        public void Remove(int id)
        {
            _db.RemoveById(id);
        }

        public void Seed(List<T> items)
        {
            if (_db.GetAll().Count > 0) return;
            items.ForEach(x => _db.Add(x));
        }
    }
}
