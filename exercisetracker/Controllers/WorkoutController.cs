using Microsoft.AspNetCore.Mvc;

namespace exercisetracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(WorkoutSession session)
    {
        var result = await _workoutService.CreateWorkoutSessionAsync(session);
        return Ok(result);
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var result = await _workoutService.GetWorkoutSessionsByUserAsync(userId);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _workoutService.GetWorkoutSessionAsync(id);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(WorkoutSession session)
    {
        var result = await _workoutService.UpdateWorkoutSessionAsync(session);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _workoutService.DeleteWorkoutSessionAsync(id);
        return Ok(result);
    }
}