namespace exercisetracker.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
}