using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class MotherboardBuilder
{
    private string? _name;
    private Socket _motherboardSocket;
    private NumberPciE? _numberPciESlots;
    private NumberSata? _numberSataSlots;
    private Chipset? _chipset;
    private Ddr _ddrVersion;
    private NumberRamSlots? _numberRamSlots;
    private FormFactor? _motherboardFormFactor;
    private Bios? _bios;

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddChipset(Chipset chipset)
    {
        _chipset = chipset;
    }

    public void AddMotherBoardSocket(Socket motherboardSocket)
    {
        _motherboardSocket = motherboardSocket;
    }

    public void AddNumberPciESlots(NumberPciE numberPciESlots)
    {
        _numberPciESlots = numberPciESlots;
    }

    public void AddNumberSataSlots(NumberSata numberSataSlots)
    {
        _numberSataSlots = numberSataSlots;
    }

    public void AddDdrVersion(Ddr ddrVersion)
    {
        _ddrVersion = ddrVersion;
    }

    public void AddNumberRamSlots(NumberRamSlots numberRamSlots)
    {
        _numberRamSlots = numberRamSlots;
    }

    public void AddMotherboardFormFactor(FormFactor motherboardFormFactor)
    {
        _motherboardFormFactor = motherboardFormFactor;
    }

    public void AddBios(Bios bios)
    {
        _bios = bios;
    }

    public Motherboard Build()
    {
        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_numberPciESlots is null)
        {
            throw new BuildingStepException(nameof(_numberPciESlots));
        }

        if (_numberSataSlots is null)
        {
            throw new BuildingStepException(nameof(_numberSataSlots));
        }

        if (_numberRamSlots is null)
        {
            throw new BuildingStepException(nameof(_numberRamSlots));
        }

        if (_motherboardFormFactor is null)
        {
            throw new BuildingStepException(nameof(_motherboardFormFactor));
        }

        if (_bios is null)
        {
            throw new BuildingStepException(nameof(_bios));
        }

        if (_chipset is null)
        {
            throw new BuildingStepException(nameof(_chipset));
        }

        return new Motherboard(_name, _motherboardSocket, _numberPciESlots, _numberSataSlots, _chipset, _ddrVersion, _numberRamSlots, _motherboardFormFactor, _bios);
    }
}