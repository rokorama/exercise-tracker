using exercisetracker.Models;

namespace exercisetracker.Data;

public interface IWorkoutRepository
{
    public Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession session);
    public Task<WorkoutSession> GetWorkoutSessionAsync(Guid id);
    public Task<List<WorkoutSession>> GetWorkoutSessionsByUserAsync(Guid userId);
    public Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession session);
    public Task<bool> DeleteWorkoutSessionAsync(Guid id);
}