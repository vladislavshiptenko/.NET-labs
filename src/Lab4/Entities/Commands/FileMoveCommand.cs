using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileMoveCommand : ICommand
{
    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }

    public Output Execute(IContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        try
        {
            context.FileMove(SourcePath, DestinationPath);
            return new Output(string.Empty, true);
        }
        catch (CommandExecuteException)
        {
            return new Output(string.Empty, false);
        }
    }
}