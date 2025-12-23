using Darkness.Core.Mods.Events;
using Darkness.Core.Network;
namespace Darkness.Core
{
	public interface ILauncher
	{
		
		public IServerSide Server { get; }
		public IClientSide? Client { get; }
		public IEventBus EventBus { get; }
		void Launch(string[] args);
	}
}