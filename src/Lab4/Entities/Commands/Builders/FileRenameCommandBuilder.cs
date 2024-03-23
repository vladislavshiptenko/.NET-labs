using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

public class FileRenameCommandBuilder : ICommandBuilder
{
    private string? _path;
    private string? _name;

    public void WithPath(string path)
    {
        _path = path;
    }

    public void WithName(string name)
    {
        _name = name;
    }

    public ICommand Build()
    {
        if (_path is null)
        {
            throw new NullBuilderFieldException(nameof(_path));
        }

        if (_name is null)
        {
            throw new NullBuilderFieldException(nameof(_name));
        }

        return new FileRenameCommand(_path, _name);
    }
}