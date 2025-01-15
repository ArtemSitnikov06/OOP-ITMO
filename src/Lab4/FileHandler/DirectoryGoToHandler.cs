using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class DirectoryGoToHandler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public DirectoryGoToHandler(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts,  AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0] + " " + commandParts[1];
        if (command != "tree goto")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        if (commandParts.Length < 3)
        {
            _logger.Log("You must set a destination.");
            return;
        }

        string destination = commandParts[2];

        var directoryGoTo = new DirectoryGoTo(_logger, destination);
        directoryGoTo.Execute();
    }
}