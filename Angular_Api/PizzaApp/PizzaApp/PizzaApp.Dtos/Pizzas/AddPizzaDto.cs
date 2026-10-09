using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Dtos.Pizzas;

public class AddPizzaDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;
    [StringLength(500)]
    public string? Description { get; set; }
    [Range(0.01, 10000)]
    public decimal Price { get; set; }
    [MinLength(1, ErrorMessage = "At least one ingredient is required")]
    public List<string> Ingredients { get; set; } = [];
}
