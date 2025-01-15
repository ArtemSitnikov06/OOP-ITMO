using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class FileDisconector : ICommand
{
    private readonly ILogger _logger;

    public AbsoluteDirectory FileSystemConnect { get; private set; }

    public FileDisconector(ILogger logger, AbsoluteDirectory fileStream)
    {
        _logger = logger;
        FileSystemConnect = fileStream;
    }

    public bool IsSuccess { get; private set; }

    public void Execute()
    {
        if (FileSystemConnect.BaseDirectory != null)
        {
            _logger.Log($"successfully disconnected from {FileSystemConnect.BaseDirectory}.");
            FileSystemConnect.BaseDirectory = null;

            IsSuccess = true;
        }
        else
        {
            _logger.Log("No connected to disconnect.");
        }
    }
}