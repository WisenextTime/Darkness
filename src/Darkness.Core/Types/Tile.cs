using Darkness.Core.Contents;
namespace Darkness.Core.Types;

public class Tile(string id) : IContent(id)
{
	public string Texture = $"Textures.Tiles.{id}.png";
}