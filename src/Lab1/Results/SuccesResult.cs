namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public struct SuccesResult : IRouteResult
{
    public bool Success { get; }

    public double Time { get; }

    public string Message { get; }

    public SuccesResult(double time)
    {
        Success = true;
        Time = time;
        Message = "Route is Succesfully pass";
    }

    public string GetResultMessage()
    {
        return $"{Message} : {Time} ";
    }
}