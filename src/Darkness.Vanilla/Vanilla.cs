using Darkness.Core.Events;
using Darkness.Core.Mods.Entrys;
using Darkness.Core.Types;
using Darkness.Core.World.Generate;
using Darkness.Vanilla.Contents;
namespace Darkness.Vanilla;

[ModClass]
public class Vanilla
{
	[ModEntry]
	public static void Initialize(EventBus eventBus)
	{
		eventBus.Subscribe<TypeRegisteringEvent>(RegisterTypes);
		eventBus.Subscribe<ContentRegisteringEvent>(RegisterContents);
	}

	private static void RegisterTypes(TypeRegisteringEvent e)
	{
		e.Register<Tile>();
		e.Register<TerrainFeature>();
		e.Register<Planet>();
	}
	
	private static void RegisterContents(ContentRegisteringEvent e)
	{
		Tiles.RegisterTiles(e);
		Planets.RegisterPlanets(e);
	}
}