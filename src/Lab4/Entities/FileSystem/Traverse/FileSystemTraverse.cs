using System;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Traverse;

public class FileSystemTraverse : ITraverse<File>, ITraverse<Folder>
{
    private readonly string _padding;
    private readonly StringBuilder _stringBuilder;
    private int _depth;

    public FileSystemTraverse(int depth, string padding, StringBuilder stringBuilder)
    {
        _depth = depth;
        _padding = padding;
        _stringBuilder = stringBuilder;
    }

    public string Result => _stringBuilder.ToString();

    public void Traverse(Folder component)
    {
        if (component is null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        string padding = string.Concat(Enumerable.Repeat(_padding, _depth));
        _stringBuilder.Append(padding);
        _stringBuilder.Append(component.Icon);
        _stringBuilder.Append(component.Name);
        _stringBuilder.Append('\n');

        _depth += 1;

        foreach (IFileSystemComponent fileSystemComponent in component.Components)
        {
            fileSystemComponent.Accept(this);
        }

        _depth -= 1;
    }

    public void Traverse(File component)
    {
        if (component is null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        string padding = string.Concat(Enumerable.Repeat(_padding, _depth));
        _stringBuilder.Append(padding);
        _stringBuilder.Append(component.Icon);
        _stringBuilder.Append(component.Name);
        _stringBuilder.Append('\n');
    }
}