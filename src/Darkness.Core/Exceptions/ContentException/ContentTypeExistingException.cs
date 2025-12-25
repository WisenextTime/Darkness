using System;
using Darkness.Core.Contents;
namespace Darkness.Core.Exceptions.ContentException;

public class ContentTypeExistingException<T> : InvalidOperationException, IWarningException where T : IContent
{
	public override string Message { get; } = $"{typeof(T).Name} has already been added to the content type.";
}