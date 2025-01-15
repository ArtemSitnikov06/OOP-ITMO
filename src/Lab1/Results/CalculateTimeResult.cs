namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public struct CalculateTimeResult
{
    public double Time { get; }

    public StatusOfTimeCalculation Status { get; }

    public CalculateTimeResult(double time, StatusOfTimeCalculation status)
    {
        Time = time;
        Status = status;
    }
}