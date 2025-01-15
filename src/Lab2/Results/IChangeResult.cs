namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public interface IChangeResult
{
    bool IsValid { get; }

    string Message { get; }

    string GetResultMessage();
}