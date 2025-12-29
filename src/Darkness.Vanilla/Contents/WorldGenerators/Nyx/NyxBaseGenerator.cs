using System.Drawing;
using System.Runtime.Serialization;
using Darkness.Core.Utils;
using Darkness.Core.World;
using Darkness.Core.World.Generate;
namespace Darkness.Vanilla.Contents.WorldGenerators.Nyx;

public class NyxBaseGenerator : IWorldGenerator
{
	public Chunk GenerateChunk(Chunk baseChunk, int seed, Point coord)
	{
		var noise = new FastNoiseLite(seed);
		Parallel.For(0, Chunk.ChunkSize, x =>
		{
			Parallel.For(0, Chunk.ChunkSize, y =>
				{
					var globalX = coord.X * x;
					var globalY = coord.Y * y;
					var tile = baseChunk.Tiles[globalX, globalY];
				});
		});
		return baseChunk;
	}
	public ISerializable? PreGenerate(int seed)
	{
		throw new NotImplementedException();
	}
	public void ReadPreGenData(ISerializable data)
	{
		
	}
}