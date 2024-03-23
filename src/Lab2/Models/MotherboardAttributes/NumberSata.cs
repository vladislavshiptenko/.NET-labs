using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;

public class NumberSata
{
    public NumberSata(int value)
    {
        if (value < 2 || value > 10)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}