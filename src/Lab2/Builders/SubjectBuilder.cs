using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectBuilder
{
    private int _id;
    private string? _name;
    private User? _author;
    private IReadOnlyCollection<LaboratoryWork>? _laboratoryWorks;
    private IReadOnlyCollection<LectureMaterials>? _lectureMaterials;
    private GradingFormat _gradingFormat;
    private PointType _points;

    public SubjectBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public SubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public SubjectBuilder SetLabWorks(IReadOnlyCollection<LaboratoryWork> laboratoryWorks)
    {
        _laboratoryWorks = laboratoryWorks;
        return this;
    }

    public SubjectBuilder SetLectureMaterials(IReadOnlyCollection<LectureMaterials> materials)
    {
        _lectureMaterials = materials;
        return this;
    }

    public SubjectBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public SubjectBuilder SetTypeExam()
    {
        _gradingFormat = GradingFormat.Exam;
        return this;
    }

    public SubjectBuilder SetTypePassFail()
    {
        _gradingFormat = GradingFormat.PassFail;
        return this;
    }

    public SubjectBuilder SetExamPoints(int points)
    {
        if (_gradingFormat != GradingFormat.Exam)
        {
            throw new ArgumentException("Grading format must be Exam");
        }

        _points.ExamPoints = points;
        return this;
    }

    public SubjectBuilder SetPassFailPoints(int passFailPoints)
    {
        if (_gradingFormat != GradingFormat.PassFail)
        {
            throw new ArgumentException("Grading format must be PassFail");
        }

        _points.PassFailPoints = passFailPoints;
        return this;
    }

    public Subject Build()
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new InvalidOperationException("Subject name has not been set.");
        }

        if (_laboratoryWorks == null)
        {
            throw new InvalidOperationException("Laboratory works have not been set.");
        }

        if (_lectureMaterials == null)
        {
            throw new InvalidOperationException("Lecture Materials have not been set.");
        }

        if (_author == null)
        {
            throw new InvalidOperationException("Author has not been set.");
        }

        return new Subject(_id, _name, _author, _laboratoryWorks, _lectureMaterials, _gradingFormat, _points);
    }
}