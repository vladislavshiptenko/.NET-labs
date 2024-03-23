using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;

public class MegabytesPerSecondEfficiency
{
    public MegabytesPerSecondEfficiency(int value)
    {
        if (value < 300 || value > 800)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}