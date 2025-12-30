using Darkness.Core.Types;
namespace Darkness.Core.World;

public readonly struct Chunk()
{
	public const int ChunkSize = 128;

	public readonly TileData[,] Tiles = new TileData[ChunkSize, ChunkSize];

	public void Initialize()
	{
		for (var x = 0; x < ChunkSize; x++)
		{
			for (var y = 0; y < ChunkSize; y++)
			{
				Tiles[x, y] = new TileData { Tags = [] };
			}
		}
	}
}