namespace Class03.Homework02.Models;

public class Boat : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Im a {GetType().Name} and i do not have wheels :( ");
    }
}
