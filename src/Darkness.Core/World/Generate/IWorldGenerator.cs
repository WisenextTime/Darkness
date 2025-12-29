using System;
using System.Drawing;
namespace Darkness.Core.World.Generate;

public interface IWorldGenerator
{
	public Chunk GenerateChunk(ref Chunk baseChunk ,int seed, Point coord);
}