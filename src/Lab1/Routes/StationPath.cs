using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class StationPath : IRouteSection
{
    private readonly double _maxSpeed;

    private readonly double _boardingTime;

    public StationPath(double maxSpeed, double boardingTime)
    {
        if (maxSpeed < 1)
        {
            throw new ArgumentException("maxSpeed on station must be greater than 0", nameof(maxSpeed));
        }

        if (boardingTime < 0)
        {
            throw new ArgumentException("boardingTime must be greater than 0 or equal", nameof(boardingTime));
        }

        _maxSpeed = maxSpeed;
        _boardingTime = boardingTime;
    }

    public IRouteResult Pass(Train train, double timelaps)
    {
        if (train.Speed > _maxSpeed)
        {
            return new FailByMaxSpeedOnStationPath();
        }

        return new SuccesResult(_boardingTime);
    }
}