namespace Class04.Homework01.Models;

public class Boat : Vehicle
{

    public override void DisplayInfo()
    {
        Console.WriteLine($"I am {GetType().Name} and I do not have wheels :(");
    }
}
