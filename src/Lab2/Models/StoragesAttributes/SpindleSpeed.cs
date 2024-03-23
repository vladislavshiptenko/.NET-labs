using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;

public class SpindleSpeed
{
    public SpindleSpeed(int value)
    {
        if (value < 2000 || value > 100000)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}