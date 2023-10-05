using System.ComponentModel.DataAnnotations;

namespace exercisetracker.Models;

public class UserChangePassword
{
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [Compare("Password", ErrorMessage = "The passwords do not match.")]
    public string NewPassword { get; set; } = string.Empty;
    
}