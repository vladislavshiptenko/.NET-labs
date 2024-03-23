using Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

public class FileShowCommandBuilder : ICommandBuilder
{
    private string? _path;
    private IWriter? _logger;

    public void WithPath(string path)
    {
        _path = path;
    }

    public void WithLogger(IWriter writer)
    {
        _logger = writer;
    }

    public ICommand Build()
    {
        if (_path is null)
        {
            throw new NullBuilderFieldException(nameof(_path));
        }

        if (_logger is null)
        {
            throw new NullBuilderFieldException(nameof(_logger));
        }

        return new FileShowCommand(_path, _logger);
    }
}