using Darkness.Core.Mods.Loaders;
using Darkness.Core.Mods.Parts;
using Darkness.Core.Types;
using Darkness.Vanilla.Contents;
namespace Darkness.Vanilla;

[ModClass]
public class Vanilla
{
	[ModEntry]
	public static void Initialize(ModContextProvider context)
	{
		context.RegisterType<Tile>();
		Tiles.RegisterTiles();
	}
}