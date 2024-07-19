using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WorkerService3;

public class WorkerHealthCheck: IHealthCheck
{
    private readonly WorkerWitness _witness;

    public WorkerHealthCheck(WorkerWitness witness)
    {
        _witness = witness;
    }
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        //Check if service run for the last 2 mins
        return DateTime.Now.Subtract(_witness.LastExecution).TotalSeconds < 120 ?
            Task.FromResult(HealthCheckResult.Healthy()) :
            Task.FromResult(HealthCheckResult.Unhealthy());
    }
}

public class WorkerWitness
{
    public DateTime LastExecution { get; set; }
}