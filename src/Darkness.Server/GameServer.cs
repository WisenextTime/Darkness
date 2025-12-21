using Darkness.Core.Contents;
using Darkness.Core.Network;
using Darkness.Server.Services;
namespace Darkness.Server
{
	public class GameServer(IConsoleLogger logger) : IServerSide
	{
		public void Register(IContent content)
		{
		
		}
		public void LogMessage(string message, string type = "log")
		{
			logger.LogMessage(message, type);
		}
	}
}