using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

public class FileMoveCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public void WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
    }

    public void WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
    }

    public ICommand Build()
    {
        if (_sourcePath is null)
        {
            throw new NullBuilderFieldException(nameof(_sourcePath));
        }

        if (_destinationPath is null)
        {
            throw new NullBuilderFieldException(nameof(_destinationPath));
        }

        return new FileMoveCommand(_sourcePath, _destinationPath);
    }
}