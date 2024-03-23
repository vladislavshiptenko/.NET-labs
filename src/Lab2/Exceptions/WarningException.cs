using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class WarningException : Exception
{
    public WarningException(string name)
        : base(name)
    {
    }

    public WarningException()
    {
    }

    public WarningException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}