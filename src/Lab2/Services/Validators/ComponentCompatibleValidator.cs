using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class ComponentCompatibleValidator : IComputerValidator
{
    public void Validate(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Cpu.CpuSocket != computer.Motherboard.MotherboardSocket || computer.Motherboard.Bios.CompatibleWithCpu(computer.Cpu))
        {
            throw new ComponentCompatibleException(nameof(computer.Cpu));
        }

        if (computer.VideoCard is null && !computer.Cpu.HasIntegratedVideoCore)
        {
            throw new ComponentCompatibleException(nameof(computer.VideoCard));
        }

        if (!computer.ComputerCase.CompatibleWithVideoCard(computer.VideoCard) ||
            !computer.ComputerCase.CompatibleWithMotherboard(computer.Motherboard))
        {
            throw new ComponentCompatibleException(nameof(computer.ComputerCase));
        }

        if (computer.WifiAdapter is not null && computer.Motherboard.Chipset.SupportWifi)
        {
            throw new ComponentCompatibleException(nameof(computer.WifiAdapter));
        }
    }
}