using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;

public class Voltage
{
    public Voltage(double value)
    {
        if (value < 0.5 || value > 2)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public double Value { get; }
}