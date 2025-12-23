using System;
namespace Darkness.Core.Mods.Events
{
	public interface IEventBus
	{
		void Publish<TEvent>(TEvent @event);
		IDisposable Subscribe<TEvent>(Action<TEvent> handler) where TEvent : class;
		void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : class;
	}
}