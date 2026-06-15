namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.BaseEntity;

public class Car : BaseEntity
{
    public string Model { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public DateTime LicensePlateExpieryDate { get; set; }
    public List<Driver> AssignedDrivers { get; set; } = new();

    public override string GetInfo()
    {
        return $"Car model {Model}";
    }
}
