using Darkness.Launcher;
using Darkness.Launcher.Server;
using Darkness.Server;
var launcher = new GameLauncher(new GameServer(new ServerLogger()));
launcher.Launch(args);