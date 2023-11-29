using exercisetracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace exercisetracker.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<WeightExercise> WeightExercises { get; set; } = null!;
    public DbSet<RunInstance> RunningExercises { get; set; } = null!;
    public DbSet<WorkoutSession> WorkoutSessions { get; set; } = null!;
    public DbSet<WeightExerciseSet> ExerciseSets { get; set; } = null!;
}