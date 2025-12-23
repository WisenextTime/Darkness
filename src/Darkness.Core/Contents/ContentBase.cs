using System;
using System.Collections.Generic;
namespace Darkness.Core.Contents
{
	public abstract class ContentBase : IContent
	{
		protected ContentBase(string id)
		{
			Id = id;
		}
		public string Id { get; }

		protected Dictionary<Type, IContentComponent> Components { get; } = new Dictionary<Type, IContentComponent>();
		public T? GetComponent<T>() where T : struct, IContentComponent => Components.GetValueOrDefault(typeof(T)) as T?;
	
		public bool HasComponent<T>() where T : struct, IContentComponent => Components.ContainsKey(typeof(T));
	
		public bool TryGetComponent<T>(out T? component) where T : struct, IContentComponent
		{
			var final = Components.TryGetValue(typeof(T), out var value);
			component = (T?)value;
			return final;
		}
		public void SetComponent<T>(T component) where T : struct, IContentComponent => Components[typeof(T)] = component;

	}
}