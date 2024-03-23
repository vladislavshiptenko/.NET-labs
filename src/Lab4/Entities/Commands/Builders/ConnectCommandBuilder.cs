using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

public class ConnectCommandBuilder : ICommandBuilder
{
    private string? _address;
    private IFileSystem? _fileSystem;

    public void WithAddress(string address)
    {
        _address = address;
    }

    public void WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public ICommand Build()
    {
        if (_address is null)
        {
            throw new NullBuilderFieldException(nameof(_address));
        }

        if (_fileSystem is null)
        {
            throw new NullBuilderFieldException(nameof(_fileSystem));
        }

        return new ConnectCommand(_address, _fileSystem);
    }
}