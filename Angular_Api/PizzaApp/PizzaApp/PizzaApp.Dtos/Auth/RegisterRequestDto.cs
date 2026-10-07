using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Dtos.Auth;

public class RegisterRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    //[Password] custom validation attribute can be used for password strength for homework extra assignment
    [Required]
    public string Password { get; set; } = string.Empty;

}
