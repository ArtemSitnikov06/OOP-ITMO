using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Update;

public class UpdateLectureMaterials : IUpdate
{
    private readonly LectureMaterials _lectureMaterials;

    public UpdateLectureMaterials(LectureMaterials lectureMaterials)
    {
        _lectureMaterials = lectureMaterials;
    }

    public IChangeResult CanUpdate(User user)
    {
        if (!_lectureMaterials.IsAuthor(user))
        {
            return new FailChangeMaterialAuthor();
        }

        return new SuccesChangeByAuthor();
    }

    public void UpdateName(string newName, IChangeResult check)
    {
        if (check.IsValid)
        {
            _lectureMaterials.Name = newName;
        }
    }

    public void UpdateDescription(string newDescription, IChangeResult check)
    {
        if (check.IsValid)
        {
            _lectureMaterials.Description = newDescription;
        }
    }

    public void UpdateContent(string newContent, IChangeResult check)
    {
        if (check.IsValid)
        {
            _lectureMaterials.Content = newContent;
        }
    }
}