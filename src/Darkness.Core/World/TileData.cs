using System.Collections.Generic;
namespace Darkness.Core.World;

public struct TileData(string id = "Empty")
{
	public string Id = id;
	public readonly List<string> Tags = [];
}