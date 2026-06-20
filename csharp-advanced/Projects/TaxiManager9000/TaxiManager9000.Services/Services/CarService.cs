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

        public double GetShiftCoveragePercentage(Car car)
        {
            // Count distinct shifts covered by drivers assigned to this car
            int coveredShifts = car.AssignedDrivers
                .Where(d => d.Shift != Shift.NoShift)
                .Select(d => d.Shift)
                .Distinct()
                .Count();

            // There are 3 possible shifts (Morning, Afternoon, Evening)
            return (coveredShifts / 3.0) * 100;
        }
    }
}
