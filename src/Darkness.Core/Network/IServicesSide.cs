using System.Threading.Tasks;
using Darkness.Core.Contents;
namespace Darkness.Core.Network
{
	public interface IServicesSide
	{
		public void Register<T>(T content,string modId) where T : IContent;
		public void RegisterType<T>() where T : IContent;

		public Task Run();
	}
}