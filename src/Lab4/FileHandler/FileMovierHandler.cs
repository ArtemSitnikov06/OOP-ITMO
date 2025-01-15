using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class FileMovierHandler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public FileMovierHandler(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts, AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0] + " " + commandParts[1];
        if (command != "file move")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        if (commandParts.Length <= 2)
        {
            _logger.Log("source and destination not set. Please set the source and destination directory first.");
            return;
        }

        string source = commandParts[2];
        string destination = commandParts[3];

        var fileMover = new FileMover(_logger, source, destination);
        fileMover.Execute();
    }
}