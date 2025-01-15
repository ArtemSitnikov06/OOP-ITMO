using Itmo.ObjectOrientedProgramming.Lab4.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCommand;

public class DirectoryLister : ICommand
{
    private readonly ILogger _logger;

    private readonly TreeSettings _treeSettings;

    private readonly string _depth;

    private readonly string _source;

    public DirectoryLister(ILogger logger, TreeSettings treeSettings, string source, string depth)
    {
        _logger = logger;
        _treeSettings = treeSettings;
        _source = source;
        _depth = depth;
    }

    public void Execute()
    {
        bool check = int.TryParse(_depth, out int depth);
        if (check)
        {
            var visitor = new PrintTreeVisitor(_logger, _treeSettings, depth);
            var rootDirectory = new DirectoryElement(_source);
            rootDirectory.Accept(visitor);
        }
        else
        {
            _logger.Log("Depth must be equal integer");
        }
    }
}