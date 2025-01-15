namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class Subject : EntityBase, IPrototype<Subject>
{
    public string Name { get; set; }

    public GradingFormat AssessmentType { get;  set; }

    public PointType Points { get; }

    public IReadOnlyCollection<LaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<LectureMaterials> LectureMaterials { get; set; }

    public int? BaseSubjectId { get; private set; }

    public Subject(
        int id,
        string name,
        User author,
        IReadOnlyCollection<LaboratoryWork> labWorks,
        IReadOnlyCollection<LectureMaterials> lectureMaterials,
        GradingFormat assessmentType,
        PointType points,
        int? baseSubjectId = null)
    : base(id, author)
    {
        Name = name;
        LaboratoryWorks = labWorks;
        LectureMaterials = lectureMaterials;
        AssessmentType = assessmentType;
        Points = points;
        BaseSubjectId = baseSubjectId;
    }

    public Subject Clone()
    {
        return new Subject(Id + 1, Name, Author, LaboratoryWorks, LectureMaterials,  AssessmentType, Points, Id);
    }
}