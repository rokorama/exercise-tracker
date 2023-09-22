namespace exercisetracker.Services;

public interface IWorkoutService
{
    public Task<ServiceResponse<WorkoutSession>> CreateWorkoutSessionAsync(WorkoutSession session);
    public Task<ServiceResponse<WorkoutSession>> GetWorkoutSessionAsync(Guid id);
    public Task<ServiceResponse<List<WorkoutSession>>> GetWorkoutSessionsByUserAsync(Guid userId);
    public Task<ServiceResponse<WorkoutSession>> UpdateWorkoutSessionAsync(WorkoutSession session);
    public Task<ServiceResponse<bool>> DeleteWorkoutSessionAsync(Guid id);
}