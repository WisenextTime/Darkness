using System.Drawing;
using Darkness.Core.Utils;
using Darkness.Core.World;
using Darkness.Core.World.Generate;
namespace Darkness.Vanilla.Contents.WorldGenerators.Nyx;

public class NyxBaseGenerator : IWorldGenerator
{

	public Chunk GenerateChunk(ref Chunk baseChunk, int seed, Point coord)
	{
		var noise = new FastNoiseLite(seed);
		noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
		noise.SetFrequency(0.001f);
		for (var x = 0; x < Chunk.ChunkSize; x++)
		{
			for (var y = 0; y < Chunk.ChunkSize; y++)
			{
				var noiseValue = noise.GetNoise(x, y);
				baseChunk.Tiles[x,y].Tags.Add(noiseValue switch
				{
					
				});
			}
		}
		return baseChunk;
	}
}