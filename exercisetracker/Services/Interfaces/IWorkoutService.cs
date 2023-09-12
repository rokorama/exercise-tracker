using exercisetracker.Models;

namespace exercisetracker.Services;

public interface IWorkoutService
{
    public Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession session);
}