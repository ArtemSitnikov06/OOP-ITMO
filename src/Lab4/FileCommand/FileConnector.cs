using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class FileConnector : ICommand
{
    private readonly ILogger _logger;

    private readonly AbsoluteDirectory _directory;

    private readonly string _source;

    public FileConnector(ILogger logger, AbsoluteDirectory directory, string source)
    {
        _logger = logger;
        _directory = directory;
        _source = source;
    }

    public bool IsSuccesConnect { get; private set; }

    public void Execute()
    {
        IsSuccesConnect = false;

        _directory.BaseDirectory = _source;

        if (Directory.Exists(_source))
        {
            Directory.SetCurrentDirectory(_directory.BaseDirectory);
            IsSuccesConnect = true;
            _logger.Log($"Succesful connected to {_source}");
        }
        else
        {
            _logger.Log($"{_source} not found");
        }
    }
}