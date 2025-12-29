using System.Drawing;
using Darkness.Core.Contents;
namespace Darkness.Core.Types;

public class TerrainFeature(string id) : IContent(id)
{
	public string Texture { get; init; } = $"Textures.Tiles.{id}.png";
	public bool Passable { get; init; } = true;
	public Color Color { get; init; } = Color.White;
}