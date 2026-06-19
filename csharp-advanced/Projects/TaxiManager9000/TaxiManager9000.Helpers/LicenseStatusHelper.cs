namespace TaxiManager9000.Helpers;

public static class LicenseStatusHelper
{
    public static (ConsoleColor color, string label) GetLicenseStatus(DateTime expiryDate)
    {
        TimeSpan timeToExpiry = expiryDate - DateTime.Now;

        if (expiryDate < DateTime.Now)
        {
            return (ConsoleColor.Red, "Red"); // Expired
        }
        else if (timeToExpiry.TotalDays <= 90)
        {
            return (ConsoleColor.Yellow, "Yellow"); // 3 months to expiry
        }
        else
        {
            return (ConsoleColor.Green, "Green"); // Valid
        }
    }
}
