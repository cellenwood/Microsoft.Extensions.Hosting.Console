using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Console;
using Example;

await Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => services
        .AddLogging()
        .AddTransient<MyHost>()
        .AddHostedService<MyHostedService>()
    )
    .RunAsConsoleAsync<MyHost>(host => host.DoWork());