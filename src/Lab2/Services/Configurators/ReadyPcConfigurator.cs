using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Configurators;

public class ReadyPcConfigurator : IConfigurator<Computer>
{
    private readonly ComputerDetailsAbstractFactory _computerDetailsAbstractFactory;
    private readonly ComputerBuilder _computerBuilder;

    public ReadyPcConfigurator(IComputer<ComputerBuilder> computer, ComputerDetailsAbstractFactory computerDetailsAbstractFactory, ComputerBuilder computerBuilder)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        _computerBuilder = computerBuilder;
        _computerDetailsAbstractFactory = computerDetailsAbstractFactory;
        computer.Direct(computerBuilder);
    }

    public void ReplaceMotherboard(string newMotherboardName)
    {
        _computerBuilder.AddMotherboard(_computerDetailsAbstractFactory.GetMotherboardByName(newMotherboardName));
    }

    public void ReplaceCpu(string newCpuName)
    {
        _computerBuilder.AddCpu(_computerDetailsAbstractFactory.GetCpuByName(newCpuName));
    }

    public void ReplaceCoolingSystem(string newCoolingSystemName)
    {
        _computerBuilder.AddCoolingSystem(_computerDetailsAbstractFactory.GetCoolingSystemByName(newCoolingSystemName));
    }

    public void ReplaceVideoCard(string newVideoCardName)
    {
        _computerBuilder.AddVideoCard(_computerDetailsAbstractFactory.GetVideoCardByName(newVideoCardName));
    }

    public void ReplaceWifiAdapter(string newWifiAdapterName)
    {
        _computerBuilder.AddWifiAdapter(_computerDetailsAbstractFactory.GetWifiAdapterByName(newWifiAdapterName));
    }

    public void ReplacePowerSupply(string newPowerSupplyName)
    {
        _computerBuilder.AddPowerSupply(_computerDetailsAbstractFactory.GetPowerSupplyByName(newPowerSupplyName));
    }

    public void ReplaceComputerCase(string newComputerCaseName)
    {
        _computerBuilder.AddComputerCase(_computerDetailsAbstractFactory.GetComputerCaseByName(newComputerCaseName));
    }

    public void ReplaceHddList(IList<string> newHddList)
    {
        if (newHddList is null)
        {
            throw new ArgumentNullException(nameof(newHddList));
        }

        IList<Hdd> hddList = new List<Hdd>();
        foreach (string hdd in newHddList)
        {
            hddList.Add(_computerDetailsAbstractFactory.GetHddByName(hdd) ?? throw new ComponentNullException(nameof(hdd)));
        }

        _computerBuilder.AddHddList(hddList);
    }

    public void ReplaceSsdList(IList<string> newSsdList)
    {
        if (newSsdList is null)
        {
            throw new ArgumentNullException(nameof(newSsdList));
        }

        IList<Ssd> ssdList = new List<Ssd>();
        foreach (string ssd in newSsdList)
        {
            ssdList.Add(_computerDetailsAbstractFactory.GetSsdByName(ssd) ?? throw new ComponentNullException(nameof(ssd)));
        }

        _computerBuilder.AddSsdList(ssdList);
    }

    public void ReplaceRamList(IList<string> newRamList)
    {
        if (newRamList is null)
        {
            throw new ArgumentNullException(nameof(newRamList));
        }

        IList<Ram> ramList = new List<Ram>();
        foreach (string ram in newRamList)
        {
            ramList.Add(_computerDetailsAbstractFactory.GetRamByName(ram) ?? throw new ComponentNullException(nameof(ram)));
        }

        _computerBuilder.AddRamList(ramList);
    }

    public Computer ConstructComputer()
    {
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