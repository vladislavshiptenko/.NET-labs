using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Traverse;

public interface ITraverse<in T> : IFileSystemTraverse
    where T : IFileSystemComponent
{
    public void Traverse(T component);
}