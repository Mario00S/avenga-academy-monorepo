namespace Library.Services;

public class Utils
{

    public string GetStringInput()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Please enter a valid input");
        }
        return input;
    }

    public int GetValidOption(int[] validOptions)
    {
        string input = GetStringInput();
        bool isValidFormat = int.TryParse(input, out int parsedInput);
        if (!isValidFormat)
        {
            throw new Exception("Invalid input format! Try again");
        }
        bool isValidChoice = validOptions.Contains(parsedInput);
        if (!isValidChoice)
        {
            throw new Exception("Invalid option selected! Try again");
        }
        return parsedInput;
    }
}
