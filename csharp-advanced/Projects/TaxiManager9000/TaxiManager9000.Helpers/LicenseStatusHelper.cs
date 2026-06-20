namespace TaxiManager9000.Helpers;

public static class LicenseStatusHelper
{
    public static (ConsoleColor color, string label) GetLicenseStatus(DateTime expiryDate)
    {
        TimeSpan timeToExpiry = expiryDate - DateTime.Now;

        if (expiryDate < DateTime.Now)
        {
            return (ConsoleColor.Red, "Expired"); // Expired
        }
        else if (expiryDate <= DateTime.Now.AddMonths(3))
        {
            return (ConsoleColor.Yellow, "3 months to expiry"); // 3 months to expiry
        }
        else
        {
            return (ConsoleColor.Green, "Valid"); // Valid
        }
    }
}
