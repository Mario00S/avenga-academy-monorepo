namespace Class05.HomeworkPart02.Models
{
    public class Car
    {

        public Car()
        {
            
        }

        public Car(string model, int speed, Driver driver)
        {
            Model = model;
            Speed = speed;
            Driver = driver;
        }

        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver Driver { get; set; }


        public int CalculateSpeed(Driver driver)
        {
            return driver.Skill * Speed;
        }

        public static void RaceCars(Car firstCar, Car secondCar)
        {

            int firstDriver = firstCar.CalculateSpeed(firstCar.Driver);
            int secondDriver = secondCar.CalculateSpeed(secondCar.Driver);

            if (firstDriver > secondDriver)
            {
                Console.WriteLine($"The driver {firstCar.Driver.Name} that raced with {firstCar.Model} wih speed: {firstDriver} kmh is faster than the driver: {secondCar.Driver.Name}, raced with: {secondCar.Model} and speed {secondDriver} kmh");
            }else if (secondDriver > firstDriver)
            {
                Console.WriteLine($"The driver {secondCar.Driver.Name} that raced with {secondCar.Model} wih speed: {secondDriver} kmh is faster than the driver: {firstCar.Driver.Name}, raced with: {firstCar.Model} and speed {firstDriver} kmh");
            }
            else
            {
                Console.WriteLine("It is a tie, or there is no winner");
            }



        }
    }
}


