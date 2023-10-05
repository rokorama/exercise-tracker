namespace exercisetracker.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = null!;
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public virtual List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Role { get; set; } = "user";
}