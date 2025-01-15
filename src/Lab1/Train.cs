using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    private readonly double _maxForce;

    private readonly double _mass;

    private double _acceleration;

    public double Speed { get; private set;  }

    public Train(double mass, double mForce)
    {
        if (mass <= 0)
        {
            throw new ArgumentException("mass must be greater than 0", nameof(mass));
        }

        _mass = mass;
        _maxForce = mForce;
        Speed = 0;
        _acceleration = 0;
    }

    public CalculateTimeResult CalculateSegmentTime(double timelaps, double distance)
    {
        if (Speed == 0 && _acceleration == 0)
        {
            return new CalculateTimeResult(0, StatusOfTimeCalculation.SpeedAndAccelerationEqualZero);
        }

        double totalTime = 0;
        double passedDistance = 0;
        double resultSpeed = 0;
        while (distance > 0)
        {
            resultSpeed = Speed + (_acceleration * timelaps);
            if (resultSpeed <= 0)
            {
                return new CalculateTimeResult(0, StatusOfTimeCalculation.SpeedLessZero);
            }

            passedDistance = resultSpeed * timelaps;
            distance -= passedDistance;
            totalTime += timelaps;
        }

        Speed = resultSpeed;

        return new CalculateTimeResult(totalTime, StatusOfTimeCalculation.Succes);
    }

    public bool ApplicatioForce(double force)
    {
        if (force <= _maxForce)
        {
            _acceleration = force / _mass;
            return true;
        }

        return false;
    }

    public void ResetAcceleration()
    {
        _acceleration = 0;
    }
}