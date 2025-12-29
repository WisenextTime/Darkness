using System.Drawing;
namespace Darkness.Core.World.Generate;

public class BlankGenerator : IWorldGenerator
{
	public Chunk GenerateChunk(ref Chunk baseChunk, int seed, Point coord) => baseChunk;
}