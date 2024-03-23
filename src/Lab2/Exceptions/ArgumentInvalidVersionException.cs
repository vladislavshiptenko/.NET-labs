using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ArgumentInvalidVersionException : Exception
{
    public ArgumentInvalidVersionException(string name)
        : base(name)
    {
    }

    public ArgumentInvalidVersionException()
    {
    }

    public ArgumentInvalidVersionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}