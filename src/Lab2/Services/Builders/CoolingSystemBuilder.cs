using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CpuAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CoolingSystemBuilder
{
    private IList<Socket> _supportingSockets = new List<Socket>();
    private string? _name;
    private MillimetersDimensions? _coolingSystemDimensions;
    private Tdp? _maxTdp;

    public void AddSupportingSocketList(IList<Socket> supportingSockets)
    {
        _supportingSockets = supportingSockets;
    }

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddCoolingSystemDimensions(MillimetersDimensions coolingSystemDimensions)
    {
        _coolingSystemDimensions = coolingSystemDimensions;
    }

    public void AddMaxTdp(Tdp maxTdp)
    {
        _maxTdp = maxTdp;
    }

    public CoolingSystem Build()
    {
        if (_supportingSockets.Count == 0)
        {
            throw new BuildingStepException(nameof(_supportingSockets));
        }

        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_coolingSystemDimensions is null)
        {
            throw new BuildingStepException(nameof(_coolingSystemDimensions));
        }

        if (_maxTdp is null)
        {
            throw new BuildingStepException(nameof(_maxTdp));
        }

        return new CoolingSystem(_supportingSockets, _name, _coolingSystemDimensions, _maxTdp);
    }
}