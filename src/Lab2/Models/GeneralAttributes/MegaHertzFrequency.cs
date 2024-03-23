using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

public class MegaHertzFrequency
{
    public MegaHertzFrequency(int value)
    {
        if (value < 500 || value > 8500000)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}