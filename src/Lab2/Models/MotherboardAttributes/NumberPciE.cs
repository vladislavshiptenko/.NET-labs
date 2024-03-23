using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;

public class NumberPciE
{
    public NumberPciE(int value)
    {
        if (value < 1 || value > 16)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}