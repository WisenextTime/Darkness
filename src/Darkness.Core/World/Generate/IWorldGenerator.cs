using System;
using System.Drawing;
using System.Runtime.Serialization;
namespace Darkness.Core.World.Generate;

public interface IWorldGenerator
{
	public Chunk GenerateChunk(Chunk baseChunk, int seed, Point coord);
	public ISerializable? PreGenerate(int seed);
	
	public void ReadPreGenData(ISerializable data);
}