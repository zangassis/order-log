namespace OrderLog.Services;
public class NullLoggingService : ILoggingService
{
    public void Log(string? message)
    {
        // Do nothing
    }
}