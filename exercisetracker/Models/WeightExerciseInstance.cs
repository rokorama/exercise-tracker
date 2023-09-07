namespace exercisetracker.Models;

public class WeightExerciseInstance
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public string Notes { get; set; } = string.Empty;
    public List<WeightExerciseSet> Sets { get; set; } = new();
    public bool Success { get; set; } = true;
}