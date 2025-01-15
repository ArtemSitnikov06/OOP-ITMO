using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class FileMover : ICommand
{
    private readonly ILogger _logger;

    private readonly string _source;

    private string _destination;

    public FileMover(ILogger logger, string source, string destination)
    {
        _logger = logger;
        _source = source;
        _destination = destination;
    }

    public void Execute()
    {
        if (Directory.Exists(_destination))
        {
            string fileName = Path.GetFileName(_source);
            _destination = Path.Combine(_destination, fileName);
            File.Move(_source, _destination);
            _logger.Log($"File succesfully Moved to {_destination}");
        }
        else
        {
            _logger.Log($"{_destination} does not exist");
        }
    }
}