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
    public IExercise Get()
    {
        var result = new Run()
        {
            Id = Guid.NewGuid(),
            ExerciseId = Guid.NewGuid(),
            Date = DateTime.Today,
            Notes = "This is a test exercise set",
            Distance = 10,
            Time = 100
        };
    return result;
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