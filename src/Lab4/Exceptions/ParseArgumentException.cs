using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ParseArgumentException : Exception
{
    public ParseArgumentException(string name)
        : base(name)
    {
    }

    public ParseArgumentException()
    {
    }

    public ParseArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}