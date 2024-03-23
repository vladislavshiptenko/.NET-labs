using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BiosAttributes;

public class BiosVersion
{
    public BiosVersion(string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Any(symbol => (symbol < '0' || symbol > '9') && symbol != '.') || value.Count(symbol => symbol == '.') != 1 || value.Last() == '.')
        {
            throw new ArgumentInvalidVersionException(nameof(value));
        }

        Value = value;
    }

    public string Value { get; }
}