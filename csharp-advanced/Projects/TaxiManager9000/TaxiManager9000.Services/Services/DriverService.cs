using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class DriverService : ServiceBase<Driver>, IDriverService
    {
        public DriverService() { }

        // Example domain-specific method:
        public List<Driver> GetUnassignedDrivers()
        {
            return GetAll()
                .Where(d => d.Car == null) // driver has no car assigned
                .ToList();
        }

        public void AssignDriver(Driver driver, Car car, Shift shift)
        {
            driver.Car = car;
            driver.Shift = shift;

            // keep car’s AssignedDrivers list in sync
            car.AssignedDrivers.Add(driver);

            Update(driver);
        }

        public void UnassignDriver(Driver driver)
        {
            if (driver.Car != null)
            {
                driver.Car.AssignedDrivers.Remove(driver);
                driver.Car = null;
            }

            driver.Shift = Shift.NoShift; // assuming you have a "None" enum value
            Update(driver);
        }
    }
}
