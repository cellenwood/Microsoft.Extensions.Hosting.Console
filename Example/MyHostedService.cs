using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Example
{
    class MyHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteLine("I also started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteLine("I also stopped");
            return Task.CompletedTask;
        }
    }
}
