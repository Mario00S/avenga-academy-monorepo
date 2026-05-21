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

#region workspace
//Filter all cars that have origin from Europe.
List<Car> allCarsFromEurope = CarsData.Cars.Where(c => c.Origin == "Europe").ToList();
Console.WriteLine("All the cars from europe are:");
int counter = 1;
foreach (var car in allCarsFromEurope)
{    
    Console.WriteLine($"{counter ++}: {car.Model}");
}

//Find all unique cylinder values for cars.
IEnumerable<int> distinctCylinder = CarsData.Cars.Select(c => c.Cylinders).Distinct();
Console.WriteLine("unique cylinder values for cars");
foreach (var cyilinder in distinctCylinder)
{
    Console.WriteLine(cyilinder);
}


#endregion
