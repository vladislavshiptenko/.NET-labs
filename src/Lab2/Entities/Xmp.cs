using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XmpAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Xmp
{
    public Xmp(Timings xmpTimings, Voltage xmpVoltage, MegaHertzFrequency frequency)
    {
        XmpTimings = xmpTimings;
        XmpVoltage = xmpVoltage;
        Frequency = frequency;
    }

    public Timings XmpTimings { get; }
    public Voltage XmpVoltage { get; }
    public MegaHertzFrequency Frequency { get; }
}