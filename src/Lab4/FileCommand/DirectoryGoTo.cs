using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class DirectoryGoTo : ICommand
{
    private readonly ILogger _logger;

    private readonly string _destination;

    public DirectoryGoTo(ILogger logger, string destination)
    {
        _logger = logger;
        _destination = destination;
    }

    public void Execute()
    {
        if (Directory.Exists(_destination))
        {
            Directory.SetCurrentDirectory(_destination);
            _logger.Log($"Current directory change on: {_destination}");
        }
        else
        {
            _logger.Log($"Directory {_destination} is not exist.");
        }
    }
}