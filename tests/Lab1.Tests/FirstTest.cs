using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Xunit;

namespace Lab1.Tests;

public class FirstTest
{
    [Fact]
    public void Scenario1()
    {
        var sections = new List<IRouteSection>
        {
            new PowerPath(length: 100, force: 120),
            new NormalPath(length: 1000),
        };
        var train = new Train(mass: 10, mForce: 1000);
        var route = new FullPath(sections, maxSpeed: 10000);

        IRouteResult check = route.Result(train, timelaps: 1);

        Assert.True(check.Success, check.GetResultMessage());
    }
}