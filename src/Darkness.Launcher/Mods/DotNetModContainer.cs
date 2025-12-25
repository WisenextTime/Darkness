using System.Reflection;
using Darkness.Core.Mods.Entrys;
using Darkness.Core.Mods.Loaders;
namespace Darkness.Launcher.Mods;

public class DotNetModContainer(Assembly assembly, ModManifest modManifest, string assetsPath)
	: ModContainer(modManifest, assetsPath)
{
	public Assembly Assembly { get; } = assembly;
	public override bool Initialize()
	{
		var modClass = Assembly.ExportedTypes.
			First(t => t.GetCustomAttributes(typeof(ModClassAttribute),false).Length != 0);
		var modEntry = modClass
			.GetMethods(BindingFlags.Static | BindingFlags.Public)
			.First(m => m.GetCustomAttributes(typeof(ModEntryAttribute), false).Length != 0);
		modEntry.Invoke(null, [GameLauncher.GetInstance().EventBus]);
		return true;
	}
}