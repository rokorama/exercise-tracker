namespace exercisetracker.Models;

public class WeightExercise
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool WeightAscending { get; set; } = true;
    public bool IsOnMachine { get; set; } = false;
}