namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public interface IRouteResult
{
    bool Success { get; }

    double Time { get;  }

    string Message { get; }

    string GetResultMessage();
}