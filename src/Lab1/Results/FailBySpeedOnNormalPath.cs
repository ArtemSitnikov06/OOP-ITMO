namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public class FailBySpeedOnNormalPath : IRouteResult
{
    public bool Success { get; }

    public double Time { get; }

    public string Message { get; }

    public FailBySpeedOnNormalPath()
    {
        Success = false;
        Time = default;
        Message = " Train dont Pass the Route because his speed and acceletration was 0 on Normal Path";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}
