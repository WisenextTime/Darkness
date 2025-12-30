using System.Collections.Concurrent;
namespace Darkness.Core.Utils;

public class NoisePool
{
	private NoisePool()
	{
		for (var _ = 0; _ < 10; _++)
		{
			_noises.Add(new FastNoiseLite());
		}
	}
	public static NoisePool Instance { get; } = new();

	private readonly ConcurrentBag<FastNoiseLite> _noises = [];
	
	public FastNoiseLite GetNoise() => _noises.TryTake(out var noise) ? noise : new FastNoiseLite();
	
	public void Return(FastNoiseLite noise) => _noises.Add(noise);
}