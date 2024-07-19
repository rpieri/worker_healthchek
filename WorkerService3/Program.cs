using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WorkerService3;
var witness = new WorkerWitness();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton(witness)
    .AddHealthChecks()
    .AddCheck<WorkerHealthCheck>("worker1");

var host = builder.Build();
host.UseRouting();

host.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true
});
host.Run();