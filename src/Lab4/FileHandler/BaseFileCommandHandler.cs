namespace Itmo.ObjectOrientedProgramming.Lab4.FileHandler;

public class BaseFileCommandHandler : IFileCommandHandler
{
    private IFileCommandHandler? _nextCommandHandler;

    public IFileCommandHandler SetNext(IFileCommandHandler handler)
    {
        if (_nextCommandHandler is null)
        {
            _nextCommandHandler = handler;
        }
        else
        {
            _nextCommandHandler.SetNext(handler);
        }

        return this;
    }

    public virtual void Handle(string[] commandParts, AbsoluteDirectory connectedFileSystem)
    {
        _nextCommandHandler?.Handle(commandParts, connectedFileSystem);
    }
}