using exercisetracker.Models;
using exercisetracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace exercisetracker.Controllers;

[ApiController]
[Route("[controller]")]
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
}