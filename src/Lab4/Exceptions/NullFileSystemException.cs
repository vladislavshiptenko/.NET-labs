using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NullFileSystemException : Exception
{
    public NullFileSystemException(string name)
        : base(name)
    {
    }

    public NullFileSystemException()
    {
    }

    public NullFileSystemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}