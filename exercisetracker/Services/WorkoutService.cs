using exercisetracker.Data;
using exercisetracker.Models;

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
}