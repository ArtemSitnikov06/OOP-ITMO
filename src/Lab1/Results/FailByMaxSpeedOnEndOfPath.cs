namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public class FailByMaxSpeedOnEndOfPath : IRouteResult
{
    public bool Success { get; }

    public double Time { get; }

    public string Message { get; }

    public FailByMaxSpeedOnEndOfPath()
    {
        Success = false;
        Message = " Train dont pass the Route because his speed was bigger than available speed on end of path.";
        Time = default;
    }

    public string GetResultMessage()
    {
        return Message;
    }
}