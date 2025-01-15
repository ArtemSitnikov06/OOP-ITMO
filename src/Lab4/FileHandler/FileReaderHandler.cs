using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class FileReaderHandler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    public FileReaderHandler(ILogger logger)
    {
        _logger = logger;
    }

    public override void Handle(string[] commandParts, AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0] + " " + commandParts[1];
        if (command != "file show")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        string mode = commandParts[4];
        if (mode != "console")
        {
            _logger.Log("mode nust be console");
            return;
        }

        string source = commandParts[2];

        var fileReader = new FileReader(_logger, source);
        fileReader.Execute();
    }
}