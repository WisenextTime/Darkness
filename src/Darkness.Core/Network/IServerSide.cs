namespace Darkness.Core.Network
{
	public interface IServerSide : IServicesSide
	{
		void LogMessage(string message, string type = "log");
	}
}