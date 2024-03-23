using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class RamEmptyException : InvalidBuildingException
{
    public RamEmptyException(string name)
        : base(name)
    {
    }

    public RamEmptyException()
    {
    }

    public RamEmptyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}