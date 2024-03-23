using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class PowerLimitValidator : IComputerValidator
{
    public void Validate(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        int videoCardPower = 0;
        if (computer.VideoCard is not null)
        {
            videoCardPower = computer.VideoCard.VideoCardPower.Value;
        }

        int wifiAdapterPower = 0;
        if (computer.WifiAdapter is not null)
        {
            wifiAdapterPower = computer.WifiAdapter.AdapterPower.Value;
        }

        int powerConsumption = computer.Cpu.CpuPower.Value + computer.SumRamPower() + computer.SumSsdPower() +
                               computer.SumHddPower() + videoCardPower + wifiAdapterPower;
        if (powerConsumption > computer.PowerSupply.MaxPower.Value)
        {
            throw new PowerLimitException();
        }
    }
}