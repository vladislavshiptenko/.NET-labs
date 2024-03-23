using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PowerLimitException : WarningException
{
    public PowerLimitException(string name)
        : base(name)
    {
    }

    public PowerLimitException()
    {
    }

    public PowerLimitException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}