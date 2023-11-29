using Microsoft.AspNetCore.Identity;

namespace exercisetracker.Models;

public class User : IdentityUser
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = null!;
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public virtual List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Role { get; set; } = "user";
    
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}