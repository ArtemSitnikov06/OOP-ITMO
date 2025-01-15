using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class FileCopier : ICommand
{
    private readonly ILogger _logger;

    private readonly string _source;
    private string _destination;

    public FileCopier(ILogger logger, string source, string destination)
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
            File.Copy(_source, _destination);
            _logger.Log("Copied file to " + _destination);
        }
        else
        {
            _logger.Log("Source file does not exist");
        }
    }
}