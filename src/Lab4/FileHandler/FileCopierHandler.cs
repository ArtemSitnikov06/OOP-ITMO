using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class FileCopierHandler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public FileCopierHandler(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts,  AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0] + " " + commandParts[1];

        if (command != "file copy")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        if (commandParts.Length <= 2)
        {
            _logger.Log("Source or destination file equal null. Please try again");
            return;
        }

        string source = commandParts[2];
        string destination = commandParts[3];

        var fileCopier = new FileCopier(_logger, source, destination);
        fileCopier.Execute();
    }
    }
