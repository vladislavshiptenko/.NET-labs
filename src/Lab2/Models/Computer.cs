using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Computer : IComputer<ComputerBuilder>
{
    private const int VideoCardNumber = 1;
    private readonly IList<Hdd> _hddList;
    private readonly IList<Ssd> _ssdList;
    private IList<Ram> _ramList;
    public Computer(ComputerCase? computerCase, CoolingSystem? coolingSystem, Motherboard? motherboard, PowerSupply? powerSupply, VideoCard? videoCard, WifiAdapter? wifiAdapter, Cpu? cpu, IList<Hdd> hddList, IList<Ssd> ssdList, IList<Ram> ramList)
    {
        ComputerCase = computerCase ?? throw new ArgumentNullException(nameof(computerCase));
        CoolingSystem = coolingSystem ?? throw new ArgumentNullException(nameof(coolingSystem));
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
        PowerSupply = powerSupply ?? throw new ArgumentNullException(nameof(powerSupply));
        VideoCard = videoCard;
        WifiAdapter = wifiAdapter;
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        _hddList = hddList;
        _ssdList = ssdList;
        _ramList = ramList;
    }

    public ComputerCase ComputerCase { get; }
    public CoolingSystem CoolingSystem { get; }
    public Motherboard Motherboard { get; }
    public PowerSupply PowerSupply { get; }
    public VideoCard? VideoCard { get; }
    public WifiAdapter? WifiAdapter { get; }
    public Cpu Cpu { get; }

    public void Direct(ComputerBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddMotherboard(Motherboard);
        builder.AddHddList(_hddList);
        builder.AddSsdList(_ssdList);
        builder.AddRamList(_ramList);
        builder.AddCpu(Cpu);
        builder.AddCoolingSystem(CoolingSystem);
        builder.AddVideoCard(VideoCard);
        builder.AddWifiAdapter(WifiAdapter);
        builder.AddPowerSupply(PowerSupply);
        builder.AddComputerCase(ComputerCase);
    }

    public int SumRamPower()
    {
        return _ramList.Sum(r => r.RamPower.Value);
    }

    public int SumSsdPower()
    {
        return _ssdList.Sum(s => s.SsdPower.Value);
    }

    public int SumHddPower()
    {
        return _hddList.Sum(h => h.HddPower.Value);
    }

    public int PciEComponentsCount()
    {
        int wifiAdapterNumber = 0;
        if (WifiAdapter is not null)
        {
            wifiAdapterNumber = 1;
        }

        return VideoCardNumber + wifiAdapterNumber + _ssdList.Count(s => s.SsdConnector == Connector.PciE);
    }

    public int SataComponentsCount()
    {
        return _hddList.Count + _ssdList.Count(s => s.SsdConnector == Connector.Sata);
    }

    public int RamCount()
    {
        return _ramList.Count;
    }

    public int SsdCount()
    {
        return _ssdList.Count;
    }

    public int HddCount()
    {
        return _hddList.Count;
    }

    public bool CompatibleCpuWithRam()
    {
        return _ramList.All(r => Cpu.CompatibleWithRam(r));
    }
}