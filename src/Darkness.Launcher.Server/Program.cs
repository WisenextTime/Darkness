using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Darkness.Core.Contents;
using Darkness.Core.Types;
using Darkness.Core.World;
using Darkness.Server;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
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
					.Title("Choose a content type")
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
		var seed = AnsiConsole.Ask<int>("Enter the seed of the test map");
		AnsiConsole.WriteLine("Generating test map...");
		var world = new Map(seed, _launcher.ContentManager.GetContents<Planet>()["Nyx"]!);
		const int chunks = 10;
		for (var x = 0; x < chunks; x++)
		{
			for (var y = 0; y < chunks; y++)
			{
				world.GenerateChunk(x, y);
			}
		}
		var bitMap = new Image<Rgba32>(128*chunks, 128*chunks);
		for (var x = 0; x < 128*chunks; x++)
		{
			for (var y = 0; y < 128*chunks; y++)
			{
				var tileId = world.Chunks[new System.Drawing.Point(x / 128, + y / 128)].Tiles[x%128, y%128].Id;
				var color = _launcher.ContentManager.GetContents<Tile>()[tileId]!.Color;
				bitMap[x,y] = new Rgba32(color.R, color.G, color.B, color.A);
			}
			bitMap.SaveAsPng("Output.png");
		}
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