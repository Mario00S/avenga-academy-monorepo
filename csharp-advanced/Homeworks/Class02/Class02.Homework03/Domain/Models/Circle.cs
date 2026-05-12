using Class02.Homework03.Domain.BaseEntity;

namespace Class02.Homework03.Domain.Models;

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Math.PI * Radius);
    }
}
