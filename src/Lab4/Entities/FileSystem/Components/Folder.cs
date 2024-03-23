using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Traverse;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Components;

public class Folder : IFileSystemComponent
{
    public Folder(IList<IFileSystemComponent> components, string name, string icon)
    {
        Components = components;
        Name = name;
        Icon = icon;
    }

    public string Name { get; }
    public string Icon { get; }

    public IList<IFileSystemComponent> Components { get; }

    public void AddComponent(IFileSystemComponent component)
    {
        if (component is null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        Components.Add(component);
    }

    public void Accept(IFileSystemTraverse fileSystemTraverse)
    {
        if (fileSystemTraverse is null)
        {
            throw new ArgumentNullException(nameof(fileSystemTraverse));
        }

        if (fileSystemTraverse is ITraverse<Folder> folderTraverse)
        {
            folderTraverse.Traverse(this);
        }
        else
        {
            throw new InvalidFileSystemTraverseException(nameof(folderTraverse));
        }
    }
}