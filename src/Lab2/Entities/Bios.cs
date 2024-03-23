using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BiosAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios
{
    private IList<Cpu> _supportingCpu;
    public Bios(IList<Cpu> supportingCpu, BiosType type, BiosVersion version)
    {
        _supportingCpu = supportingCpu;
        Type = type;
        Version = version;
    }

    public BiosType Type { get; }
    public BiosVersion Version { get; }
    public bool CompatibleWithCpu(Cpu cpu)
    {
        return _supportingCpu.Any(su => su == cpu);
    }
}