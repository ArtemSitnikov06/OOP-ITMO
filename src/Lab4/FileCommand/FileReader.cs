using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class FileReader : ICommand
{
    private readonly ILogger _logger;

    private readonly string _source;

    public FileReader(ILogger logger, string source)
    {
        _logger = logger;
        _source = source;
    }

    public void Execute()
    {
        if (File.Exists(_source))
        {
            string content = File.ReadAllText(_source);
            _logger.Log(content);
        }
        else
        {
            _logger.Log($"File {_source} does not exist");
        }
    }
}