using Class06.Homework01;
using Class06.Homework01.Helpers;
#region requirements
//Practice LINQ Vol. 2 🏋️‍♂️
//1. Filter all cars that have origin from Europe.
//2. Find all unique cylinder values for cars.
//3. Select all car names with their model names converted to uppercase.
//4. Check if there are any cars with horsepower greater than 300.
//5. Find the car with the highest horsepower.
//6. Filter all "Chevrolet" cars and order them by weight in descending order.
//7. Find the car with the longest model name.
//8. Group cars by their origin and then order the groups by the number of cars in each group, in ascending order.
//9. Find the first 5 cars with the highest horsepower. (Hint: read about LINQ methods Skip() and Take()).
//10. Find the car with the highest acceleration time.
//11. Select only the model and horsepower of cars with horsepower greater than 200.
//12. Select all unique origins of cars, ordered alphabetically (ascending).
//13. Select all cars with more than 4 cylinders, and order them by origin and then by horsepower.
//14. Filter all cars that have more than 6 cylinders, not including 6, and after that filter all cars that have exactly 4 cylinders and horsepower more than 110.0. Join them in one result.
//15. Filter all cars that have more than 200 horsepower and find out the lowest, highest, and average miles per gallon for these cars.
//16. Be creative and write a requirement of your own choice. (Only one catch: must use at least 3 LINQ methods.)
//17. Be creative and write a requirement of your own choice. (Only one catch: must use at least 3 LINQ methods.)

#endregion

#region notes

// List<T> is a concrete collection stored in memory.
// Use it when you want list features like indexing, Add, Remove, or Count.

// IEnumerable<T> is an interface for something you can iterate through.
// Use it when you are chaining LINQ methods like Where, Select, or Distinct,
// because those methods often return a sequence instead of a List<T>.

// Use ToList() when you want to convert a sequence into a real List<T>.

#endregion

#region workspace
//1.Filter all cars that have origin from Europe.
List<Car> allCarsFromEurope = CarsData.Cars.Where(c => c.Origin == "Europe").ToList();
Console.WriteLine("1. All the cars from europe are:");
int counter = 1;
//foreach (var car in allCarsFromEurope)
//{
//    //Console.WriteLine($"{counter ++}: {car.Model}");
//    CarPrinter.PrintCar(car);
//}
CarPrinter.PrintNumberedCars(allCarsFromEurope);
Console.ReadLine();

//2.Find all unique cylinder values for cars.
IEnumerable<int> distinctCylinder = CarsData.Cars.Select(c => c.Cylinders).Distinct();
Console.WriteLine("2. unique cylinder values for cars");
foreach (var cyilinder in distinctCylinder)
{
    Console.Write(cyilinder + ", ");
}

//3.Select all car names with their model names converted to uppercase.
List<string> allCarsModelsUpperCase = CarsData.Cars.Select(c => c.Model.ToUpper()).ToList();
Console.WriteLine("3.Select all car names with their model names converted to uppercase.");
foreach (var car in allCarsModelsUpperCase)
{
    Console.WriteLine($"{counter++}: {car}");
}

//4.Check if there are any cars with horsepower greater than 300.
Console.WriteLine("4.Check if there are any cars with horsepower greater than 300.");
bool horsePowerGreaterThan300 = CarsData.Cars.Any(c => c.HorsePower > 300);
Console.WriteLine($"Are there any cars with horsepower greater than 300Hp? {(horsePowerGreaterThan300 ? "Yes" : "No")}");

//5.Find the car with the highest horsepower.
Console.WriteLine("5.Find the car with the highest horsepower");
Car highestHp = CarsData.Cars.OrderByDescending(c => c.HorsePower).First();
//Car highestHp2 = CarsData.Cars.MaxBy(c => c.HorsePower);
Console.WriteLine($"The highest hp car is {highestHp.Model} - {highestHp.HorsePower}");
//Console.WriteLine($"The highest hp car is {highestHp2.Model} - {highestHp2.HorsePower}");

//6. Filter all "Chevrolet" cars and order them by weight in descending order.
Console.WriteLine("6. Filter all \"Chevrolet\" cars and order them by weight in descending order.");
List<Car> allChevroletCars = CarsData.Cars
    .Where(c => c.Model.Contains("Chevrolet"))
    .OrderByDescending(c => c.Weight)
    .ToList();

foreach (var car in allChevroletCars)
{
    Console.WriteLine(car.Model + " " + car.Weight);
}

//7.Find the car with the longest model name.
Console.WriteLine("7. Find the car with the longest model name.");
Car? carWithLongestModelName = CarsData.Cars
    .OrderByDescending(c => c.Model.Length).FirstOrDefault();

if (carWithLongestModelName is not null)
{
    Console.WriteLine(carWithLongestModelName.Model);
}

//8. Group cars by their origin and then order the groups by the number of cars in each group, in ascending order.
Console.WriteLine("8. Group cars by their origin and then order the groups by the number of cars in each group, in ascending order.");
IEnumerable<IGrouping<string, Car>> groupsByOrigin =
    CarsData.Cars.GroupBy(c => c.Origin).OrderBy(g => g.Count());

foreach (IGrouping<string, Car> origin in groupsByOrigin)
{
    Console.WriteLine(origin.Key + " " + origin.Count());
}

//9. Find the first 5 cars with the highest horsepower. (Hint: read about LINQ methods Skip() and Take()).
Console.WriteLine("9. Find the first 5 cars with the highest horsepower. (Hint: read about LINQ methods Skip() and Take()).");
List<Car> firstFiveCarsWithHighestHp = CarsData.Cars
    .OrderByDescending(c => c.HorsePower).Take(5).ToList();

foreach (var car in firstFiveCarsWithHighestHp)
{
    Console.WriteLine($"{car.Model} has {car.HorsePower} hp");
}

//10. Find the car with the highest acceleration time.
Console.WriteLine("10. Find the car with the highest acceleration time.");
Car? carWithHighestAccTime = CarsData.Cars
    .MaxBy(c => c.AccelerationTime);

if (carWithHighestAccTime is not null)
{
    Console.WriteLine($"{carWithHighestAccTime.Model} with acceleration time of {carWithHighestAccTime.AccelerationTime}");
}

//11. Select only the model and horsepower of cars with horsepower greater than 200.
Console.WriteLine("11. Select only the model and horsepower of cars with horsepower greater than 200.");
List<Car> modelsHpGreaterThan200 = CarsData.Cars
    .Where(c => c.HorsePower > 200).ToList();

foreach (var car in modelsHpGreaterThan200)
{
    Console.WriteLine($"{car.Model} {car.HorsePower} HP");
}

//12. Select all unique origins of cars, ordered alphabetically (ascending).
Console.WriteLine("12. Select all unique origins of cars, ordered alphabetically (ascending)");
List<string> distincCarOrigin = CarsData.Cars
    .Select(c => c.Origin)
    .Distinct().OrderBy(x => x).ToList();

foreach (var origin in distincCarOrigin)
{
    Console.WriteLine(origin.ToUpper());
}

//13. Select all cars with more than 4 cylinders, and order them by origin and then by horsepower.
Console.WriteLine("13. Select all cars with more than 4 cylinders, and order them by origin and then by horsepower.");
List<Car> carsWithMoreThan4Cylinders = CarsData.Cars
    .Where(c => c.Cylinders > 4)
    .OrderBy(c => c.Origin)
    .ThenBy(c => c.HorsePower).ToList();

foreach (var car in carsWithMoreThan4Cylinders)
{
    Console.WriteLine($"{car.Model} | Origin: {car.Origin} | HP: {car.HorsePower}");
}
Console.WriteLine($"The number of cars with more than 4 cylinders is {carsWithMoreThan4Cylinders.Count()}");

//14. Filter all cars that have more than 6 cylinders, not including 6, and after that filter all cars that have exactly 4 cylinders and horsepower more than 110.0. Join them in one result.
Console.WriteLine("14. Filter all cars that have more than 6 cylinders, not including 6, and after that filter all cars that have exactly 4 cylinders and horsepower more than 110.0. Join them in one result.");
List<Car> joinedQuerries = CarsData.Cars
    .Where(c => c.Cylinders > 6)
    .Concat(CarsData.Cars.Where(c => c.Cylinders == 4 && c.HorsePower > 110)).ToList();

foreach (var car in joinedQuerries)
{
    Console.WriteLine($"{car.Model} - {car.Cylinders} cyl - {car.HorsePower} HP");
}
Console.WriteLine(joinedQuerries.Count());

//15. Filter all cars that have more then 200 HorsePower
//and Find out how much is the lowest, highest and average Miles per galon for these cars.
Console.WriteLine("15. Filter all cars that have more then 200 HorsePower\r\n//and Find out how much is the lowest, highest and average Miles per galon for these cars.");
List<Car> filteredCars = CarsData.Cars
    .Where(c => c.HorsePower > 200)
    .ToList();

double lowestMpg = filteredCars.Min(c => c.MilesPerGalon);
double highestMpg = filteredCars.Max(c => c.MilesPerGalon);
double averageMpg = filteredCars.Average(c => c.MilesPerGalon);

//Console.WriteLine($"Min MPG: {lowestMpg}");
//Console.WriteLine($"Max MPG: {highestMpg}");
//Console.WriteLine($"Average MPG: {averageMpg}");

CarPrinter.PrintMpgStats(lowestMpg, highestMpg, averageMpg);

Console.ReadLine();

//To be refactored...
#endregion
