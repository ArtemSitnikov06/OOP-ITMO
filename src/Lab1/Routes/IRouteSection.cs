using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public interface IRouteSection
{
    public IRouteResult Pass(Train train, double timelaps);
}