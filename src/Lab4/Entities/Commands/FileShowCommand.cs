using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileShowCommand : ICommand
{
    public FileShowCommand(string path, IWriter writer)
    {
        Path = path;
        Writer = writer;
    }

    public string Path { get; }
    public IWriter Writer { get; }

    public Output Execute(IContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        try
        {
            string textOutput = context.FileShow(Path, Writer);
            return new Output(textOutput, true);
        }
        catch (CommandExecuteException)
        {
            return new Output(string.Empty, false);
        }
    }
}