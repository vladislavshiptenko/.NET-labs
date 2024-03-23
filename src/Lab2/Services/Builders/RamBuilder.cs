using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class RamBuilder
{
    private IList<Xmp> _supportingXmp = new List<Xmp>();
    private IList<JedecVoltageMatching> _supportingJedecVoltage = new List<JedecVoltageMatching>();
    private string? _name;
    private NumberGigabytesMemory? _ramMemoryCapacity;
    private FormFactor? _ramFormFactor;
    private Ddr _ddrVersion;
    private Power? _ramPower;

    public void AddSupportingXmp(IList<Xmp> supportingXmp)
    {
        _supportingXmp = supportingXmp;
    }

    public void AddSupportingJedecVoltage(IList<JedecVoltageMatching> supportingJedecVoltage)
    {
        _supportingJedecVoltage = supportingJedecVoltage;
    }

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddRamMemoryCapacity(NumberGigabytesMemory ramMemoryCapacity)
    {
        _ramMemoryCapacity = ramMemoryCapacity;
    }

    public void AddRamFormFactor(FormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
    }

    public void AddDdrVersion(Ddr ddrVersion)
    {
        _ddrVersion = ddrVersion;
    }

    public void AddRamPower(Power ramPower)
    {
        _ramPower = ramPower;
    }

    public Ram Build()
    {
        if (_supportingXmp.Count == 0)
        {
            throw new BuildingStepException(nameof(_supportingXmp));
        }

        if (_supportingJedecVoltage.Count == 0)
        {
            throw new BuildingStepException(nameof(_supportingJedecVoltage));
        }

        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_ramMemoryCapacity is null)
        {
            throw new BuildingStepException(nameof(_ramMemoryCapacity));
        }

        if (_ramFormFactor is null)
        {
            throw new BuildingStepException(nameof(_ramFormFactor));
        }

        if (_ramPower is null)
        {
            throw new BuildingStepException(nameof(_ramPower));
        }

        return new Ram(_supportingXmp, _supportingJedecVoltage, _name, _ramMemoryCapacity, _ramFormFactor, _ddrVersion, _ramPower);
    }
}