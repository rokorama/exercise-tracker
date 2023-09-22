using exercisetracker.Data;

namespace exercisetracker.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    
    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public async Task<ServiceResponse<WorkoutSession>> CreateWorkoutSessionAsync(WorkoutSession session)
    {
        var result = new ServiceResponse<WorkoutSession>();
        result.Data = await _workoutRepository.CreateWorkoutSessionAsync(session);
        if (result.Data == null)
        {
            result.Message = "Workout session could not be created";
            result.Success = false;
        }

        return result;
    }
    
    public async Task<ServiceResponse<WorkoutSession>> GetWorkoutSessionAsync(Guid id)
    {
        var result = new ServiceResponse<WorkoutSession>();
        result.Data = await _workoutRepository.GetWorkoutSessionAsync(id);
        if (result.Data == null)
        {
            result.Message = "Workout session with given ID not found";
            result.Success = false;
        }

        return result;
    }
    
    public async Task<ServiceResponse<List<WorkoutSession>>> GetWorkoutSessionsByUserAsync(Guid userId)
    {
        var result = new ServiceResponse<List<WorkoutSession>>();
        result.Data = await _workoutRepository.GetWorkoutSessionsByUserAsync(userId);
        if (result.Data == null)
        {
            result.Message = "No workout sessions with given user ID found";
            result.Success = false;
        }

        return result;
    }
    
    public async Task<ServiceResponse<WorkoutSession>> UpdateWorkoutSessionAsync(WorkoutSession session)
    {
        var result = new ServiceResponse<WorkoutSession>();
        result.Data = await _workoutRepository.UpdateWorkoutSessionAsync(session);
        if (result.Data == null)
        {
            result.Message = "Workout session could not be updated";
            result.Success = false;
        }
        
        return result;
    }
    
    public async Task<ServiceResponse<bool>> DeleteWorkoutSessionAsync(Guid id)
    {
        var result = new ServiceResponse<bool>();
        result.Data = await _workoutRepository.DeleteWorkoutSessionAsync(id);
        if (!result.Data)
        {
            result.Message = "Workout session could not be deleted";
            result.Success = false;
        }

        return result;
    }
}