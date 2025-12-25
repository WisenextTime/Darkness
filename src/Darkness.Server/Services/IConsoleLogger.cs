namespace Darkness.Server.Services;

public interface IConsoleLogger
{
	public void LogMessage(string message, string type = "log");
}