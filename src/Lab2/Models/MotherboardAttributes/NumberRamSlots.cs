using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;

public class NumberRamSlots
{
    public NumberRamSlots(int value)
    {
        if (value < 2 || value > 8)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}