using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ArgumentLessThanZeroException : Exception
{
    public ArgumentLessThanZeroException(string name)
        : base(name)
    {
    }

    public ArgumentLessThanZeroException()
    {
    }

    public ArgumentLessThanZeroException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}