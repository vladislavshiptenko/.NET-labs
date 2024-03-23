using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CpuAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CoolingSystem : IComponent
{
    private IList<Socket> _supportingSockets;

    public CoolingSystem(IList<Socket> supportingSockets, string name, MillimetersDimensions coolingSystemDimensions, Tdp maxTdp)
    {
        _supportingSockets = supportingSockets;
        Name = name;
        CoolingSystemDimensions = coolingSystemDimensions;
        MaxTdp = maxTdp;
    }

    public string Name { get; }
    public MillimetersDimensions CoolingSystemDimensions { get; }
    public Tdp MaxTdp { get; }

    public bool CompatibleWithCpu(Cpu cpu)
    {
        return _supportingSockets.Any(ss => ss == cpu.CpuSocket);
    }

    public void Direct(CoolingSystemBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddSupportingSocketList(_supportingSockets);
        builder.AddName(Name);
        builder.AddCoolingSystemDimensions(CoolingSystemDimensions);
        builder.AddMaxTdp(MaxTdp);
    }
}