namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public interface ICheckPointResult
{
    bool Succes { get; }

    string Message { get; }

    string GetResultMessage();
}