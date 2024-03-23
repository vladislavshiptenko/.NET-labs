using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class StorageEmptyException : InvalidBuildingException
{
    public StorageEmptyException(string name)
        : base(name)
    {
    }

    public StorageEmptyException()
    {
    }

    public StorageEmptyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}