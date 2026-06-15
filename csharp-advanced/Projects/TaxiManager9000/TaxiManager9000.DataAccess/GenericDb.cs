using TaxiManager9000.DataAccess.Interfaces;
using TaxiManager9000.Domain.BaseEntity;

namespace TaxiManager9000.DataAccess
{
    public class GenericDb<T> : IGenericDb<T> where T : BaseEntity
    {
        private List<T> _db;
        private int _idCounter;

        public GenericDb()
        {
            _db = new List<T>();
        }

        public List<T> GetAll()
        {
            return _db;
        }

        public T GetById(int id)
        {
            return _db.FirstOrDefault(e => e.Id == id);
        }

        public int Add(T entity)
        {
            entity.Id = ++_idCounter;
            _db.Add(entity);
            return entity.Id;
        }

        public bool Update(T entity)
        {
            try
            {
                int index = _db.FindIndex(e => e.Id == entity.Id);
                if (index == -1) return false;
                _db[index] = entity;
                return true;
                //T entityDb = GetById(entity.Id);
                //entityDb = entity;
                //return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveById(int id)
        {
            try
            {
                T entity = GetById(id);
                _db.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T> FilterBy(Func<T, bool> filter)
        {
            return _db.Where(filter).ToList();
        }
    }
}
