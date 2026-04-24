using Class05.HomeworkPart02.Models;
using System.ComponentModel.Design;

#region requirements

//Task 1
//Make a class Driver. Add properties: Name, Skill
//Make a class Car. Add properties: Model, Speed and Driver
//Make a method of the Car class called : CalculateSpeed() that takes a driver object as input parameter and calculates the skill multiplied by the speed of the car and return it as a result.
//Make a method RaceCars() that will get two Car objects that will determine which car will win and print the result in the console.
//Make 4 car objects and 4 driver objects.
//Ask the user to select a two cars and two drivers for the cars.Add the drivers to the cars and call the RaceCars() methods
//Test Data:
//Choose a car no.1:
//Hyundai
//Mazda
//Ferrari
//Porsche
//Choose Driver:
//Bob
//Greg
//Jill
//Anne
//Choose a car no.2:
//Hyundai
//Mazda
//Ferrari
//Porsche
//Choose Driver:
//Bob
//Greg
//Jill
//Anne
//Expected Output:
//Car no. 2 was faster.
//BONUS 1: If a user chooses option one for the first car, eliminate that option when the user picks car two.

//BONUS 2: Make the Output message say what was the model of the car that won, what speed was it going and which driver was driving it.

//BONUS 3: Implement a Race Again Feature where you ask the user if he wants to race again and repeat the racing function.

#endregion

#region Workspace

//drivers
//Driver driver1 = new Driver("Max Verstapen", 5);
//Driver driver2 = new Driver("Lando Norris", 4);
//Driver driver3 = new Driver("Sebastian Vettel", 3);
//Driver driver4 = new Driver("Yasuke Honda", 2);

Driver[] drivers = new Driver[]
{
    new Driver("Max Verstapen", 5),
    new Driver("Lando Norris", 4),
    new Driver("Sebastian Vettel", 3),
    new Driver("Yasuke Honda", 2)
};

////cars
//Car car1 = new Car("Renault", 10, null);
//Car car2 = new Car("Mercedes", 8, null);
//Car car3 = new Car("Alfa-Romeo", 7, null);
//Car car4 = new Car("Honda", 6, null);

Car[] cars = new Car[]
   {
   new Car("Renault", 10, null),
   new Car("Mercedes", 8, null),
   new Car("Alfa-Romeo", 7, null),
   new Car("Honda", 6, null)
   };



static Driver ChooseDriver(Driver[] drivers)
{
    while (true)
    {
        //foreach (var driver in drivers)
        //{
        //    Console.WriteLine(driver.Name);
        //}

        for (int i = 0; i < drivers.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {drivers[i].Name}");
        }

        bool isValidDriver = int.TryParse(Console.ReadLine(), out int chooseDriverInt);
        int selectedIndex = chooseDriverInt - 1;

        if (isValidDriver && chooseDriverInt >=1 && chooseDriverInt <= drivers.Length)
        {
            return drivers[selectedIndex];
        }
        else
        {
            Console.WriteLine("Invalid input, Please try again");
        }

    }
}


static Car ChooseCar(Car[] cars)
{
    while (true)
    {
        //foreach (var car in cars)
        //{
        //    Console.WriteLine($"{ [1++]} {car.Model}");
        //}

        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine($"{i+1}. {cars[i].Model}");
        }

        bool isValidCar = int.TryParse(Console.ReadLine(), out int chooseCarInt);
        int selectedIndex = chooseCarInt - 1;


        if (isValidCar && chooseCarInt >= 1 && chooseCarInt <= cars.Length)
        {
            return cars[selectedIndex];
        }
        else
        {
            Console.WriteLine("Invalid Input, Please try again");
        }  
    }
}


static Car Menu(Car[] cars, Driver[] drivers)
{
    Console.WriteLine("Select a Car:");
    Car selectCar = ChooseCar(cars);
    Console.WriteLine("Select a Driver:");
    Driver selectDriver = ChooseDriver(drivers);
    selectCar.Driver = selectDriver;

    Console.WriteLine($"The racer is {selectDriver.Name}, {selectCar.Model}"); //testing purposes
    return selectCar;
}


Car racer1 = Menu(cars, drivers);
Console.WriteLine(racer1);
Car racer2 = Menu(FilterCars(cars, racer1), FilterDrivers(drivers, racer1.Driver));
Console.WriteLine(racer2);



Car.RaceCars(racer1, racer2);


static Car[] FilterCars(Car[] cars, Car racer1)
{
    Car[] filteredCars = new Car[cars.Length - 1];
    int j = 0;

    for (int i = 0; i < cars.Length; i++)
    {
        if (cars[i] != racer1)
        {
            filteredCars[j] = cars[i];
            j++;
        }
    }
    return filteredCars;
}

static Driver[] FilterDrivers(Driver[] drivers, Driver racer1)
{
    Driver[] filteredDrivers = new Driver[drivers.Length - 1];
    int j = 0;

    for (int i = 0; i < drivers.Length; i++)
    {
        if (drivers[i] != racer1)
        {
            filteredDrivers[j] = drivers[i];
            j++;
        }
    }
    return filteredDrivers;
}

//Car callMethod = chooseCar(cars);

//Console.WriteLine(callMethod);

#endregion