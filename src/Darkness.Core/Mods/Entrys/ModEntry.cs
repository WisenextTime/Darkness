using System;
namespace Darkness.Core.Mods.Entrys;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ModClassAttribute : Attribute
{
		
}
	
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class ModEntryAttribute : Attribute
{
		
}