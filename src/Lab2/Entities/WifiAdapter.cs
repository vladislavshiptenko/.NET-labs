using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapterAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WifiAdapter : IComponent
{
    public WifiAdapter(string name, WifiStandard adapterWifiStandard, bool hasBluetooth, PciEVersion adapterPciEVersion, Power adapterPower)
    {
        Name = name;
        AdapterWifiStandard = adapterWifiStandard;
        HasBluetooth = hasBluetooth;
        AdapterPciEVersion = adapterPciEVersion;
        AdapterPower = adapterPower;
    }

    public string Name { get; }
    public WifiStandard AdapterWifiStandard { get; }
    public bool HasBluetooth { get; }
    public PciEVersion AdapterPciEVersion { get; }
    public Power AdapterPower { get; }
    public void Direct(WifiAdapterBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddName(Name);
        builder.AddAdapterWifiStandard(AdapterWifiStandard);
        builder.AddHasBluetooth(HasBluetooth);
        builder.AddAdapterPciEVersion(AdapterPciEVersion);
        builder.AddAdapterPower(AdapterPower);
    }
}