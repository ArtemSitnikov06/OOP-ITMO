using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messanger;

public class Messenger : IMessenger
{
    private readonly ILogger _logger;

    public Messenger(ILogger logger)
    {
        _logger = logger;
    }

    public void ShowMessage(string message)
    {
        _logger.Log("messenger : " + message);
    }
}