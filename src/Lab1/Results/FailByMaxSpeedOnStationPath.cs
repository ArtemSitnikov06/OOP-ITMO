namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public class FailByMaxSpeedOnStationPath : IRouteResult
{
    public bool Success { get; }

    public double Time { get; }

    public string Message { get; }

    public FailByMaxSpeedOnStationPath()
    {
        Success = false;
        Time = default;
        Message = " Train dont pass the Route because his Speed was bigger than available speed on station.";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}