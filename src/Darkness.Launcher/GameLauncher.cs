using Darkness.Core.Network;
using Darkness.Launcher.Events;
namespace Darkness.Launcher
{
	public class GameLauncher(IServerSide server, IClientSide? client = null) : ILauncher
	{
		public IServerSide Server { get; } = server;
		public IClientSide? Client { get; } = client;
		private IEventBus _eventBus = new EventBus(exception => server.LogMessage(exception.Message, "error"));
		public void Launch(string[] args)
		{
			
		}
	}
}