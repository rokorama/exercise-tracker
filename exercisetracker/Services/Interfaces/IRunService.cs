namespace exercisetracker.Services;

public interface IRunService
{
    public Task<RunInstance> CreateRunAsync(RunInstance run);
    public Task<RunInstance> GetRunAsync(Guid id);
    public Task<List<RunInstance>> GetRunsAsync();
    public Task<RunInstance> UpdateRunAsync(RunInstance run);
    public Task DeleteRunAsync(Guid id);
}