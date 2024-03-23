using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

public class FileDeleteCommandBuilder : ICommandBuilder
{
    private string? _path;

    public void WithPath(string path)
    {
        _path = path;
    }

    public ICommand Build()
    {
        if (_path is null)
        {
            throw new NullBuilderFieldException(nameof(_path));
        }

        return new FileDeleteCommand(_path);
    }
}