using Darkness.Core.Contents;
using Darkness.Core.Network;
namespace Darkness.Core.Mods
{
	public interface IRegistry
	{
		void Register(IContent content);
	}
}