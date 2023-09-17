using Microsoft.EntityFrameworkCore;

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
    
    public async Task<WorkoutSession> GetWorkoutSessionAsync(Guid id)
    {
        return await _context.WorkoutSessions.FindAsync(id);
    }
    
    public async Task<List<WorkoutSession>> GetWorkoutSessionsByUserAsync(Guid userId)
    {
        return await _context.WorkoutSessions.Where(x => x.UserId == userId).ToListAsync();
    }
    
    public async Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession session)
    {
        _context.WorkoutSessions.Update(session);
        await _context.SaveChangesAsync();
        return session;
    }
    
    public async Task DeleteWorkoutSessionAsync(Guid id)
    {
        var session = await GetWorkoutSessionAsync(id);
        _context.WorkoutSessions.Remove(session);
        await _context.SaveChangesAsync();
    }
}