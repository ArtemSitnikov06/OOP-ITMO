using Itmo.ObjectOrientedProgramming.Lab4.Elements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IVisitor
{
    void VisitFile(FileElement element);

    void VisitDirectory(DirectoryElement element);
}