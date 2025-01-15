namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class LaboratoryWork : EntityBase, IPrototype<LaboratoryWork>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string PointsCriteria { get; set; }

    public int Points { get; set; }

    public int? BaseLabWorkID { get; private set; }

    public LaboratoryWork(int id, string name, string description, string pointsCriteria, int points, User author, int? baseLabWorkID = null)
        : base(id, author)
    {
        Name = name;
        Description = description;
        PointsCriteria = pointsCriteria;
        Points = points;
        BaseLabWorkID = baseLabWorkID;
    }

    public LaboratoryWork Clone()
    {
        return new LaboratoryWork(Id + 1, Name, Description, PointsCriteria, Points, Author, Id);
    }
}