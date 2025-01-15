using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class FileConnectorHadnler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public FileConnectorHadnler(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts, AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0];
        if (command != "connect")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        string mode = commandParts[3];
        if (mode != "local")
        {
            _logger.Log("mode must be local");
            return;
        }

        string destination = commandParts[1];

        var fileConnect = new FileConnector(_logger, connectedFileSystem, destination);
        fileConnect.Execute();
    }
}