namespace exercisetracker.Models;

public class Run : IExercise
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public int Distance { get; set; }
    public int Time { get; set; }
    public DateTime WarmupTime { get; set; }
    public bool Outside { get; set; } = false;
    public string Notes { get; set; } = string.Empty;
}