namespace Itmo.ObjectOrientedProgramming.Lab4.Logger;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}