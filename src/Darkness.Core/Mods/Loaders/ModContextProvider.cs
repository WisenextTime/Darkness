using Darkness.Core.Contents;
using Darkness.Core.Mods.Events;
using Darkness.Core.Network;
namespace Darkness.Core.Mods.Loaders
{
	public class ModContextProvider
	{
		private string _modId;
		private readonly IServerSide _server;
		private readonly IClientSide? _client;
		public IEventBus EventBus { get; }
		public ModContextProvider(string modId, IServerSide server, IClientSide? client,IEventBus eventBus)
		{
			_modId = modId;
			_server = server;
			_client = client;
			EventBus = eventBus;
		}

		public void RegisterType<T>() where T : IContent
		{
			_server.RegisterType<T>();
			_client?.RegisterType<T>();
		}
		public void Register<T>(T content) where T : IContent
		{
			_server.Register(content, _modId);
			_client?.Register(content, _modId);
		}
	}
}