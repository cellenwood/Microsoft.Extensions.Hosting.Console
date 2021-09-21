using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Console;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        public static async Task Main(string[] args)
            => await CreateHostBuilder(args)
                .RunAsConsoleAsync<MyHost>(host => host.DoWork());

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => services
                    .AddLogging()
                    .AddTransient<MyHost>()
                    .AddHostedService<MyHostedService>()
                );
    }
}
