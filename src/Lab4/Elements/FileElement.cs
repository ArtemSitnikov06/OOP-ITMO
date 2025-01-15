using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Elements;

public class FileElement : IElement
{
   public string Path { get; }

   public FileElement(string path)
    {
        Path = path;
    }

   public void Accept(IVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}