using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IDriverService : IServiceBase<Driver>
    {
        public List<Driver> GetUnassignedDrivers();
        public void AssignDriver(Driver driver, Car car, Shift shift);
        public void UnassignDriver(Driver driver);
    }
}
