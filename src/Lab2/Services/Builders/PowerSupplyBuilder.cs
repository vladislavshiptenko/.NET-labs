using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class PowerSupplyBuilder
{
    private string? _name;
    private Power? _maxPower;

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddMaxPower(Power maxPower)
    {
        _maxPower = maxPower;
    }

    public PowerSupply Build()
    {
        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_maxPower is null)
        {
            throw new BuildingStepException(nameof(_maxPower));
        }

        return new PowerSupply(_name, _maxPower);
    }
}