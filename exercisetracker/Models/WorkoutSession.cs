namespace exercisetracker.Models;

public class WorkoutSession
{
    public Guid Id { get; set; }
    public virtual Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public List<RunInstance> Runs { get; set; } = new();
    public List<WeightExercise> WeightExercises { get; set; } = new();
    public string Notes { get; set; } = string.Empty;
}