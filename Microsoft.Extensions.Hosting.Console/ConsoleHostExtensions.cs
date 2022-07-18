using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting.Console;

public static class ConsoleHostExtensions
{
    public static async Task RunAsConsoleAsync<T>(this IHostBuilder builder, Action<T> action) where T : class
    {
        builder.ConfigureServices((hostContext, services) => services
            .AddHostedService(services =>
            {
                var startupObject = services.GetRequiredService<T>();
                var appLifetime = services.GetRequiredService<IHostApplicationLifetime>();
                return new ConsoleHost<T>(appLifetime, startupObject, action);
            }));

        await builder.RunConsoleAsync();
    }
}
