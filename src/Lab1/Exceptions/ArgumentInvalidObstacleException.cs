using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ArgumentInvalidObstacleException : Exception
{
    public ArgumentInvalidObstacleException(string name)
        : base(name)
    {
    }

    public ArgumentInvalidObstacleException()
    {
    }

    public ArgumentInvalidObstacleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}