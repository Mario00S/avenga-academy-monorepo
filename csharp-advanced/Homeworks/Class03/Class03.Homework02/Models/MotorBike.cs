namespace Class03.Homework02.Models;

public class MotorBike : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Im a {GetType().Name} and i drive on 2 wheels :)");
    }
}
