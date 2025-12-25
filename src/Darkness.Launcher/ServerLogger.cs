using Darkness.Server.Services;
using Spectre.Console;
namespace Darkness.Launcher;

public class ServerLogger : IConsoleLogger
{
	public void LogMessage(string message, string type = "log")
	{
		var color = type switch
		{
			"warning" => "yellow",
			"error" => "red",
			"tip" => "cyan",
			_ => "white",
		};
		var time = DateTime.Now.ToString("HH:mm:ss");
		AnsiConsole.Console.MarkupLine($"[[{time}]][{color}][b][[{type.ToUpper()}]][/] {message}[/]");
	}
}