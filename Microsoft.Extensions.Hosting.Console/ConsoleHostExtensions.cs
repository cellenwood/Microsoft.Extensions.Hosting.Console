using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting.Console
{
    public static class ConsoleHostExtensions
    {
        public static async Task RunAsConsoleAsync<T>(this IHostBuilder builder, Action<T> action) where T : class
        {
            builder.ConfigureServices((hostContext, services) => services
                .AddHostedService(services =>
                {
                    var startupObject = services.GetService<T>();
                    var console = new ConsoleHost<T>(services.GetService<IHostApplicationLifetime>(), startupObject, action);
                    return console;
                }));

            await builder.RunConsoleAsync();
        }
    }
}
