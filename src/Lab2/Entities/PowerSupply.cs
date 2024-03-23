using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply : IComponent
{
    public PowerSupply(string name, Power maxPower)
    {
        Name = name;
        MaxPower = maxPower;
    }

    public string Name { get; }
    public Power MaxPower { get; }
    public void Direct(PowerSupplyBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddName(Name);
        builder.AddMaxPower(MaxPower);
    }
}