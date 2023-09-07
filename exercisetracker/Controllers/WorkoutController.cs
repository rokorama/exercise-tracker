using exercisetracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercisetracker.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(WorkoutSession session)
    {
        return Ok();
    }
}