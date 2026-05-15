namespace Class03.Homework02.Models;

public class Plane : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Im a {GetType().Name} i have couple of wheels :)");
    }
}
