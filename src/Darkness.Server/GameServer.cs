using Darkness.Core.Contents;
using Darkness.Core.Network;
using Darkness.Server.Services;
namespace Darkness.Server
{
	public class GameServer(IConsoleLogger logger) : IServerSide
	{
		private readonly Dictionary<Type,Dictionary<string,IContent>> _contents = new();

		public T? GetContent<T>(string id) where T : IContent
		{
			return (T?)_contents[typeof(T)][id];
		}
		public void Register<T>(T content,string modId) where T : IContent
		{
			if (_contents.ContainsKey(content.GetType()))
				_contents[content.GetType()].Add($"{modId}:{content.Id}", content);
			else
				logger.LogMessage($"{content.GetType()} has not been registered", "warning");
		}
		public void RegisterType<T>() where T : IContent
		{
			if (_contents.ContainsKey(typeof(T)))
				logger.LogMessage($"{typeof(T).Name} has already been registered", "warning");
			_contents.Add(typeof(T), new Dictionary<string, IContent>());
		}
		public async Task Run()
		{
			var loop = new GameLoop();
			await loop.RunAsync();
		}
		public void LogMessage(string message, string type = "log")
		{
			logger.LogMessage(message, type);
		}
	}
}