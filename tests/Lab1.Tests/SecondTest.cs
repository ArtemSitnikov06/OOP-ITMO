using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Xunit;

namespace Lab1.Tests;

public class SecondTest
{
    [Fact]
    public void Scenario2()
    {
        var sections = new List<IRouteSection>
        {
            new PowerPath(length: 100, force: 1200),
            new NormalPath(length: 1000),
        };
        var train = new Train(mass: 10, mForce: 1300);
        var route = new FullPath(sections, maxSpeed: 100);

        IRouteResult check = route.Result(train, timelaps: 1);

        Assert.False(check.Success, check.GetResultMessage());
    }
}