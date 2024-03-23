using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;

public interface IConnectionModeFlagRepository
{
    public void Add(string flag, IFileSystem fileSystem);
    public IFileSystem GetFileSystem(string flag);
}