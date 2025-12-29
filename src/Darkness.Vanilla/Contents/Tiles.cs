using System.Drawing;
using Darkness.Core.Events;
using Darkness.Core.Types;
namespace Darkness.Vanilla.Contents;

public static class Tiles
{
	public readonly static Tile[] TilesArray =
	[
		//Base tiles
		new("HardAlloy")
		{
			Color = Color.FromArgb(103,103,103),
		},
		new("MetalIce")
		{
			Color = Color.FromArgb(45,104,104),
		},
		new("VolatileCrystal")
		{
			Color = Color.FromArgb(12,60,53),
		},
		new("SilicateRock")
		{
			Color = Color.FromArgb(58,86,30),
		},
		new("HydrothermalDeposit")
		{
			Color = Color.FromArgb(255,161,0),
		},
		
		//Liquids
		new("Methane")
		{
			Color = Color.FromArgb(128,128,128),
			Type = TileType.Liquid,
		},
		new("SulfurSlurry")
		{
			Color = Color.FromArgb(80,12,12),
			Type = TileType.Liquid,
		}
	];
	public static void RegisterTiles(ContentRegisteringEvent e)
	{
		e.Register(Tile.Empty);
		foreach (var tile in TilesArray)
		{
			e.Register(tile);
		}
	}
}