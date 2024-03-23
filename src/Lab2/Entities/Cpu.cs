using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CpuAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IComponent
{
    private IList<JedecVoltageMatching> _supportingJedecVoltage;
    public Cpu(string name, MegaHertzFrequency coreFrequency, NumberCore cpuNumberCore, Socket cpuSocket, bool hasIntegratedVideoCore, Tdp cpuTdp, Power cpuPower, IList<JedecVoltageMatching> supportingJedecVoltage)
    {
        Name = name;
        CoreFrequency = coreFrequency;
        CpuNumberCore = cpuNumberCore;
        CpuSocket = cpuSocket;
        HasIntegratedVideoCore = hasIntegratedVideoCore;
        CpuTdp = cpuTdp;
        CpuPower = cpuPower;
        _supportingJedecVoltage = supportingJedecVoltage;
    }

    public string Name { get; }
    public MegaHertzFrequency CoreFrequency { get; }
    public NumberCore CpuNumberCore { get; }
    public Socket CpuSocket { get; }
    public bool HasIntegratedVideoCore { get; }
    public Tdp CpuTdp { get; }
    public Power CpuPower { get; }
    public void Direct(CpuBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddSupportingJedecVoltage(_supportingJedecVoltage);
        builder.AddName(Name);
        builder.AddCoreFrequency(CoreFrequency);
        builder.AddCpuNumberCore(CpuNumberCore);
        builder.AddCpuSocket(CpuSocket);
        builder.AddHasIntegratedVideoCore(HasIntegratedVideoCore);
        builder.AddCpuTdp(CpuTdp);
        builder.AddCpuPower(CpuPower);
    }

    public bool CompatibleWithRam(Ram ram)
    {
        return _supportingJedecVoltage.Any(jedec => ram.Find(jedec));
    }
}