namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public class FailBySpeedLessZero : IRouteResult
{
    public bool Success { get; }

    public double Time { get; }

    public string Message { get; }

    public FailBySpeedLessZero()
    {
        Success = false;
        Message = " Train dont pass the Route because his speed became less than zero.";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}