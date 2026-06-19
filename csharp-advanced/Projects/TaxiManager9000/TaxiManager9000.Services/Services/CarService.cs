using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class CarService : ServiceBase<Car>, ICarService
    {
        public CarService() { }

        public List<Car> GetAvailableCars(Shift shift)
        {
            DateTime now = DateTime.Now;

            return GetAll()
                .Where(car =>
                    car.LicensePlateExpieryDate > now && // valid license plate
                    !car.AssignedDrivers.Any(d => d.Shift == shift)) // no driver in this shift
                .ToList();
        }
    }
}
