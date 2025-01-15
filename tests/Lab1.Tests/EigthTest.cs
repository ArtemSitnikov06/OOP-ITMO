using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;

using Xunit;

namespace Lab1.Tests;

public class EigthTest
{
    [Fact]
    public void Scenario8()
    {
        var sections = new List<IRouteSection>
        {
            new PowerPath(length: 600, force: 100),
            new PowerPath(length: 600, force: -200),
        };
        var train = new Train(mass: 10, mForce: 200);
        var route = new FullPath(sections, maxSpeed: 100);

        IRouteResult check = route.Result(train, timelaps: 1);

        Assert.False(check.Success, check.GetResultMessage());
    }
}