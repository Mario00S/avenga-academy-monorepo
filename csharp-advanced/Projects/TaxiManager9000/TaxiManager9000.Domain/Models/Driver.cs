namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.BaseEntity;

public class Driver : BaseEntity
{
    public Driver(string firstName, string lastName, Shift shift, Car? car, string license, DateTime licenseExpieryDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Shift = shift;
        Car = car;
        License = license;
        LicenseExpieryDate = licenseExpieryDate;
    }

    public Driver()
    {
        
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Shift Shift { get; set; }
    public Car? Car { get; set; }
    public string License { get; set; } = string.Empty;
    public DateTime LicenseExpieryDate { get; set; }
    public DateTime DateTime { get; }


    //Driver driver1 = new Driver("Romario", "Walsh", Shift.NoShift, null, "LC12456123", new DateTime(2023, 11, 5));



    public override string GetInfo()
    {
        return $"Driver {FirstName} {LastName} with license {License}!";
    }
}
