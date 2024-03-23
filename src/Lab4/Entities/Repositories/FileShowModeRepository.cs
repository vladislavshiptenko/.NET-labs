using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;

public class FileShowModeRepository : IFileShowModeRepository
{
    private readonly IDictionary<string, IWriter> _dictionary;

    public FileShowModeRepository(IDictionary<string, IWriter> dictionary)
    {
        _dictionary = dictionary;
    }

    public void Add(string flag, IWriter writer)
    {
        _dictionary.Add(flag, writer);
    }

    public IWriter GetLogger(string flag)
    {
        return _dictionary[flag];
    }
}