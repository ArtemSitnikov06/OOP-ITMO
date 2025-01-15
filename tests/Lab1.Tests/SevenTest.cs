using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Xunit;

namespace Lab1.Tests;

public class SevenTest
{
    [Fact]
    public void Scenario7()
    {
        var sections = new List<IRouteSection>
        {
            new NormalPath(length: 600),
        };
        var train = new Train(mass: 10, mForce: 20);
        var route = new FullPath(sections, maxSpeed: 100);

        IRouteResult check = route.Result(train, timelaps: 1);

        Assert.False(check.Success, check.GetResultMessage());
    }
}