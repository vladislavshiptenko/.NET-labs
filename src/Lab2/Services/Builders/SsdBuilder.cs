using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class SsdBuilder
{
    private string? _name;
    private Connector _ssdConnector;
    private NumberGigabytesMemory? _memoryCapacity;
    private MegabytesPerSecondEfficiency? _maxEfficiency;
    private Power? _ssdPower;

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddSsdConnector(Connector ssdConnector)
    {
        _ssdConnector = ssdConnector;
    }

    public void AddMemoryCapacity(NumberGigabytesMemory memoryCapacity)
    {
        _memoryCapacity = memoryCapacity;
    }

    public void AddMaxEfficiency(MegabytesPerSecondEfficiency maxEfficiency)
    {
        _maxEfficiency = maxEfficiency;
    }

    public void AddSsdPower(Power ssdPower)
    {
        _ssdPower = ssdPower;
    }

    public Ssd Build()
    {
        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_memoryCapacity is null)
        {
            throw new BuildingStepException(nameof(_memoryCapacity));
        }

        if (_maxEfficiency is null)
        {
            throw new BuildingStepException(nameof(_maxEfficiency));
        }

        if (_ssdPower is null)
        {
            throw new BuildingStepException(nameof(_ssdPower));
        }

        return new Ssd(_name, _ssdConnector, _memoryCapacity, _maxEfficiency, _ssdPower);
    }
}