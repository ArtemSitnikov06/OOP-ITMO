namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class LectureMaterials : EntityBase, IPrototype<LectureMaterials>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Content { get; set; }

    public int? BaseLectureMaterialId { get; private set; }

    public LectureMaterials(int id, string name, string summary, string content, User author, int? baseLectureMaterialId = null)
    : base(id, author)
    {
        Name = name;
        Description = summary;
        Content = content;
        BaseLectureMaterialId = baseLectureMaterialId;
    }

    public LectureMaterials Clone()
    {
        return new LectureMaterials(Id + 1, Name, Description, Content, Author, Id);
    }
}