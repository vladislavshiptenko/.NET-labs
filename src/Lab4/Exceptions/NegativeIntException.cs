using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NegativeIntException : Exception
{
    public NegativeIntException(string name)
        : base(name)
    {
    }

    public NegativeIntException()
    {
    }

    public NegativeIntException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}