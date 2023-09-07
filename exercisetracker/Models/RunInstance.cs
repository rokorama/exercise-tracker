namespace exercisetracker.Models;

public class RunInstance
{
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public double Distance { get; set; }
    public TimeSpan Time { get; set; }
    public TimeSpan WarmupTime { get; set; }
    public bool Outside { get; set; }
    public string Notes { get; set; } = string.Empty;
}