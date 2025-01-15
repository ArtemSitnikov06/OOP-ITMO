using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class CheckValidPoints
{
    public ICheckPointResult CheckPoints(IReadOnlyCollection<LaboratoryWork> labs)
    {
        int summ = 0;
        foreach (LaboratoryWork lab in labs)
        {
            summ += lab.Points;
        }

        if (summ == 100)
        {
            return new SuccesCheckPoints();
        }

        return new FailCheckPoints();
    }
}