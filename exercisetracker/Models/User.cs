namespace exercisetracker.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<WeightExercise> WeightExercises { get; set; } = new List<WeightExercise>();
    public List<RunningExercise> RunningExercises { get; set; } = new List<RunningExercise>();
    public List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
}