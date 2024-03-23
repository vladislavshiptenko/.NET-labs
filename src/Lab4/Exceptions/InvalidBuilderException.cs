using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class InvalidBuilderException : Exception
{
    public InvalidBuilderException(string name)
        : base(name)
    {
    }

    public InvalidBuilderException()
    {
    }

    public InvalidBuilderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}