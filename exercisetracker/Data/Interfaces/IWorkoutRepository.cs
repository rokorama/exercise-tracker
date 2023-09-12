using exercisetracker.Models;

namespace exercisetracker.Data;

public interface IWorkoutRepository
{
    public Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession session);
}