using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LectureMaterialsBuilder
{
    private int _id;
    private string? _name;
    private string? _description;
    private string? _content;
    private User? _author;

    public LectureMaterialsBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public LectureMaterialsBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LectureMaterialsBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureMaterialsBuilder SetContent(string content)
    {
        _content = content;
        return this;
    }

    public LectureMaterialsBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public LectureMaterials Build()
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new InvalidOperationException("Lecture material name has not been set.");
        }

        if (string.IsNullOrEmpty(_content))
        {
            throw new InvalidOperationException("Content criteria have not been set.");
        }

        if (string.IsNullOrEmpty(_description))
        {
            throw new InvalidOperationException("Lecture material description has not been set.");
        }

        if (_author == null)
        {
            throw new InvalidOperationException("Author has not been set.");
        }

        return new LectureMaterials(_id, _name, _description, _content, _author);
    }
}