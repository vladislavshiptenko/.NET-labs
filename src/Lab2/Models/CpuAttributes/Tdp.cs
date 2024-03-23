using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CpuAttributes;

public class Tdp
{
    public Tdp(int value)
    {
        if (value < 10 || value > 700)
        {
            throw new ArgumentInvalidValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}