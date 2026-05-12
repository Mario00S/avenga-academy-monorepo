namespace Class02.Homework03.Domain.BaseEntity;

public abstract class Shape
{
    public abstract double CalculateArea();

    public abstract double CalculatePerimeter();

    public void DisplayInfo()
    {
        Console.WriteLine($"The shape of the element is {GetType().Name} with area of: {CalculateArea()} and the perimeter of: {CalculatePerimeter()}");
    }
}
