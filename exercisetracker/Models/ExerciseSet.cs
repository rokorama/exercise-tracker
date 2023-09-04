namespace exercisetracker.Models;

public class ExerciseSet : IExercise
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; } = string.Empty;
    public int Weight { get; set; }
    public int Reps { get; set; }
    public bool Success { get; set; }
}