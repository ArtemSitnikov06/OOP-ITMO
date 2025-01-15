namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public interface IFileCommandHandler
{
    IFileCommandHandler SetNext(IFileCommandHandler handler);

    void Handle(string[] commandParts,  AbsoluteDirectory connectedFileSystem);
}