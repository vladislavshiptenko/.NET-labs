using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : IComponent
{
    public Motherboard(string name, Socket motherboardSocket, NumberPciE numberPciESlots, NumberSata numberSataSlots, Chipset chipset, Ddr ddrVersion, NumberRamSlots numberRamSlots, FormFactor motherboardFormFactor, Bios bios)
    {
        Name = name;
        MotherboardSocket = motherboardSocket;
        NumberPciESlots = numberPciESlots;
        NumberSataSlots = numberSataSlots;
        Chipset = chipset;
        DdrVersion = ddrVersion;
        NumberRamSlots = numberRamSlots;
        MotherboardFormFactor = motherboardFormFactor;
        Bios = bios;
    }

    public string Name { get; }
    public Socket MotherboardSocket { get; }
    public NumberPciE NumberPciESlots { get; }
    public NumberSata NumberSataSlots { get; }
    public Chipset Chipset { get; }
    public Ddr DdrVersion { get; }
    public NumberRamSlots NumberRamSlots { get; }
    public FormFactor MotherboardFormFactor { get; }
    public Bios Bios { get; }
    public void Direct(MotherboardBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddName(Name);
        builder.AddMotherBoardSocket(MotherboardSocket);
        builder.AddNumberPciESlots(NumberPciESlots);
        builder.AddNumberSataSlots(NumberSataSlots);
        builder.AddChipset(Chipset);
        builder.AddDdrVersion(DdrVersion);
        builder.AddNumberRamSlots(NumberRamSlots);
        builder.AddMotherboardFormFactor(MotherboardFormFactor);
        builder.AddBios(Bios);
    }
}