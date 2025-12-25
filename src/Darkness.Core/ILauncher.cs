using Darkness.Core.Events;
using Darkness.Core.Network;
namespace Darkness.Core
{
	public interface ILauncher
	{
		public IServerSide Server { get; }
		public IClientSide? Client { get; }
		public EventBus EventBus { get; }
		void Launch(string[] args);
	}
}