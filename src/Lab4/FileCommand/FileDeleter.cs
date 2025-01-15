using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class FileDeleter : ICommand
{
    private readonly ILogger _logger;

    private readonly string _source;

    public FileDeleter(ILogger logger, string source)
    {
        _logger = logger;
        _source = source;
    }

    public void Execute()
    {
        if (File.Exists(_source))
        {
            File.Delete(_source);
            _logger.Log("Deleted file:" + _source);
        }
        else
        {
            _logger.Log("Source file does not exist:" + _source);
        }
    }
}