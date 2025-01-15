using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Update;

public class UpdateLaboratoryWork : IUpdate
{
    private readonly LaboratoryWork _laboratoryWork;

    public UpdateLaboratoryWork(LaboratoryWork laboratoryWork)
    {
        _laboratoryWork = laboratoryWork;
    }

    public IChangeResult CanUpdate(User user)
    {
        if (!_laboratoryWork.IsAuthor(user))
        {
            return new FailChangeLabAuthor();
        }

        return new SuccesChangeByAuthor();
    }

    public void UpdateName(string newName, IChangeResult check)
    {
        if (check.IsValid)
        {
            _laboratoryWork.Name = newName;
        }
    }

    public void UpdateDescription(string newDescription, IChangeResult check)
    {
        if (check.IsValid)
        {
            _laboratoryWork.Description = newDescription;
        }
    }

    public void UpdatePointsCriteria(string newPointsCriteria, IChangeResult check)
    {
        _laboratoryWork.PointsCriteria = newPointsCriteria;
    }

    public void UpdatePoints(int newPoints)
    {
        _laboratoryWork.Points = newPoints;
    }
}