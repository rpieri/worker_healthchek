namespace WorkerService3;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly WorkerWitness _witness;

    public Worker(ILogger<Worker> logger, WorkerWitness witness)
    {
        _logger = logger;
        _witness = witness;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            _witness.LastExecution = DateTime.Now;
            await Task.Delay(1000, stoppingToken);
        }
    }
}