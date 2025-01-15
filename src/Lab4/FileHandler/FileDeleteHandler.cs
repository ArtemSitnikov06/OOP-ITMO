using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class FileDeleteHandler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public FileDeleteHandler(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts,  AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0] + " " + commandParts[1];

        if (command != "file delete")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        if (commandParts.Length < 3)
        {
            _logger.Log($"You must set file which you want to delete: {command}");
            return;
        }

        string source = commandParts[2];

        var fileDeleter = new FileDeleter(_logger, source);
        fileDeleter.Execute();
    }
}