using System.Collections;
using Darkness.Core;
using Darkness.Core.Contents;
using Darkness.Core.Events;
using Darkness.Core.Exceptions;
using Darkness.Core.Network;
using Darkness.Launcher.Utils;
// ReSharper disable SuspiciousTypeConversion.Global
namespace Darkness.Launcher;

public class GameLauncher : ILauncher
{
	private static GameLauncher? _instance;
	public static GameLauncher GetInstance()
	{
		return _instance ?? throw new InvalidOperationException("The server is not running.");
	}
	public IServerSide Server { get; }
	public IClientSide? Client { get; }
		
	public EventBus EventBus { get; }
	public bool IsRunning { get; private set; }
	private ArgumentList? _arguments;
	public GameLauncher(IServerSide server, IClientSide? client = null)
	{
		if(_instance is not null) throw new InvalidOperationException("There is already a launcher running.");
		Server = server;
		Client = client;
		EventBus = new EventBus();
		_instance = this;
	}
	public ArgumentList GetArguments()
	{
		if(IsRunning&&_arguments is not null) return _arguments;
		throw new InvalidOperationException("Can't get arguments before launching game");
	}
	public void Launch(string[] args)
	{
		IsRunning = true;
		//Parse args
		_arguments = new ArgumentList(args);
		//Init mod manager
		Server.LogMessage("Init mod loader......");
		var modManager = new ModManager();
		var contentManager = new ContentManager();
		Server.LogMessage("Load vanilla dll......");
		modManager.LoadDll("Darkness.Vanilla.dll", "Assets/Manifest.toml", "Assets");
		Server.LogMessage("Load mods......");
		/* TODO:
		 Load Mods
		 */
		modManager.LoadContents();
		Server.LogMessage("Register types......");
		var exceptions = EventBus.Publish(new TypeRegisteringEvent(contentManager));
		LogExceptions(exceptions);
	}

	private void LogExceptions(params IEnumerable<Exception> exceptions)
	{
		
		foreach (var exception in exceptions)
		{
			switch (exception)
			{
				case IWarningException:
				{
					Server.LogMessage(exception.Message,"warning");
					break;
				}
				case IErrorException:
				{
					var lines = string.Join(
						'\n',
						exception.Data.Cast<DictionaryEntry>()
							.Select(entry => $"{entry.Key}: {entry.Value?.ToString() ?? "[null]"}"));
					Server.LogMessage(lines,"error");
					break;
				}
				default:
					throw exception;
			}
		}
	}
}