using System;
using Darkness.Core.Contents;
namespace Darkness.Core.Exceptions.ContentException;

public class ContentReplacedException<T>(string Id) : InvalidOperationException, IWarningException where T : IContent
{
	public override string Message { get; } = $"{typeof(T).Name}:{Id} has already been exist and it will be replaced.";
}