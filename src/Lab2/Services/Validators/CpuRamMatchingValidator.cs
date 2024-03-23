using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CpuRamMatchingValidator : IComputerValidator
{
    public void Validate(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (!computer.CompatibleCpuWithRam())
        {
            throw new ComponentCompatibleException(nameof(computer.Cpu));
        }
    }
}