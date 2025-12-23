using System.Diagnostics;
namespace Darkness.Server;

public class GameLoop
{
    private const int Tps = 60;
    private const double FixedDeltaTime = 1.0 / Tps;
    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(FixedDeltaTime));
    private bool _isRunning;
    private readonly Stopwatch _watch = Stopwatch.StartNew();
    private double _accumulator;

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        _isRunning = true;
        var lastTime = _watch.Elapsed.TotalSeconds;

        try
        {
            while (_isRunning && 
                   await _timer.WaitForNextTickAsync(cancellationToken))
            {
                var currentTime = _watch.Elapsed.TotalSeconds;
                var frameTime = currentTime - lastTime;
                lastTime = currentTime;
                
                _accumulator += frameTime;
                
                while (_accumulator >= FixedDeltaTime)
                {
                    Update(FixedDeltaTime);
                    _accumulator -= FixedDeltaTime;
                }
            }
        }
        catch (OperationCanceledException)
        {
            // 正常取消
        }
        finally
        {
            _watch.Stop();
        }
    }
    
    private void Update(double deltaTime)
    {
        ProcessNetworkMessages();
        
        UpdateGameState(deltaTime);
        
        SyncStateToClients();
        
        Cleanup();
    }
    private void Cleanup()
    {
        //TODO
    }

    private void ProcessNetworkMessages()
    {
        //TODO
    }
    
    private void UpdateGameState(double deltaTime)
    {
        //TODO
    }
    
    private void SyncStateToClients()
    {
        //TODO
    }
    
    public void Stop()
    {
        _isRunning = false;
    }
}