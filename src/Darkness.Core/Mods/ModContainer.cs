using System.Reflection;
namespace Darkness.Core.Mods
{
	public struct ModContainer
	{
		public ModContainer(ModManifest modManifest, Assembly? assembly = null, AssetsContainer? assetsContainer = null)
		{
			ModManifest = modManifest;
			Assembly = assembly;
			AssetsContainer = assetsContainer;
		}
		public ModManifest ModManifest { get; private set; }
		public Assembly? Assembly { get; private set; }
		public AssetsContainer? AssetsContainer { get; private set; }
	}
}