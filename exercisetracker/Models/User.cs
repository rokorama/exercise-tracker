namespace exercisetracker.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? Weight { get; set; }
    public List<WorkoutSession> Workouts { get; set; } = new List<WorkoutSession>();
}