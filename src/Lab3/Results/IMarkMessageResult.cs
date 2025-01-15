namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public interface IMarkMessageResult
{
    bool Succes { get; }

    string Message { get; }

    string GetResultMessage();
}