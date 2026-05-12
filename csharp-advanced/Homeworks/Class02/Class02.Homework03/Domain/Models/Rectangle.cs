using Class02.Homework03.Domain.BaseEntity;

namespace Class02.Homework03.Domain.Models;

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }


    //inherited abstract classes:
    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }

    //already at base class no need to rewrite or reference it
    //public static void DisplayInfo()
    //{

    //}

}
