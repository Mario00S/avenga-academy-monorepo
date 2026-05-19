namespace Class04.Homework01.Models;

public static class VehicleExtensions
{
    public static void Drive(this Vehicle vehicle)
    {
        if (vehicle is Car)
        {
            Console.WriteLine("The car is driving");
        }
        else
        {
            Console.WriteLine($"I am a {vehicle.GetType().Name} and I cannot drive");
        }        
    }

    public static void Wheelie(this Vehicle vehicle)
    {
        if (vehicle is MotorBike)
        {
            Console.WriteLine("The motorbike is driving on one wheel");
        }
        else
        {
            Console.WriteLine($"I am a {vehicle.GetType().Name} and I cannot do a wheelie");
        }

        
    }

    public static void Sail(this Vehicle vehicle)
    {
        if (vehicle is Boat)
        {
            Console.WriteLine("The boat is sailing");
        }
        else
        {
            Console.WriteLine($"I am a {vehicle.GetType().Name} and I cannot sail");
        }        
    }

    public static void Fly(this Vehicle vehicle)
    {

        if (vehicle is Airplane)
        {
            Console.WriteLine("The airplane is flying");
        }
        else
        {
            Console.WriteLine($"I am a {vehicle.GetType().Name} and I cannot fly");
        }
    }


    //Because the variables are declared as Vehicle, the extension methods need Vehicle as the this parameter instead of a specific derived type.
}
