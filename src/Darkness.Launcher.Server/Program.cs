using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Darkness.Core.Contents;
using Darkness.Server;
using Spectre.Console;

namespace Darkness.Launcher.Server;

internal class Program
{
	private static GameLauncher _launcher = null!;
	public static void Main(string[] args)
	{
		var server = new GameServer(new ServerLogger());
		_launcher = new GameLauncher(server);
		_launcher.Launch(args);
		AnsiConsole.Clear();
		var isBreak = false;
		while (!isBreak)
		{
			var input = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("What would you like to do?")
					.AddChoices("Show registered contents", "Generate a test map", "Exit")
			);
			switch (input)
			{
				case "Show registered contents":
					ShowRegisteredContents();
					break;
				case "Generate a test map":
					GenerateTestMap();
					break;
				case "Exit":
					isBreak = true;
					break;
			}
		}
	}
	

	static void  ShowRegisteredContents()
	{
		var contentManager = _launcher.ContentManager;
		var types = new Dictionary<string, IDictionary<string, IContent>>();
		foreach (var type in contentManager.GetRegisteredTypes())
		{
			var contents = contentManager.GetContents(type);
			types.Add(type.Name, contents??new Dictionary<string, IContent>());
		}
		var isBreak = false;
		while (!isBreak)
		{
			var input = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("What would you like to do?")
					.AddChoices(types.Keys)
					.AddChoices("Back")
			);
			switch (input)
			{
				case "Back":
					isBreak = true;
					break;
				default:
					PrintContents(types[input]);
					break;
			}
		}
	}

	static void GenerateTestMap()
	{
	
	}

	static void PrintContents(IDictionary<string, IContent> contents)
	{
		var contentsTable = new Table();
		var type = contents.First().Value.GetType();
		var properties = type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance)
			.Where(p => p.CanRead && p.GetMethod != null && p.GetMethod.IsPublic).OrderBy(info => info.Name != "Id");
		var propertyInfos = properties.ToArray();
		contentsTable.AddColumns(propertyInfos.Select(p => p.Name).ToArray());
		foreach (var content in contents)
		{
			var infos = content.Value.GetType()
				.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.CanRead && p.GetMethod != null && p.GetMethod.IsPublic).OrderBy(info => info.Name != "Id");
			contentsTable.AddRow(
				infos.Select(p =>
						(p.GetMethod?.Invoke(content.Value, null)?.ToString() ?? "").Replace("[", "[[").Replace("]", "]]"))
					.ToArray());
		}
		AnsiConsole.Write(contentsTable);
		var wait = AnsiConsole.Ask<string>("Press enter to continue...");
	}
}