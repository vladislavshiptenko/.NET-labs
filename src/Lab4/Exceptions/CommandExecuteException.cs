using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class CommandExecuteException : Exception
{
    public CommandExecuteException(string name)
        : base(name)
    {
    }

    public CommandExecuteException()
    {
    }

    public CommandExecuteException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}