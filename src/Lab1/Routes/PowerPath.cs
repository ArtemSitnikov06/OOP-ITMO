using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class PowerPath : IRouteSection
{
    private readonly double _length;

    private readonly double _force;

    public PowerPath(double length, double force)
    {
        if (length < 0)
        {
            throw new ArgumentException("Length must be greater than or equal to 0.", nameof(length));
        }

        _force = force;
        _length = length;
    }

    public IRouteResult Pass(Train train, double timelaps)
    {
        bool appliedForce = train.ApplicatioForce(_force);
        if (!appliedForce)
        {
            return new FailByOverForceOnPowerPath();
        }

        CalculateTimeResult result = train.CalculateSegmentTime(timelaps, _length);

        if (result.Status == StatusOfTimeCalculation.SpeedLessZero)
        {
            return new FailBySpeedLessZero();
        }

        if (result.Status == StatusOfTimeCalculation.SpeedAndAccelerationEqualZero)
        {
            return new FailBySpeedOnNormalPath();
        }

        train.ResetAcceleration();

        return new SuccesResult(result.Time);
    }
}