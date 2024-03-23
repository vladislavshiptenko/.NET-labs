using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : IComponent
{
    private IList<Xmp> _supportingXmp;
    private IList<JedecVoltageMatching> _supportingJedecVoltage;

    public Ram(IList<Xmp> supportingXmp, IList<JedecVoltageMatching> supportingJedecVoltage, string name, NumberGigabytesMemory ramMemoryCapacity, FormFactor ramFormFactor, Ddr ddrVersion, Power ramPower)
    {
        _supportingXmp = supportingXmp;
        _supportingJedecVoltage = supportingJedecVoltage;
        Name = name;
        RamMemoryCapacity = ramMemoryCapacity;
        RamFormFactor = ramFormFactor;
        DdrVersion = ddrVersion;
        RamPower = ramPower;
    }

    public string Name { get; }
    public NumberGigabytesMemory RamMemoryCapacity { get; }
    public FormFactor RamFormFactor { get; }
    public Ddr DdrVersion { get; }
    public Power RamPower { get; }
    public void Direct(RamBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddSupportingXmp(_supportingXmp);
        builder.AddSupportingJedecVoltage(_supportingJedecVoltage);
        builder.AddName(Name);
        builder.AddRamMemoryCapacity(RamMemoryCapacity);
        builder.AddRamFormFactor(RamFormFactor);
        builder.AddDdrVersion(DdrVersion);
        builder.AddRamPower(RamPower);
    }

    public bool Find(JedecVoltageMatching jedec)
    {
        return _supportingJedecVoltage.Any(j => Math.Abs(j.Voltage.Value - jedec.Voltage.Value) < 0.0000001 && j.Frequency.Value == jedec.Frequency.Value);
    }
}