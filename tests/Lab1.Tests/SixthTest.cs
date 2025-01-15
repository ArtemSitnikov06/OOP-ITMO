using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Xunit;

namespace Lab1.Tests;

public class SixthTest
{
    [Fact]
    public void Scenario6()
    {
        var sections = new List<IRouteSection>
        {
            new PowerPath(length: 100, force: 120),
            new NormalPath(length: 600),
            new PowerPath(length: 500, force: -30),
            new StationPath(maxSpeed: 10, boardingTime: 10),
            new NormalPath(length: 500),
            new PowerPath(length: 500, force: 1500),
            new NormalPath(length: 400),
            new PowerPath(length: 500, force: -600),
        };
        var train = new Train(mass: 10, mForce: 2000);
        var route = new FullPath(sections, maxSpeed: 100);

        IRouteResult check = route.Result(train, timelaps: 1);

        Assert.True(check.Success, check.GetResultMessage());
    }
}