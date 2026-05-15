//Task 2
//Create a class Vehicle that have one method DisplayInfo(). Create class Car, MotorBike, Boat, Airplane that will inherit from Vehicle and will implement the respective method;

//Vehicle car = new Car();
//Vehicle motorBike = new MotorBike();
//Vehicle boat = new Boat();
//Vehicle plane = new Airplane();

//car.DisplayInfo();
//motorBike.DisplayInfo();
//boat.DisplayInfo();
//plane.DisplayInfo()

//// in console we should display
//// Im a car and i drive on 4 wheels :)
//// Im a motorbike and i drive on 2 wheels :)
//// Im a boat and i do not have wheels :(
//// Im a plane i have couple of wheels :)


//Simple visual
//Picture this:
//Vehicle = blank template
//Car = template filled with “4 wheels”
//MotorBike = template filled with “2 wheels”
//Boat = template filled with “no wheels”
//Airplane = template filled with “couple of wheels”
//Same template shape, different content.
//A useful next step is to sketch the class names and arrows on paper first:
//Vehicle
//Car -> Vehicle
//MotorBike -> Vehicle
//Boat -> Vehicle
//Airplane -> Vehicle

using Class03.Homework02.Models;

///declare and initialize variables
Vehicle car = new Car();
Vehicle boat = new Boat();
Vehicle motorbike = new MotorBike();
Vehicle plane = new Plane();

//calling the displayInfo method
car.DisplayInfo();
boat.DisplayInfo();
motorbike.DisplayInfo();
plane.DisplayInfo();