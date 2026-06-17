namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.BaseEntity;

public class Car : BaseEntity
{
    public Car(string model, string licensePlate, DateTime licensePlateExpieryDate)
    {
        Model = model;
        LicensePlate = licensePlate;
        LicensePlateExpieryDate = licensePlateExpieryDate;
    }

    public Car()
    {
        
    }

    public string Model { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public DateTime LicensePlateExpieryDate { get; set; }
    public List<Driver> AssignedDrivers { get; set; } = new();

    public override string GetInfo()
    {
        return $"Car model {Model}";
    }
}
