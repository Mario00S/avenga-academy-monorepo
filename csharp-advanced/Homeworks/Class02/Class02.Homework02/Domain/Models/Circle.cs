using Class02.Homework02.Domain.Interfaces;
namespace Class02.Homework02.Domain.Models;

public class Circle : IShape
{
    public double Radius { get; set; }


    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius,2);
    }
}
