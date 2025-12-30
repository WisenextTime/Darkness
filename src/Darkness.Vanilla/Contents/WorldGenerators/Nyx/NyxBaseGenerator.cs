using System.Drawing;
using Darkness.Core.Utils;
using Darkness.Core.World;
using Darkness.Core.World.Generate;
namespace Darkness.Vanilla.Contents.WorldGenerators.Nyx;

public class NyxBaseGenerator : IWorldGenerator
{
	private int _totalWeight;
	private readonly List<(float maxValue, string geo, string baseTileId)> _cache = [];
	private readonly Dictionary<string,(int weight,string baseTileId)> _geos = [];

	public NyxBaseGenerator()
	{
		_geos.Add("MetalPlains",(30,"HardAlloy"));
		_geos.Add("CrystalFields",(25,"VolatileCrystal"));
		_geos.Add("MethaneWetland",(20,"MetalIce"));
		Refresh();
		
	}
	public Chunk GenerateChunk(Chunk baseChunk, int seed, Point coord)
	{
		var noise = NoisePool.Instance.GetNoise();
		noise.SetSeed(seed);
		noise.SetNoiseType(FastNoiseLite.NoiseType.Cellular);
		noise.SetCellularReturnType(FastNoiseLite.CellularReturnType.CellValue);
		noise.SetFrequency(0.001f);
		var domainWarp = NoisePool.Instance.GetNoise();
		domainWarp.SetSeed(seed+101);
		domainWarp.SetDomainWarpType(FastNoiseLite.DomainWarpType.OpenSimplex2);
		domainWarp.SetDomainWarpAmp(40);
		domainWarp.SetFrequency(0.015f);
		Parallel.For(0, Chunk.ChunkSize, x =>
		{
			Parallel.For(0, Chunk.ChunkSize, y =>
			{
				var globalX = coord.X * Chunk.ChunkSize + x;
				var globalY = coord.Y * Chunk.ChunkSize + y;
				var tile = baseChunk.Tiles[x, y];
				float warpX = globalX, warpY = globalY;
				domainWarp.DomainWarp(ref warpX, ref warpY);
				var geoValue = noise.GetNoise(warpX, warpY);
				SetGeo(ref tile, geoValue);
				baseChunk.Tiles[x, y] = tile;
				});
		});
		return baseChunk;
	}

	private void SetGeo(ref TileData tile, float noiseValue)
	{
		int i;
		for (i = 0; i < _cache.Count && _cache[i].maxValue < noiseValue; i++) ;
		if (i >= _cache.Count) i--;
		tile.Tags.Add($"Geo:{_cache[i].geo}");
		tile.Id = _cache[i].baseTileId;
	}
	
	public void Refresh()
	{
		_cache.Clear();
		_totalWeight = _geos.Sum(geo => geo.Value.weight);
		float lastMaxValue = -1;
		foreach (var geo in _geos)
		{
			lastMaxValue += 2f * geo.Value.weight / _totalWeight;
			_cache.Add((lastMaxValue, geo.Key, geo.Value.baseTileId));
		}
	}
}