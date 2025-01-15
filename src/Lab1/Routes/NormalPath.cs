using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class NormalPath : IRouteSection
{
    private readonly double _length;

    public NormalPath(double length)
    {
        if (length < 0)
        {
            throw new ArgumentException("Length must be greater than or equal to 0.", nameof(length));
        }

        _length = length;
    }

    public IRouteResult Pass(Train train, double timelaps)
    {
        CalculateTimeResult result = train.CalculateSegmentTime(timelaps, _length);

        if (result.Status == StatusOfTimeCalculation.SpeedAndAccelerationEqualZero)
        {
            return new FailBySpeedOnNormalPath();
        }

        return new SuccesResult(result.Time);
    }
}