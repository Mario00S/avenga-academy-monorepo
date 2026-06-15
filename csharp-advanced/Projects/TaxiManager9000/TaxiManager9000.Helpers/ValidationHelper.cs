namespace TaxiManager9000.Helpers
{
    public static class ValidationHelper
    {
        public static int ValidateNumberInput(string inputNumber, int range)
        {
            bool isValidInt = int.TryParse(inputNumber, out int value);
            if (value >= 1 && value <= range)
            {
                return value;
            }
            return -1;
        }

        public static bool ValidateStringInput(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }
}
