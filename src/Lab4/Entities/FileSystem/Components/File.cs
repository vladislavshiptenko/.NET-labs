using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Traverse;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Components;

public class File : IFileSystemComponent
{
    public File(string name, string icon)
    {
        Name = name;
        Icon = icon;
    }

    public string Name { get; }
    public string Icon { get; }

    public void Accept(IFileSystemTraverse fileSystemTraverse)
    {
        if (fileSystemTraverse is null)
        {
            throw new ArgumentNullException(nameof(fileSystemTraverse));
        }

        if (fileSystemTraverse is ITraverse<File> fileTraverse)
        {
            fileTraverse.Traverse(this);
        }
        else
        {
            throw new InvalidFileSystemTraverseException(nameof(fileTraverse));
        }
    }
}