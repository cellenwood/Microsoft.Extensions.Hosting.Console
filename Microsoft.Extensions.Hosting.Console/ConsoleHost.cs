using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting.Console
{
    public partial class ConsoleHost<T> : IHostedService where T : class
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly T _startupObject;
        private readonly Action<T> _startupFunction;

        private ExitCode? _exitCode;

        public ConsoleHost(IHostApplicationLifetime appLifetime, T startupObject, Action<T> startupFunction)
        {
            _appLifetime = appLifetime;
            _startupObject = startupObject;
            _startupFunction = startupFunction;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var args = Environment.GetCommandLineArgs();
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(() =>
                {
                    try
                    {
                        _startupFunction.Invoke(_startupObject);
                    }
                    catch (Exception)
                    {
                        _exitCode = ExitCode.Failure;
                        throw;
                    }
                    finally
                    {
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            var exitCode = (int)_exitCode.GetValueOrDefault(ExitCode.Success);
            Environment.ExitCode = exitCode;
            return Task.CompletedTask;
        }
    }
}
