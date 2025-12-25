using Darkness.Launcher;
using Darkness.Server;
using Spectre.Console;
var server = new GameServer(new ServerLogger());
var launcher = new GameLauncher(server);
launcher.Launch(args);
var input = "";
while (input != "Exit")
{
	input = AnsiConsole.Prompt(
		new SelectionPrompt<string>()
			.Title("What would you like to do?")
			.AddChoices("Show registered contents", "Generate a test map", "Exit")
	);
	switch (input)
	{
		
	}
}