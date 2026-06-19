using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;

namespace TaxiManager9000.Services.Interfaces
{
    public interface ICarService : IServiceBase<Car>
    {
        List<Car> GetAvailableCars(Shift shift);

    }
}
