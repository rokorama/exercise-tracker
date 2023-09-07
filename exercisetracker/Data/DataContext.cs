using System.ComponentModel;
using exercisetracker.Models;
using Microsoft.EntityFrameworkCore;

namespace exercisetracker.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    // protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    // {
    //     base.ConfigureConventions(builder);
    //     builder.Properties<DateOnly>()
    //         .HaveConversion<DateOnlyConverter>();
    //     builder.Properties<TimeOnly>()
    //         .HaveConversion<TimeOnlyConverter>();
    // }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<WeightExercise> WeightExercises { get; set; } = null!;
    public DbSet<RunInstance> RunningExercises { get; set; } = null!;
    public DbSet<WorkoutSession> WorkoutSessions { get; set; } = null!;
    public DbSet<WeightExerciseSet> ExerciseSets { get; set; } = null!;
}