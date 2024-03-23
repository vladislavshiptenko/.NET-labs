using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;

public class JedecVoltageMatching
{
    public JedecVoltageMatching(MegaHertzFrequency frequency, Voltage voltage)
    {
        Frequency = frequency;
        Voltage = voltage;
    }

    public MegaHertzFrequency Frequency { get; }
    public Voltage Voltage { get; }
}