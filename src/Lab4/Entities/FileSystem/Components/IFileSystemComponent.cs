using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Traverse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Components;

public interface IFileSystemComponent
{
    string Name { get; }
    string Icon { get; }
    public void Accept(IFileSystemTraverse fileSystemTraverse);
}