using Darkness.Core;
using Darkness.Core.Mods.Events;
using Darkness.Core.Network;
using Darkness.Launcher.Events;
using Darkness.Launcher.Utils;
namespace Darkness.Launcher
{
	public class GameLauncher : ILauncher
	{
		private static GameLauncher? _instance;
		public static GameLauncher GetInstance()
		{
			return _instance ?? throw new InvalidOperationException("The server is not running.");
		}
		public IServerSide Server { get; }
		public IClientSide? Client { get; }
		public IEventBus EventBus { get;private set; }
		public bool IsRunning { get; private set; }
		private ArgumentList? _arguments;
		public GameLauncher(IServerSide server, IClientSide? client = null)
		{
			if(_instance is not null) throw new InvalidOperationException("There is already a launcher running.");
			Server = server;
			Client = client;
			EventBus = new EventBus(exception => server.LogMessage(exception.Message, "error"));
			_instance = this;
		}
		public ArgumentList GetArguments()
		{
			if(IsRunning&&_arguments is not null) return _arguments;
			throw new InvalidOperationException("Can't get arguments before launching game");
		}
		public void Launch(string[] args)
		{
			IsRunning = true;
			//Parse args
			_arguments = new ArgumentList(args);
			
			//Init mod manager
			Server.LogMessage("Init mod loader......");
			var modManager = new ModManager(this);
			Server.LogMessage("Load vanilla dll......");
			modManager.LoadDll("Darkness.Vanilla.dll", "Assets/Manifest.toml", "Assets");
			Server.LogMessage("Load mods......");
			/* TODO:
			 Load Mods
			 */
			modManager.LoadContents();
		}
	}
}