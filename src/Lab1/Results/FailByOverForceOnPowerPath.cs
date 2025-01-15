namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public class FailByOverForceOnPowerPath : IRouteResult
{
    public bool Success { get;  }

    public double Time { get;  }

    public string Message { get; }

    public FailByOverForceOnPowerPath()
    {
        Success = false;
        Time = default;
        Message = " Train dont Pass the Route because force on PowerPath was bigger then available train force";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}