using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;

public class ConnectionModeFlagRepository : IConnectionModeFlagRepository
{
    private readonly IDictionary<string, IFileSystem> _dictionary;

    public ConnectionModeFlagRepository(IDictionary<string, IFileSystem> dictionary)
    {
        _dictionary = dictionary;
    }

    public void Add(string flag, IFileSystem fileSystem)
    {
        _dictionary.Add(flag, fileSystem);
    }

    public IFileSystem GetFileSystem(string flag)
    {
        return _dictionary[flag];
    }
}