using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CpuAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CpuBuilder
{
    private IList<JedecVoltageMatching> _supportingJedecVoltage = new List<JedecVoltageMatching>();
    private string? _name;
    private MegaHertzFrequency? _coreFrequency;
    private NumberCore? _cpuNumberCore;
    private Socket _cpuSocket;
    private bool _hasIntegratedVideoCore;
    private Tdp? _cpuTdp;
    private Power? _cpuPower;

    public void AddSupportingJedecVoltage(IList<JedecVoltageMatching> supportingJedecVoltage)
    {
        _supportingJedecVoltage = supportingJedecVoltage;
    }

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddCoreFrequency(MegaHertzFrequency coreFrequency)
    {
        _coreFrequency = coreFrequency;
    }

    public void AddCpuNumberCore(NumberCore cpuNumberCore)
    {
        _cpuNumberCore = cpuNumberCore;
    }

    public void AddCpuSocket(Socket cpuSocket)
    {
        _cpuSocket = cpuSocket;
    }

    public void AddHasIntegratedVideoCore(bool hasIntegratedVideoCore)
    {
        _hasIntegratedVideoCore = hasIntegratedVideoCore;
    }

    public void AddCpuTdp(Tdp cpuTdp)
    {
        _cpuTdp = cpuTdp;
    }

    public void AddCpuPower(Power cpuPower)
    {
        _cpuPower = cpuPower;
    }

    public Cpu Build()
    {
        if (_supportingJedecVoltage.Count == 0)
        {
            throw new BuildingStepException(nameof(_supportingJedecVoltage));
        }

        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_coreFrequency is null)
        {
            throw new BuildingStepException(nameof(_coreFrequency));
        }

        if (_cpuNumberCore is null)
        {
            throw new BuildingStepException(nameof(_cpuNumberCore));
        }

        if (_cpuTdp is null)
        {
            throw new BuildingStepException(nameof(_cpuTdp));
        }

        if (_cpuPower is null)
        {
            throw new BuildingStepException(nameof(_cpuPower));
        }

        return new Cpu(_name, _coreFrequency, _cpuNumberCore, _cpuSocket, _hasIntegratedVideoCore, _cpuTdp, _cpuPower, _supportingJedecVoltage);
    }
}