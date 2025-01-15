using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class FullPath
{
    private readonly IEnumerable<IRouteSection> _sections;

    private readonly double _maxSpeed;

    public FullPath(IEnumerable<IRouteSection> sections, double maxSpeed)
    {
        if (maxSpeed < 1)
        {
            throw new ArgumentException("MaxSpeed on end of path must be greater than 0.", nameof(maxSpeed));
        }

        _sections = sections;
        _maxSpeed = maxSpeed;
    }

    public IRouteResult Result(Train train, double timelaps)
    {
        if (timelaps <= 0)
        {
            throw new ArgumentException("Timelaps must be greater than zero.", nameof(timelaps));
        }

        double totalTime = 0;
        foreach (IRouteSection section in _sections)
        {
            IRouteResult result = section.Pass(train, timelaps);
            if (!result.Success)
            {
                return result;
            }

            totalTime += result.Time;
        }

        return train.Speed <= _maxSpeed ? new SuccesResult(totalTime) : new FailByMaxSpeedOnEndOfPath();
    }
}