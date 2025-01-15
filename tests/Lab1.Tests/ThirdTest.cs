using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Xunit;

namespace Lab1.Tests;

public class ThirdTest
{
    [Fact]
    public void Scenario3()
    {
        var sections = new List<IRouteSection>
        {
            new PowerPath(length: 100, force: 100),
            new NormalPath(length: 50),
            new StationPath(maxSpeed: 500, boardingTime: 20),
            new NormalPath(length: 300),
        };
        var route = new FullPath(sections, maxSpeed: 100);
        var train = new Train(mass: 10, mForce: 200);
        IRouteResult check = route.Result(train, timelaps: 1);

        Assert.True(check.Success, check.GetResultMessage());
    }
}

