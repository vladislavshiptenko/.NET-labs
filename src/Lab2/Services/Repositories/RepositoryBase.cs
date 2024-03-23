using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public abstract class RepositoryBase<T> : IRepository<T>
    where T : IComponent
{
    private IList<T> _componentList = new List<T>();

    public T? GetByName(string? name)
    {
        return _componentList.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void Add(T component)
    {
        _componentList.Add(component);
    }

    public void Delete(T component)
    {
        bool deleted = _componentList.Remove(component);
        if (!deleted)
        {
            throw new RepositoryFindException(nameof(component));
        }
    }

    public void Update(T oldComponent, T newComponent)
    {
        int oldComponentIndex = _componentList.IndexOf(oldComponent);
        if (oldComponentIndex == -1)
        {
            throw new RepositoryFindException(nameof(oldComponent));
        }

        _componentList[oldComponentIndex] = newComponent;
    }
}