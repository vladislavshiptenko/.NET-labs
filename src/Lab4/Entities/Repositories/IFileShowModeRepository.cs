using Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;

public interface IFileShowModeRepository
{
    public void Add(string flag, IWriter writer);
    public IWriter GetLogger(string flag);
}