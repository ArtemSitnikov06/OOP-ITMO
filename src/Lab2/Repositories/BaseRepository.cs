using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public abstract class BaseRepository<T> where T : EntityBase
{
    private readonly List<T> _repositoryEntity;

    protected BaseRepository()
    {
        _repositoryEntity = new List<T>();
    }

    public void Add(T entity)
    {
        _repositoryEntity.Add(entity);
    }

    public T? FindEntity(int id)
    {
        foreach (T entity in _repositoryEntity)
        {
            if (id == entity.Id)
            {
                return entity;
            }
        }

        return null;
    }
}