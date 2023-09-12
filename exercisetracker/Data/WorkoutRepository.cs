using exercisetracker.Models;

namespace exercisetracker.Data;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly DataContext _context;
    
    public WorkoutRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession session)
    {
        await _context.WorkoutSessions.AddAsync(session);
        await _context.SaveChangesAsync();
        return session;
    }
}