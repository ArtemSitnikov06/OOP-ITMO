using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class FileRenamer : ICommand
{
    private readonly ILogger _logger;

    private readonly string _source;

    private readonly string _newName;

    public FileRenamer(ILogger logger, string source, string newName)
    {
        _logger = logger;
        _source = source;
        _newName = newName;
    }

    public void Execute()
    {
        if (File.Exists(_source))
        {
            string? directoryPath = Path.GetDirectoryName(_source);
            string fileExtension = Path.GetExtension(_source);
            if (directoryPath != null)
            {
                string newFilePath = Path.Combine(directoryPath, _newName + fileExtension);

                File.Move(_source, newFilePath);
                _logger.Log($"File at {_source} renamed to {newFilePath}.");
            }
        }
        else
        {
            _logger.Log($"File {_source} does not exist.");
        }
    }
}