using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class BuildingStepValidator : IComputerValidator
{
    public void Validate(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Motherboard is null)
        {
            throw new BuildingStepException(nameof(computer.Motherboard));
        }

        if (computer.Cpu is null)
        {
            throw new BuildingStepException(nameof(computer.Cpu));
        }

        if (computer.CoolingSystem is null)
        {
            throw new BuildingStepException(nameof(computer.CoolingSystem));
        }

        if (computer.ComputerCase is null)
        {
            throw new BuildingStepException(nameof(computer.ComputerCase));
        }

        if (computer.PowerSupply is null)
        {
            throw new BuildingStepException(nameof(computer.PowerSupply));
        }
    }
}