namespace Darkness.Launcher.Utils;

public class ArgumentList
{
	public ArgumentList(string[] args)
	{
		var lastArg = "";
		foreach (var arg in args)
		{
			if (arg.StartsWith('-'))
			{
				if (lastArg != "") TagArguments.Add(lastArg[1..].Trim());
				lastArg = arg;
			}
			else
			{
				if (lastArg != "") ValueArguments.Add(lastArg[1..].Trim(), arg);
				lastArg = "";
			}
		}
	}
	public Dictionary<string,string> ValueArguments { get; } = new();
	public List<string> TagArguments { get; } = [];
}