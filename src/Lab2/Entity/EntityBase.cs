namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public abstract class EntityBase
{
    public int Id { get; private set; }

    public User Author { get; }

    protected EntityBase(int id, User user)
    {
        Id = id;
        Author = user;
    }

    public bool IsAuthor(User user)
    {
        return Author.Id == user.Id;
    }
}