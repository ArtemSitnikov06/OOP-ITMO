using Itmo.ObjectOrientedProgramming.Lab4.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class PrintTreeVisitor : IVisitor
{
    private readonly ILogger _logger;

    private readonly TreeSettings _treeSettings;

    private readonly int _depth;

    private int _currentDepth = 0;

    public PrintTreeVisitor(ILogger logger, TreeSettings treeSettings, int depth)
    {
        _logger = logger;
        _treeSettings = treeSettings;
        _depth = depth;
    }

    public void VisitFile(FileElement element)
    {
        string indent = string.Concat(Enumerable.Repeat(_treeSettings.IndentSymbol, _currentDepth));
        _logger.Log($"{indent}{_treeSettings.FileSymbol} {Path.GetFileName(element.Path)}");
    }

    public void VisitDirectory(DirectoryElement element)
    {
        if (_currentDepth > _depth) return;

        foreach (string subDirectory in Directory.GetDirectories(element.Path))
        {
            string indent = string.Concat(Enumerable.Repeat(_treeSettings.IndentSymbol, _currentDepth));
            _logger.Log($"{indent}{_treeSettings.FolderSymbol}{Path.GetFileName(subDirectory)}");

            _currentDepth++;

            var subDirElement = new DirectoryElement(subDirectory);
            subDirElement.Accept(this);

            _currentDepth--;
        }

        foreach (string file in Directory.GetFiles(element.Path))
        {
            var fileElement = new FileElement(file);
            fileElement.Accept(this);
        }
    }
}