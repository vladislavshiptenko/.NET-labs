using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class DevicesPerPortValidator : IComputerValidator
{
    public void Validate(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.SataComponentsCount() > computer.Motherboard.NumberSataSlots.Value)
        {
            throw new DevicesPerPortExceededException(nameof(computer.Motherboard.NumberSataSlots));
        }

        if (computer.Motherboard.NumberPciESlots.Value < computer.PciEComponentsCount())
        {
            throw new DevicesPerPortExceededException(nameof(computer.Motherboard.NumberPciESlots));
        }

        if (computer.RamCount() > computer.Motherboard.NumberRamSlots.Value)
        {
            throw new DevicesPerPortExceededException(nameof(computer.Motherboard.NumberRamSlots));
        }
    }
}