using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ArgumentInvalidValueException : Exception
{
    public ArgumentInvalidValueException(string name)
        : base(name)
    {
    }

    public ArgumentInvalidValueException()
    {
    }

    public ArgumentInvalidValueException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}