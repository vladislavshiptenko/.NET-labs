using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class TdpCompatibleValidator : IComputerValidator
{
    public void Validate(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Cpu.CpuTdp.Value > computer.CoolingSystem.MaxTdp.Value || !computer.CoolingSystem.CompatibleWithCpu(computer.Cpu))
        {
            throw new TdpCompatibleException(nameof(computer.CoolingSystem));
        }
    }
}