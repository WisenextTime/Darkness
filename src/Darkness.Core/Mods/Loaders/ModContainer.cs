using System.Reflection;
using Darkness.Core.Mods.Entrys;
using Darkness.Core.Network;
namespace Darkness.Core.Mods.Loaders;

public abstract class ModContainer
{
	protected ModContainer(ModManifest modManifest, string assetsPath)
	{
		Manifest = modManifest;
	}
	protected ModManifest Manifest { get; private set; }

	public abstract bool Initialize();
}