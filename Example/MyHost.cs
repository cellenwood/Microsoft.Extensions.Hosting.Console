namespace Example;

class MyHost
{
    public Task DoWork()
    {
        Console.WriteLine("I started.");
        return Task.CompletedTask;
    }
}
