using Class02.Homework02.Domain.Interfaces;
namespace Class02.Homework02.Domain.Models;

public class Triangle : IShape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public double GetArea()
    {
        return 0.5 * Base * Height;
    }
}
