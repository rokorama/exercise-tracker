using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercisetracker.Models;

public class WorkoutSession
{
    public Guid Id { get; set; }
    // [ForeignKey("UserId")]
    public virtual Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public List<RunInstance> Runs { get; set; } = new();
    public List<WeightExercise> WeightExercises { get; set; } = new();
    public string Notes { get; set; } = string.Empty;
}