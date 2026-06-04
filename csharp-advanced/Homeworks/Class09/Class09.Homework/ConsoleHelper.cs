namespace Class09.Homework;

public static class ConsoleHelper
{
    public static void WriteInColor(string text, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void ReadFromFile(string path)
    {
        using (StreamReader sr = new StreamReader(path))
        {
           string content = sr.ReadToEnd();

            if (string.IsNullOrEmpty(content))
            {
                WriteInColor("There is no text in this file", ConsoleColor.Red);
            }
            else
            {
                WriteInColor(content, ConsoleColor.Green);
            }
        }
    }

    public static void WriteInFile(string text, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            try
            {
                sw.WriteLine(text);
            }
            catch (Exception ex)
            {

                WriteInColor($"An error occured: {ex.Message}", ConsoleColor.Red);
            }
        }
    }

    public static void UserInput(string filePath)
    {
        while (true)
        {
            ConsoleHelper.WriteInColor("Enter user input for names.txt file, when you want to exit press 'x'");         
            string userInput1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput1))
            {
                WriteInColor("Invalid input please enter a Name", ConsoleColor.Red);
            }
            else if (userInput1.ToLower() == "x") 
            {
                break;
            }
            else
            {
                WriteInFile(userInput1, filePath);
            }
        }
    }

    public static void CreateFilesByLetter(string filePath)
    {
        string[] names = File.ReadAllLines(filePath);
        string folderPath = Path.GetDirectoryName(filePath);
        //string folderPath = Directory.GetCurrentDirectory(); less reliable option

        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            string newFileName = $"namesStartingWith_{letter}.txt";
            string newFilePath = Path.Combine(folderPath, newFileName);
            List<string> matchingNames = new List<string>();

            foreach (string name in names)
            {

                if (name.Trim().StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    matchingNames.Add(name);
                }
            }

            if (matchingNames.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter(newFilePath))
                {
                    foreach (string name in matchingNames)
                    {
                        sw.WriteLine(name);
                    }
                }
            }
        }
    }
}
