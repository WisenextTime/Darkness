using System.Collections.Concurrent;
namespace Darkness.Launcher.Events
{
	public interface IEventBus
	{
		void Publish<TEvent>(TEvent @event);
		IDisposable Subscribe<TEvent>(Action<TEvent> handler) where TEvent : class;
		void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : class;
	}

	public class EventBus(Action<Exception> errorCatcher) : IEventBus
	{

		private readonly ConcurrentDictionary<Type, List<Delegate>> _handlers = new();

		public void Publish<TEvent>(TEvent @event)
		{
			if(@event == null) throw new ArgumentNullException(nameof(@event));
			var type = typeof(TEvent);
			if (!_handlers.TryGetValue(type, out var handlers)) return;
			var list = handlers.ToList();
			foreach (var handler in list)
			{
				try
				{
					((Action<TEvent>)handler)(@event);
				}
				catch (Exception e)
				{
					errorCatcher(e);
				}
			}
		}
		public IDisposable Subscribe<TEvent>(Action<TEvent> handler) where TEvent : class
		{
			if (handler == null) throw new ArgumentNullException(nameof(handler));
			var type = typeof(TEvent);
			var handlers = _handlers.GetOrAdd(type, []);
			lock (handlers)
			{
				handlers.Add(handler);
			}
			return new Subscription<TEvent>(this, handler);
		}
		public void Unsubscribe<TEvent>(Action<TEvent>? handler) where TEvent : class
		{
			if(handler == null) return;
			var type = typeof(TEvent);
			if (!_handlers.TryGetValue(type, out var handlers)) return;
			lock (handlers)
			{
				handlers.Remove(handler);
			}
		}
		private class Subscription<TEvent>(EventBus eventBus, Action<TEvent> handler) : IDisposable
			where TEvent : class
		{
			public void Dispose()
			{
				eventBus.Unsubscribe(handler);
			}
		}
	}
}