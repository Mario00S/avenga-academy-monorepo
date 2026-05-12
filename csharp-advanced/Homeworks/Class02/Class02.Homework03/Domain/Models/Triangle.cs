using Class02.Homework03.Domain.BaseEntity;

namespace Class02.Homework03.Domain.Models;

public class Triangle : Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public override double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2;

        // Validates triangle inequality: sum of any two sides > third side, all sides > 0
        // Prevents NaN from invalid inputs in Math.Sqrt()
        if (SideA > 0 && SideB > 0 && SideC > 0 &&
    SideA + SideB > SideC &&
    SideA + SideC > SideB &&
    SideB + SideC > SideA)
        {
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
        else
        {
            
            return 0;
        }
    }

    public override double CalculatePerimeter()
    {
        return (SideA + SideB + SideC);
    }
}
