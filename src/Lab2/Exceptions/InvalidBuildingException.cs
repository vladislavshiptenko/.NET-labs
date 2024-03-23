using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class InvalidBuildingException : Exception
{
    public InvalidBuildingException(string name)
        : base(name)
    {
    }

    public InvalidBuildingException()
    {
    }

    public InvalidBuildingException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}