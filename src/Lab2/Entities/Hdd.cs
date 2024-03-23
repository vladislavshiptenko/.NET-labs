using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IComponent
{
    public Hdd(string name, NumberGigabytesMemory memoryCapacity, SpindleSpeed maxSpindleSpeed, Power hddPower)
    {
        Name = name;
        MemoryCapacity = memoryCapacity;
        MaxSpindleSpeed = maxSpindleSpeed;
        HddPower = hddPower;
    }

    public string Name { get; }
    public NumberGigabytesMemory MemoryCapacity { get; }
    public SpindleSpeed MaxSpindleSpeed { get; }
    public Power HddPower { get; }
    public void Direct(HddBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddName(Name);
        builder.AddMemoryCapacity(MemoryCapacity);
        builder.AddMaxSpindleSpeed(MaxSpindleSpeed);
        builder.AddHddPower(HddPower);
    }
}