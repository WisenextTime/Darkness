using Darkness.Core.Types;
namespace Darkness.Core.World;

public readonly struct Chunk()
{
	public const int ChunkSize = 128;

	public readonly TileData[,] Tiles = new TileData[ChunkSize, ChunkSize];

	public void Initialize()
	{
		Tiles.Initialize();
	}
}