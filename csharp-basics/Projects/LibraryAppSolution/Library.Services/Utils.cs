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
        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid input");
                Console.ResetColor();
                continue;
            }

            if (!int.TryParse(input, out int parsedInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input format! Try again");
                Console.ResetColor();
                continue;
            }

            if (!validOptions.Contains(parsedInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option selected! Try again");
                Console.ResetColor();
                continue;
            }

            return parsedInput;
        }
    }
}
