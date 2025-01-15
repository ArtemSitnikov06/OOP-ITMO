using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Update;

public class UpdateSubject : IUpdate
{
    private readonly Subject _subject;

    private readonly List<LectureMaterials> _materials;

    public UpdateSubject(Subject subject)
    {
        _subject = subject;

        _materials = new List<LectureMaterials>(_subject.LectureMaterials);
    }

    public IChangeResult CanUpdate(User user)
    {
        if (!_subject.IsAuthor(user))
        {
            return new FailChangeSubjectAuthor();
        }

        return new SuccesChangeByAuthor();
    }

    public void UpdateName(string name, IChangeResult check)
    {
        if (check.IsValid)
        {
            _subject.Name = name;
        }
    }

    public void AddLecureMaterials(LectureMaterials material, IChangeResult check)
    {
        if (check.IsValid)
        {
            _materials.Add(material);
            _subject.LectureMaterials = _materials.AsReadOnly();
        }
    }

    public void ChangeGradingFormatToExam(IChangeResult check)
    {
        if (check.IsValid)
        {
            _subject.AssessmentType = GradingFormat.Exam;
        }
    }

    public void ChangeGradingFormatToPassFail(IChangeResult check)
    {
        if (check.IsValid)
        {
            _subject.AssessmentType = GradingFormat.PassFail;
        }
    }
}