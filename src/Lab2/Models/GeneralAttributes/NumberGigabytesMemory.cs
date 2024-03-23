using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

public class NumberGigabytesMemory
{
    public NumberGigabytesMemory(int value)
    {
        if (value == 0 || value > 5000)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}