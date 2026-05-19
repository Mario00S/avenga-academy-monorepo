namespace Class04.Homework01.Models;

public class Car : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"I am a {GetType().Name} and I drive on 4 wheels :)");
    }

    //public void Drive()
    //{
    //    Console.WriteLine("The car is driving");
    //}
}
