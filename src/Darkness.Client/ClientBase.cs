using System.Threading.Tasks;
using Darkness.Core.Contents;
using Darkness.Core.Network;
namespace Darkness.Client
{
	public class ClientBase : IClientSide
	{
		public void Register<T>(T content, string modId) where T : IContent
		{
			//TODO Register content at ClientSide
		}
		public void RegisterType<T>() where T : IContent
		{
			//TODO Register content type at ClientSide
		}
		public async Task Run()
		{
			//TODO Run ClientSide
		}
	}
}