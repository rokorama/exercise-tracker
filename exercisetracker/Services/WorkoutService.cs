using exercisetracker.Data;

namespace exercisetracker.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    
    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public async Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession session)
    {
        return await _workoutRepository.CreateWorkoutSessionAsync(session);
    }
    
    public async Task<WorkoutSession> GetWorkoutSessionAsync(Guid id)
    {
        return await _workoutRepository.GetWorkoutSessionAsync(id);
    }
    
    public async Task<List<WorkoutSession>> GetWorkoutSessionsByUserAsync(Guid userId)
    {
        return await _workoutRepository.GetWorkoutSessionsByUserAsync(userId);
    }
    
    public async Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession session)
    {
        return await _workoutRepository.UpdateWorkoutSessionAsync(session);
    }
    
    public async Task DeleteWorkoutSessionAsync(Guid id)
    {
        await _workoutRepository.DeleteWorkoutSessionAsync(id);
    }
}