using Class06.Homework01;
#region requirements
//Practice LINQ Vol. 2 🏋️‍♂️
//Filter all cars that have origin from Europe.
//Find all unique cylinder values for cars.
//Select all car names with their model names converted to uppercase.
//Check if there are any cars with horsepower greater than 300.
//Find the car with the highest horsepower.
//Filter all "Chevrolet" cars and order them by weight in descending order.
//Find the car with the longest model name.
//Group cars by their origin and then order the groups by the number of cars in each group, in ascending order.
//Find the first 5 cars with the highest horsepower. (hint: read about LINQ methods Skip() and Take())
//Find the car with the highest acceleration time.
//Select only the model and horsepower of cars with horsepower greater than 200.
//Select all unique origins of cars, ordered alphabetically (ascending).
//Select all cars with more than 4 cylinders, and order them by origin and then by horsepower.
//Filter all cars that have more than 6 Cylinders not including 6 after that Filter all cars that have exactly 4 Cylinders and have HorsePower more then 110.0. Join them in one result.
//Filter all cars that have more then 200 HorsePower and Find out how much is the lowest, highest and average Miles per galon for these cars.
//Be creative and write requirement of your own choice :) (only one catch, must use at least 3 LINQ methods)
//Be creative and write requirement of your own choice :) (only one catch, must use at least 3 LINQ methods)

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
foreach (var car in allCarsFromEurope)
{    
    Console.WriteLine($"{counter ++}: {car.Model}");
}

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
Car highestHp2 = CarsData.Cars.MaxBy(c => c.HorsePower);
Console.WriteLine($"The highest hp car is {highestHp.Model} - {highestHp.HorsePower}");
Console.WriteLine($"The highest hp car is {highestHp2.Model} - {highestHp2.HorsePower}");

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
#endregion
