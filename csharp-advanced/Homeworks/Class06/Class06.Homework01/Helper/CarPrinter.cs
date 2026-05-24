namespace Class06.Homework01.Helper;

public static class CarPrinter
{

    public static void PrintCar(Car car)
    {
        Console.WriteLine(car.Model);
    }


    public static void PrintCars(IEnumerable<Car> cars)
    {
        foreach (var car in cars)
        {
            PrintCar(car);
        }
    }

    public static void PrintNumberedCars(IEnumerable<Car> cars)
    {
        int counter = 1;

        foreach (var car in cars)
        {
            Console.WriteLine($"{counter++}: {car.Model}");

        }
    }

    public static void PrintMpgStats(double minMpg, double maxMpg, double averageMpg)
    {
        Console.WriteLine($"Min MPG: {minMpg}");
        Console.WriteLine($"Max MPG: {maxMpg}");
        Console.WriteLine($"Average MPG: {averageMpg}");
    }
}
