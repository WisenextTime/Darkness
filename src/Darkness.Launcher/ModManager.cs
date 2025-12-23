using System.Reflection;
using Darkness.Core;
using Darkness.Core.Mods.Entrys;
using Darkness.Core.Mods.Loaders;
using Darkness.Launcher.Mods;
using Tomlyn;
namespace Darkness.Launcher;

public class ModManager(ILauncher GameLauncher)
{
	private Dictionary<string, ModContainer> _mods = [];
	internal void LoadDll(string dllPath,string manifestPath, string assetsPath)
	{
		using var manifestStream = new FileStream(manifestPath, FileMode.Open);
		using var reader = new StreamReader(manifestStream);
		var manifest = Toml.Parse(reader.ReadToEnd()).ToModel<ModManifest>();
		LoadDll(Assembly.LoadFrom(dllPath), manifest, assetsPath);
	}

	internal void LoadDll(Assembly dll, ModManifest manifest, string assetsPath)
	{
		var container = new DotNetModContainer(dll, manifest, assetsPath);
		_mods.Add(manifest.Name, container);
	}

	internal void LoadContents()
	{
		foreach (var mod in _mods)
		{
			mod.Value.Initialize();
		}
	}
} 