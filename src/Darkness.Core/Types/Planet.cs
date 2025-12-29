using System.Collections.Generic;
using Darkness.Core.Contents;
using Darkness.Core.World.Generate;
namespace Darkness.Core.Types;

public class Planet(string id) : IContent(id)
{
	public List<IWorldGenerator> Generators { get; init; } = [new BlankGenerator()];
}