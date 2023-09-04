using exercisetracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercisetracker.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutController : ControllerBase
{
    public WorkoutController()
    {
    }
    
    // GET
    [HttpGet]
    public ActionResult<List<IExercise>> Get()
    {
        var result = new List<RunningExercise>
        {
            new RunningExercise()
            {
                Id = Guid.NewGuid(),
                ExerciseId = Guid.NewGuid(),
                Date = DateTime.Today,
                Notes = "This is a test exercise set",
                Outside = true,
                Distance = 10,
                Time = 100
            },
            new RunningExercise()
            {
                Id = Guid.NewGuid(),
                ExerciseId = Guid.NewGuid(),
                Date = DateTime.Today,
                Notes = "This is a another exercise set",
                Distance = 5,
                Time = 50
            }
        };
        return Ok  (result);
    // public WorkoutSession Get()
    // {
    //     var result = new WorkoutSession()
    //     {
    //         Id = Guid.NewGuid(),
    //         UserId = Guid.NewGuid(),
    //         Date = DateTime.Today,
    //         Notes = "This is a test workout session",
    //         ExerciseSets = new List<IExercise>()
    //         {
    //             new ExerciseSet()
    //             {
    //                 Id = Guid.NewGuid(),
    //                 ExerciseId = Guid.NewGuid(),
    //                 Date = DateTime.Today,
    //                 Notes = "This is a test exercise set",
    //                 Reps = 10,
    //                 Weight = 100
    //             }
    //         }
    //     };
    //     return result;
    }
}