using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LaboratoryWorkBuilder
{
    private int _id;
    private string? _name;
    private string? _description;
    private string? _pointCriteria;
    private int _points;
    private User? _author;

    public LaboratoryWorkBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public LaboratoryWorkBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LaboratoryWorkBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LaboratoryWorkBuilder SetPointCriteria(string pointCriteria)
    {
        _pointCriteria = pointCriteria;
        return this;
    }

    public LaboratoryWorkBuilder SetPoints(int points)
    {
        _points = points;
        return this;
    }

    public LaboratoryWorkBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public LaboratoryWork Build()
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new InvalidOperationException("Lab work name has not been set.");
        }

        if (string.IsNullOrEmpty(_pointCriteria))
        {
            throw new InvalidOperationException("Point criteria have not been set.");
        }

        if (string.IsNullOrEmpty(_description))
        {
            throw new InvalidOperationException("Lab work description has not been set.");
        }

        if (_author == null)
        {
            throw new InvalidOperationException("Author has not been set.");
        }

        return new LaboratoryWork(_id, _name, _description, _pointCriteria, _points, _author);
    }
}