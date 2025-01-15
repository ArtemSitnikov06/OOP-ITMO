using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayEntity;

public class DisplayDriver : IDisplayDriver
{
    private readonly ILogger _logger;

    public DisplayDriver(ILogger logger)
    {
        _logger = logger;
    }

    public void Clear()
    {
        Console.Clear();
        _logger.Log("Display cleared.");
    }

    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        _logger.Log($"Display color set to {color}");
    }

    public void WriteText(string text)
    {
        _logger.Log(text);
    }
}