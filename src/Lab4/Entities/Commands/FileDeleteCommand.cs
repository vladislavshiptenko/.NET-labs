using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileDeleteCommand : ICommand
{
    public FileDeleteCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public Output Execute(IContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        try
        {
            context.FileDelete(Path);
            return new Output(string.Empty, true);
        }
        catch (CommandExecuteException)
        {
            return new Output(string.Empty, false);
        }
    }
}