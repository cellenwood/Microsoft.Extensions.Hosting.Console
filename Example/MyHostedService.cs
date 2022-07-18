using Microsoft.Extensions.Hosting;

namespace Example;

class MyHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("I also started");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("I also stopped");
        return Task.CompletedTask;
    }
}
