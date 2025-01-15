using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Elements;

public class DirectoryElement : IElement
{
    public string Path { get;  }

    public DirectoryElement(string path)
    {
        Path = path;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitDirectory(this);
    }
}