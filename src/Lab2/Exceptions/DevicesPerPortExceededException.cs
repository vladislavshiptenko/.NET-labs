using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class DevicesPerPortExceededException : InvalidBuildingException
{
    public DevicesPerPortExceededException(string name)
        : base(name)
    {
    }

    public DevicesPerPortExceededException()
    {
    }

    public DevicesPerPortExceededException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}