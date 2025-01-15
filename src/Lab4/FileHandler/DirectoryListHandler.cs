using Itmo.ObjectOrientedProgramming.Lab4.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class DirectoryListHandler : BaseFileCommandHandler
{
    private readonly ILogger _logger;

    private readonly TreeSettings _treeSettings;

    public DirectoryListHandler(ILogger logger, TreeSettings treeSettings)
    {
        _logger = logger;
        _treeSettings = treeSettings;
    }

    public override void Handle(string[] commandParts,  AbsoluteDirectory connectedFileSystem)
    {
        string command = commandParts[0] + " " + commandParts[1];
        if (command != "tree list")
        {
            base.Handle(commandParts, connectedFileSystem);
            return;
        }

        string depth;
        if (commandParts.Length <= 3)
        {
            depth = "1";
        }
        else
        {
            depth = commandParts[3];
        }

        var directoryLister = new DirectoryLister(_logger, _treeSettings, Directory.GetCurrentDirectory(), depth);
        directoryLister.Execute();
    }
}