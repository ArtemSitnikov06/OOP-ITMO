using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Elements;

public interface IElement
{
    void Accept(IVisitor visitor);
}