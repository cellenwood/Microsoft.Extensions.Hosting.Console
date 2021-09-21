using System.Threading.Tasks;
using static System.Console;

namespace Example
{
    class MyHost
    {
        public Task DoWork()
        {
            WriteLine("I started.");
            return Task.CompletedTask;
        }
    }
}
