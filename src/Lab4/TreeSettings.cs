using Itmo.ObjectOrientedProgramming.Lab4.CommandReader;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class TreeSettings
{
    private readonly ICommandReader _reader;

    private readonly ILogger _logger;

    public string FileSymbol { get; set; } = "*";

    public string FolderSymbol { get; set; } = "+";

    public string IndentSymbol { get; set; } = "-";

    public TreeSettings(ICommandReader reader, ILogger logger)
    {
        _reader = reader;
        _logger = logger;
    }

    public void SetSettings()
    {
        _logger.Log("Enter symbol for files");
        FileSymbol = _reader.ReadCommand();

        _logger.Log("Enter symbol for folders");
        FolderSymbol = _reader.ReadCommand();

        _logger.Log("Enter symbol for indents");
        IndentSymbol = _reader.ReadCommand();
    }
}