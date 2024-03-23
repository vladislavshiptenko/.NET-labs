using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ParseInvalidTypeException : Exception
{
    public ParseInvalidTypeException(string name)
        : base(name)
    {
    }

    public ParseInvalidTypeException()
    {
    }

    public ParseInvalidTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}