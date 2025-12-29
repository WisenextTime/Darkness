using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Darkness.Core.Types;
namespace Darkness.Core.World;

public class Map(int seed, Planet planet)
{
	public int Seed { get; } = seed;
	public Planet Planet { get; } = planet;
	public Dictionary<Point, Chunk> Chunks { get; } = [];
	private void GenerateChunk(int coordX, int coordY) => GenerateChunk(new Point(coordX, coordY));

	private void GenerateChunk(Point coord)
	{
		if(!Chunks.TryGetValue(coord, out var chunk)) chunk = new Chunk();
		chunk.Initialize();
		chunk = Planet.Generators.Aggregate(chunk, (current, generator) => generator.GenerateChunk(current, Seed, coord));
		Chunks[coord] = chunk;
	}
}