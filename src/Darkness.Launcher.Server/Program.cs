using Darkness.Launcher;
using Darkness.Server;
var launcher = new GameLauncher(new GameServer(new ServerLogger()));
launcher.Launch(args);