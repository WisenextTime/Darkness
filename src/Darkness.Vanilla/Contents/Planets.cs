using Darkness.Core.Events;
using Darkness.Core.Types;
using Darkness.Core.World;
using Darkness.Vanilla.Contents.WorldGenerators.Nyx;
namespace Darkness.Vanilla.Contents;

public static class Planets
{
	public static void RegisterPlanets(ContentRegisteringEvent e)
	{
		e.Register(new Planet("Nyx")
		{
			Generators = [
			new NyxBaseGenerator()],
		});
	}
}