using System;
using System.Collections.Generic;
using Darkness.Core.Exceptions;
using Darkness.Core.Exceptions.ContentException;
namespace Darkness.Core.Contents;

public class ContentManager
{
	private readonly Dictionary<Type, Dictionary<string, IContent>> _contents = new();

	public void RegisterType<T>() where T : IContent
	{
		if (_contents.ContainsKey(typeof(T))) throw new ContentTypeExistingException<T>();
		_contents.Add(typeof(T), new Dictionary<string, IContent>());
	}

	public void RegisterContent<T>(T content) where T : IContent
	{
		if (!_contents.ContainsKey(typeof(T))) throw new ContentTypeNotExistingException<T>();
		var replaced = _contents[typeof(T)].ContainsKey(content.Id);
		_contents[typeof(T)][content.Id]= content;
	}
}