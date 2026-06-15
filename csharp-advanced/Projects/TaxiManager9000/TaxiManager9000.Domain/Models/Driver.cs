namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.BaseEntity;

public class Driver : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Shift Shift { get; set; }
    public Car? Car { get; set; }
    public string License { get; set; } = string.Empty;
    public DateTime LicenseExpieryDate { get; set; }
    public DateTime DateTime { get; }

    public override string GetInfo()
    {
        return $"Driver {FirstName} {LastName} with license {License}!";
    }
}
