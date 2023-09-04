using exercisetracker.Models;
using Microsoft.EntityFrameworkCore;

namespace exercisetracker.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<WeightExercise> WeightExercises { get; set; } = null!;
    public DbSet<RunningExercise> RunningExercises { get; set; } = null!;
    public DbSet<WorkoutSession> WorkoutSessions { get; set; } = null!;
    public DbSet<ExerciseSet> ExerciseSets { get; set; } = null!;
}