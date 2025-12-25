using System;
using Darkness.Core.Contents;
namespace Darkness.Core.Exceptions.ContentException;

public class ContentTypeNotExistingException<T> : InvalidOperationException, IWarningException where T : IContent
{
	public override string Message { get; } = $"{typeof(T).Name} is not exist.";
}