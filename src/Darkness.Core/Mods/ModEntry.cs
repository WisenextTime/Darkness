using System;
namespace Darkness.Core.Mods
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class ModClassAttribute : Attribute
	{
		
	}
	
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public class ModEntryAttribute : Attribute
	{
		
	}
}