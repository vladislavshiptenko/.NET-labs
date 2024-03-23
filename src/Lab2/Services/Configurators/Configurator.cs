using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Configurators;

public class Configurator : IConfigurator<Computer>
{
    private string _computerCaseName;
    private string _coolingSystemName;
    private string _cpuName;
    private string _motherboardName;
    private string _powerSupplyName;
    private string _videoCardName;
    private string _wifiAdapterName;
    private IList<string> _hddList;
    private IList<string> _ssdList;
    private IList<string> _ramList;
    private ComputerDetailsAbstractFactory _computerDetailsAbstractFactory;
    private ComputerBuilder _computerBuilder;

    public Configurator(string computerCaseName, string coolingSystemName, string cpuName, string motherboardName, string powerSupplyName, string videoCardName, string wifiAdapterName, IList<string> hddList, IList<string> ssdList, IList<string> ramList, ComputerDetailsAbstractFactory computerDetailsAbstractFactory, ComputerBuilder computerBuilder)
    {
        _computerCaseName = computerCaseName;
        _coolingSystemName = coolingSystemName;
        _cpuName = cpuName;
        _motherboardName = motherboardName;
        _powerSupplyName = powerSupplyName;
        _videoCardName = videoCardName;
        _wifiAdapterName = wifiAdapterName;
        _hddList = hddList;
        _ssdList = ssdList;
        _ramList = ramList;
        _computerDetailsAbstractFactory = computerDetailsAbstractFactory;
        _computerBuilder = computerBuilder;
    }

    public void ReplaceMotherboard(string newMotherboardName)
    {
        _motherboardName = newMotherboardName;
    }

    public void ReplaceCpu(string newCpuName)
    {
        _cpuName = newCpuName;
    }

    public void ReplaceCoolingSystem(string newCoolingSystemName)
    {
        _coolingSystemName = newCoolingSystemName;
    }

    public void ReplaceVideoCard(string newVideoCardName)
    {
        _videoCardName = newVideoCardName;
    }

    public void ReplaceWifiAdapter(string newWifiAdapterName)
    {
        _wifiAdapterName = newWifiAdapterName;
    }

    public void ReplacePowerSupply(string newPowerSupplyName)
    {
        _powerSupplyName = newPowerSupplyName;
    }

    public void ReplaceComputerCase(string newComputerCaseName)
    {
        _computerCaseName = newComputerCaseName;
    }

    public void ReplaceHddList(IList<string> newHddList)
    {
        _hddList = newHddList;
    }

    public void ReplaceSsdList(IList<string> newSsdList)
    {
        _ssdList = newSsdList;
    }

    public void ReplaceRamList(IList<string> newRamList)
    {
        _ramList = newRamList;
    }

    public Computer ConstructComputer()
    {
        _computerBuilder.AddMotherboard(_computerDetailsAbstractFactory.GetMotherboardByName(_motherboardName));
        IList<Hdd> hddList = new List<Hdd>();
        IList<Ssd> ssdList = new List<Ssd>();
        IList<Ram> ramList = new List<Ram>();
        foreach (string hdd in _hddList)
        {
            hddList.Add(_computerDetailsAbstractFactory.GetHddByName(hdd) ?? throw new ArgumentNullException(nameof(hdd)));
        }

        foreach (string ssd in _ssdList)
        {
            ssdList.Add(_computerDetailsAbstractFactory.GetSsdByName(ssd) ?? throw new ArgumentNullException(nameof(ssd)));
        }

        foreach (string ram in _ramList)
        {
            ramList.Add(_computerDetailsAbstractFactory.GetRamByName(ram) ?? throw new ArgumentNullException(nameof(ram)));
        }

        _computerBuilder.AddHddList(hddList);
        _computerBuilder.AddSsdList(ssdList);
        _computerBuilder.AddRamList(ramList);
        _computerBuilder.AddCpu(_computerDetailsAbstractFactory.GetCpuByName(_cpuName));
        _computerBuilder.AddCoolingSystem(_computerDetailsAbstractFactory.GetCoolingSystemByName(_coolingSystemName));
        _computerBuilder.AddVideoCard(_computerDetailsAbstractFactory.GetVideoCardByName(_videoCardName));
        _computerBuilder.AddWifiAdapter(_computerDetailsAbstractFactory.GetWifiAdapterByName(_wifiAdapterName));
        _computerBuilder.AddPowerSupply(_computerDetailsAbstractFactory.GetPowerSupplyByName(_powerSupplyName));
        _computerBuilder.AddComputerCase(_computerDetailsAbstractFactory.GetComputerCaseByName(_computerCaseName));

        try
        {
            Computer computer = _computerBuilder.Build();
            return computer;
        }
        catch (WarningException we)
        {
            Console.WriteLine(we.Message);
            Console.WriteLine("Отказ от гарантийных обязательств");
            throw;
        }
        catch (InvalidBuildingException err)
        {
            Console.WriteLine(err.Message);
            Console.WriteLine("Сборка некорректна");
            throw;
        }
    }
}