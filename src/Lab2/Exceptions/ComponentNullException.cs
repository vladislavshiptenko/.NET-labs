using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ComponentNullException : Exception
{
    public ComponentNullException(string name)
        : base(name)
    {
    }

    public ComponentNullException()
    {
    }

    public ComponentNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}