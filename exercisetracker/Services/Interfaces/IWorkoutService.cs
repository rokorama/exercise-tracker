namespace exercisetracker.Services;

public interface IWorkoutService
{
    public Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession session);
    public Task<WorkoutSession> GetWorkoutSessionAsync(Guid id);
    public Task<List<WorkoutSession>> GetWorkoutSessionsByUserAsync(Guid userId);
    public Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession session);
    public Task DeleteWorkoutSessionAsync(Guid id);
}