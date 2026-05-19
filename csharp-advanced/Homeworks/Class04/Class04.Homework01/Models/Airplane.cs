namespace Class04.Homework01.Models;

public class Airplane : Vehicle
{

    public override void DisplayInfo()
    {
        Console.WriteLine($"I am a {GetType().Name} and I have couple of wheels");
    }
}
