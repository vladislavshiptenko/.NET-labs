using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class InvalidFileSystemTraverseException : Exception
{
    public InvalidFileSystemTraverseException(string name)
        : base(name)
    {
    }

    public InvalidFileSystemTraverseException()
    {
    }

    public InvalidFileSystemTraverseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}