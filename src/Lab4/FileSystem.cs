using Itmo.ObjectOrientedProgramming.Lab4.CommandReader;
using Itmo.ObjectOrientedProgramming.Lab4.FileHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileSystem
{
    private readonly ICommandReader _reader;

    private readonly ILogger _logger;

    private readonly IFileCommandHandler _commandHandler;

    private readonly AbsoluteDirectory _fileSystemConnect;

    private readonly TreeSettings _treeSettings;

    public FileSystem(ICommandReader reader, ILogger logger, AbsoluteDirectory fileConnect, TreeSettings treeSettings)
    {
        _reader = reader;
        _logger = logger;
        _fileSystemConnect = fileConnect;
        _treeSettings = treeSettings;
        _commandHandler = new FileDisconectorHandle(_logger)
            .SetNext(new FileCopierHandler(_logger))
            .SetNext(new FileDeleteHandler(_logger))
            .SetNext(new FileMovierHandler(_logger))
            .SetNext(new FileReaderHandler(_logger))
            .SetNext(new FileRenamerHandler(_logger))
            .SetNext(new DirectoryGoToHandler(_logger))
            .SetNext(new DirectoryListHandler(_logger, _treeSettings))
            .SetNext(new FileConnectorHadnler(_logger));
    }

    public void ProccessComand()
    {
        _treeSettings.SetSettings();
        do
        {
            string commandLine = _reader.ReadCommand();

            string[] commandParts = commandLine.Split(" ");

            _commandHandler.Handle(commandParts, _fileSystemConnect);
        }
        while (_fileSystemConnect.BaseDirectory != null);
    }
}