using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class FileDisconectorHandle : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public FileDisconectorHandle(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts, AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0];
        if (command != "disconnect")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        var fileDisconnect = new FileDisconector(_logger, connectedFileSystem);
        fileDisconnect.Execute();
    }
}