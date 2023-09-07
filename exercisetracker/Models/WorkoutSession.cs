namespace exercisetracker.Models;

public class WorkoutSession
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public List<RunInstance> Runs { get; set; } = new List<RunInstance>();
    public List<WeightExercise> WeightExercises { get; set; } = new List<WeightExercise>();
    public string Notes { get; set; } = string.Empty;
}