using NotebookBackend.Services;

namespace NotebookBackend.Implementations;

public class ConsoleGreeter : IGreeter
{
    private int _counter = 1;

    public void SayHello()
    {
        Console.WriteLine($"Hello {_counter}");
        ++_counter;
    }
}