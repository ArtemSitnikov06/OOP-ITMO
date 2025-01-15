using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class FileRenamerHandler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public FileRenamerHandler(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts, AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0] + " " + commandParts[1];
        if (command != "file rename")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        if (commandParts.Length <= 2)
        {
            _logger.Log($"Source file and new Name not set");
            return;
        }

        string source = commandParts[2];
        string newName = commandParts[3];

        var fileRenamer = new FileRenamer(_logger, source, newName);
        fileRenamer.Execute();
    }
}