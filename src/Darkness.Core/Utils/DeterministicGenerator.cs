using System.Collections.Generic;
namespace Darkness.Core.Utils;

public static class DeterministicGenerator
{
	private const uint FnvPrime0 = 0x01000193;
	private const uint FnvPrime1 = 0x85ebca6b;
	private const uint FnvPrime2 = 0xc2b2ae35;

	private readonly static Dictionary<(int, int, int), uint> _cache = [];
	public static uint GetPositionHash(int x, int y, int seed)
	{
		if (_cache.TryGetValue((x, y, seed), out var value)) return value;
		value = (uint)seed;

		value ^= (uint)x;
		value *= FnvPrime0;
		value ^= (uint)y;
		value *= FnvPrime0;

		value ^= value >> 16;
		value *= FnvPrime1;
		value ^= value >> 13;
		value *= FnvPrime2;
		value ^= value >> 16;
		_cache[(x, y, seed)] = value;
		return value;
	}

	public static float HashToFloat(uint hash)
	{
		return (hash & 0x00ffffff) / (float)0x00ffffff;
	}
}