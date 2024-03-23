using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapterAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class WifiAdapterBuilder
{
    private string? _name;
    private WifiStandard _adapterWifiStandard;
    private bool _hasBluetooth;
    private PciEVersion _adapterPciEVersion;
    private Power? _adapterPower;

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddAdapterWifiStandard(WifiStandard adapterWifiStandard)
    {
        _adapterWifiStandard = adapterWifiStandard;
    }

    public void AddHasBluetooth(bool hasBluetooth)
    {
        _hasBluetooth = hasBluetooth;
    }

    public void AddAdapterPciEVersion(PciEVersion adapterPciEVersion)
    {
        _adapterPciEVersion = adapterPciEVersion;
    }

    public void AddAdapterPower(Power adapterPower)
    {
        _adapterPower = adapterPower;
    }

    public WifiAdapter Build()
    {
        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_adapterPower is null)
        {
            throw new BuildingStepException(nameof(_adapterPower));
        }

        return new WifiAdapter(_name, _adapterWifiStandard, _hasBluetooth, _adapterPciEVersion, _adapterPower);
    }
}