namespace IAMExample;

public interface ILoggingService
{
    void LogInformation(string message, params object[] args);
}
