using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Xunit;

namespace Lab1.Tests;

public class FourthTest
{
    [Fact]
    public void Scenario4()
    {
        var sections = new List<IRouteSection>
        {
            new PowerPath(length: 100, force: 120),
            new StationPath(maxSpeed: 10, boardingTime: 10),
            new NormalPath(length: 500),
        };
        var train = new Train(mass: 10, mForce: 1000);
        var route = new FullPath(sections, maxSpeed: 10000);

        IRouteResult check = route.Result(train, timelaps: 1);

        Assert.False(check.Success, check.GetResultMessage());
    }
}