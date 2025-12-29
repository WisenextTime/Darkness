using System.Drawing;
using System.Runtime.Serialization;
namespace Darkness.Core.World.Generate;

public class BlankGenerator : IWorldGenerator
{
	public Chunk GenerateChunk(Chunk baseChunk, int seed, Point coord) => baseChunk;
	public ISerializable? PreGenerate(int seed) => null;
	public void ReadPreGenData(ISerializable data) { }
}