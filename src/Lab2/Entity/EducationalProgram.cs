namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class EducationalProgram : EntityBase
{
    public string Name { get; private set; }

    private readonly Dictionary<int, List<Subject>> _subjectsBySemester;

    public EducationalProgram(int id, string name, User manager) : base(id, manager)
    {
        Name = name;
        _subjectsBySemester = new Dictionary<int, List<Subject>>();
    }

    public void AddSubjectToSemester(int semester, Subject subject)
    {
        if (!_subjectsBySemester.ContainsKey(semester))
        {
            _subjectsBySemester[semester] = new List<Subject>();
        }

        _subjectsBySemester[semester].Add(subject);
    }
}