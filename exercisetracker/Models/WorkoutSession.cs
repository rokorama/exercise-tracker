namespace exercisetracker.Models;

public class WorkoutSession
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public List<IExercise> ExerciseSets { get; set; } = new List<IExercise>();
    public string Notes { get; set; } = string.Empty;
}