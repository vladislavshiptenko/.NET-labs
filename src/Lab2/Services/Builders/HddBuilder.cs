using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class HddBuilder
{
    private string? _name;
    private NumberGigabytesMemory? _memoryCapacity;
    private SpindleSpeed? _maxSpindleSpeed;
    private Power? _hddPower;

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddMaxSpindleSpeed(SpindleSpeed maxSpindleSpeed)
    {
        _maxSpindleSpeed = maxSpindleSpeed;
    }

    public void AddMemoryCapacity(NumberGigabytesMemory? memoryCapacity)
    {
        _memoryCapacity = memoryCapacity;
    }

    public void AddHddPower(Power hddPower)
    {
        _hddPower = hddPower;
    }

    public Hdd Build()
    {
        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_hddPower is null)
        {
            throw new BuildingStepException(nameof(_hddPower));
        }

        if (_maxSpindleSpeed is null)
        {
            throw new BuildingStepException(nameof(_maxSpindleSpeed));
        }

        if (_memoryCapacity is null)
        {
            throw new BuildingStepException(nameof(_memoryCapacity));
        }

        return new Hdd(_name, _memoryCapacity, _maxSpindleSpeed, _hddPower);
    }
}