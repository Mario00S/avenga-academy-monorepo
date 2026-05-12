namespace Class02.Homework02.Domain.Models;

using Class02.Homework02.Domain.Interfaces;

public class Rectangle : IShape
{

    public double Width { get; set; }
    public double Height { get; set; }

    public double GetArea()
    {
        return Width * Height;
    }
}
