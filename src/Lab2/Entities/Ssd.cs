using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : IComponent
{
    public Ssd(string name, Connector ssdConnector, NumberGigabytesMemory memoryCapacity, MegabytesPerSecondEfficiency maxEfficiency, Power ssdPower)
    {
        Name = name;
        SsdConnector = ssdConnector;
        MemoryCapacity = memoryCapacity;
        MaxEfficiency = maxEfficiency;
        SsdPower = ssdPower;
    }

    public string Name { get; }
    public Connector SsdConnector { get; }
    public NumberGigabytesMemory MemoryCapacity { get; }
    public MegabytesPerSecondEfficiency MaxEfficiency { get; }
    public Power SsdPower { get; }
    public void Direct(SsdBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddName(Name);
        builder.AddSsdConnector(SsdConnector);
        builder.AddMemoryCapacity(MemoryCapacity);
        builder.AddMaxEfficiency(MaxEfficiency);
        builder.AddSsdPower(SsdPower);
    }
}