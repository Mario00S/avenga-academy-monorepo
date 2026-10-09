using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Dtos.Pizzas;

public class UpdatePizzaDto
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;
    [StringLength(500)]
    public string? Description { get; set; }
    [Range(0.01, 10000)]
    public decimal Price { get; set; }
    public List<string> Ingredients { get; set; } = [];
}
