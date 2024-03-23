using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;

public class Chipset
{
    private IList<MegaHertzFrequency> _supportingRamFrequency;

    public Chipset(IList<MegaHertzFrequency> supportingRamFrequency, string name, bool supportXmp, bool supportWifi)
    {
        _supportingRamFrequency = supportingRamFrequency;
        Name = name;
        SupportXmp = supportXmp;
        SupportWifi = supportWifi;
    }

    public string Name { get; }
    public bool SupportXmp { get; }
    public bool SupportWifi { get; }
}