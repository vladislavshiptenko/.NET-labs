using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class ComputerBuilder
{
    private ComputerCase? _computerCase;
    private CoolingSystem? _coolingSystem;
    private Motherboard? _motherboard;
    private PowerSupply? _powerSupply;
    private VideoCard? _videoCard;
    private WifiAdapter? _wifiAdapter;
    private Cpu? _cpu;
    private IList<Hdd> _hddList = new List<Hdd>();
    private IList<Ssd> _ssdList = new List<Ssd>();
    private IList<Ram> _ramList = new List<Ram>();
    private IList<IComputerValidator> _computerValidators;

    public ComputerBuilder(IList<IComputerValidator> computerValidators)
    {
        _computerValidators = computerValidators;
    }

    public void AddComputerCase(ComputerCase? computerCase)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        if (_coolingSystem is null)
        {
            throw new BuildingStepException(nameof(_coolingSystem));
        }

        if (_powerSupply is null)
        {
            throw new BuildingStepException(nameof(_powerSupply));
        }

        if (_cpu is null)
        {
            throw new BuildingStepException(nameof(_videoCard));
        }

        _computerCase = computerCase ?? throw new ArgumentNullException(nameof(computerCase));
    }

    public void AddCoolingSystem(CoolingSystem? coolingSystem)
    {
        if (_cpu is null)
        {
            throw new BuildingStepException(nameof(_videoCard));
        }

        _coolingSystem = coolingSystem ?? throw new ArgumentNullException(nameof(coolingSystem));
    }

    public void AddMotherboard(Motherboard? motherboard)
    {
        _motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
    }

    public void AddPowerSupply(PowerSupply? powerSupply)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        _powerSupply = powerSupply ?? throw new ArgumentNullException(nameof(powerSupply));
    }

    public void AddVideoCard(VideoCard? videoCard)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        _videoCard = videoCard ?? throw new ArgumentNullException(nameof(videoCard));
    }

    public void AddWifiAdapter(WifiAdapter? wifiAdapter)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        _wifiAdapter = wifiAdapter;
    }

    public void AddCpu(Cpu? cpu)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        _cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
    }

    public void AddHddList(IList<Hdd> hddList)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        _hddList = hddList;
    }

    public void AddSsdList(IList<Ssd> ssdList)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        _ssdList = ssdList;
    }

    public void AddRamList(IList<Ram> ramList)
    {
        if (_motherboard is null)
        {
            throw new BuildingStepException(nameof(_motherboard));
        }

        _ramList = ramList;
    }

    public Computer Build()
    {
        var computer = new Computer(_computerCase, _coolingSystem, _motherboard, _powerSupply, _videoCard, _wifiAdapter, _cpu, _hddList, _ssdList, _ramList);
        foreach (IComputerValidator validator in _computerValidators)
        {
            validator.Validate(computer);
        }

        return computer;
    }
}