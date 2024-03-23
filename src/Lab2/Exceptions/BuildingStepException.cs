using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class BuildingStepException : InvalidBuildingException
{
    public BuildingStepException(string name)
        : base(name)
    {
    }

    public BuildingStepException()
    {
    }

    public BuildingStepException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}