using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ComponentCompatibleException : InvalidBuildingException
{
    public ComponentCompatibleException(string name)
        : base(name)
    {
    }

    public ComponentCompatibleException()
    {
    }

    public ComponentCompatibleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}