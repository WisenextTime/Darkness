using System;
using System.Runtime.Serialization;
#pragma warning disable CS8618
namespace Darkness.Core.Mods
{
	[Serializable]
	public class PackManifest
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
		[DataMember(Name = "Loader")]
		public string Loader { get; set; }
	}
	[Serializable]
	public class ModManifest
	{
		[DataMember(Name = "Id")]
		public string Id { get; set; }
		
		[DataMember(Name = "Version")]
		public string Version { get; set; }
	} 
}