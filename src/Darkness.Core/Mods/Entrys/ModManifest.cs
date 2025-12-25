using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
#pragma warning disable CS8618
namespace Darkness.Core.Mods.Entrys;

[Serializable]
public class ModManifest
{
	/// <summary> 
	///The loader of this pack<br/>
	/// <list type="DotnetLoader|ScriptLoader">
	///		<listheader>
	///			<term>Value</term>
	///			<description>Description</description>
	///		</listheader>
	///		<item>
	///			<term>DotnetLoader</term>
	///			<description>The mod is based on dotnet.</description>
	///		</item>
	///		<item>
	///			<term>ScriptLoader</term>
	///			<description>The mod is based on f# scripts and tomls.</description>
	///		</item>
	/// </list>
	/// </summary>
	[DataMember(Name = "Loader")] public string Loader { get; set; } = "";

	[DataMember(Name = "Id")] public string Id { get; set; } = "";
		
	[DataMember(Name = "Name")] public string Name { get; set; } = "";

	[DataMember(Name = "Version")] public string Version { get; set; } = "";

	[DataMember(Name = "Author")] public string Author { get; set; } = "";

	[DataMember(Name = "Description")] public string Description { get; set; } = "";

	[DataMember(Name = "Dependencies")] public List<ModDependencies> Dependencies { get; set; } = new List<ModDependencies>();
}

[Serializable]
public class ModDependencies
{
	[DataMember(Name = "Id")] public string Id { get; set; } = "";

	[DataMember(Name = "Version")] public string Version { get; set; } = "";
}