using TaxiManager9000.Domain.BaseEntity;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IServiceBase<T> where T : BaseEntity
    {
        List<T> GetAll();
        List<T> GetFiltered(Func<T, bool> filter);
        T GetById(int id);
        void Insert(T entity);
        bool Update(T entity);
        void Remove(int id);
        void Seed(List<T> items);
    }
}
