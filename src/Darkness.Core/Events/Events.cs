using System;
using Darkness.Core.Contents;
namespace Darkness.Core.Events;

public class TypeRegisteringEvent(ContentManager manager)
{
	public void Register<T>() where T : IContent => manager.RegisterType<T>();
}