namespace exercisetracker.Models;

public interface IExercise
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }
}