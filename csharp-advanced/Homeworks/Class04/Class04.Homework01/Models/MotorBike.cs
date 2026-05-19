namespace Class04.Homework01.Models;

public class MotorBike : Vehicle
{

    public override void DisplayInfo()
    {
        Console.WriteLine($"I am {GetType().Name} and I drive on 2 wheels :)");
    }

}
