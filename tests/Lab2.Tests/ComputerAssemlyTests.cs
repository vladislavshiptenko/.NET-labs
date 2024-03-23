using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configurators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerAssemlyTests
{
    private readonly ComputerDetailsAbstractFactory _computerDetailsAbstractFactory;
    private readonly IList<IComputerValidator> _computerValidators;

    public ComputerAssemlyTests()
    {
        _computerDetailsAbstractFactory = TestData.Components();
        _computerValidators = new List<IComputerValidator>();
        _computerValidators.Add(new BuildingStepValidator());
        _computerValidators.Add(new ComponentCompatibleValidator());
        _computerValidators.Add(new PowerLimitValidator());
        _computerValidators.Add(new RamEmptyValidator());
        _computerValidators.Add(new StorageEmptyValidator());
        _computerValidators.Add(new TdpCompatibleValidator());
        _computerValidators.Add(new DevicesPerPortValidator());
        _computerValidators.Add(new CpuRamMatchingValidator());
    }

    [Fact]
    public void ValidAssembly()
    {
        // Arrange
        IList<string> hddList = new List<string>();
        hddList.Add("WD Blue");
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "DEEPCOOL FC120",
            "Intel Core i5-13400F",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            hddList,
            new List<string>(),
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act
        try
        {
            Computer computer = configurator.ConstructComputer();
        }
        catch (Exception)
        {
            // Assert
            Assert.Fail();
            throw;
        }
    }

    [Fact]
    public void NotEnoughPowerAssembly()
    {
        // Arrange
        IList<string> hddList = new List<string>();
        hddList.Add("WD Blue");
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "DEEPCOOL FC120",
            "Intel Core i7-13700KF",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "AeroCool VX PLUS 500W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            hddList,
            new List<string>(),
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act, Assert
        Assert.Throws<PowerLimitException>(() => configurator.ConstructComputer());
    }

    [Fact]
    public void NotMatchingCoolingSystemAssembly()
    {
        // Arrange
        IList<string> hddList = new List<string>();
        hddList.Add("WD Blue");
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "MSI MAX",
            "Intel Core i5-13400F",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            hddList,
            new List<string>(),
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act, Assert
        Assert.Throws<TdpCompatibleException>(() => configurator.ConstructComputer());
    }

    [Fact]
    public void SataPortExceededAssembly()
    {
        // Arrange
        IList<string> ssdList = new List<string>();
        ssdList.Add("Samsung 870 EVO");
        ssdList.Add("Samsung 870 EVO");
        ssdList.Add("Samsung 870 EVO");
        ssdList.Add("Samsung 870 EVO");
        ssdList.Add("Samsung 870 EVO");
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "DEEPCOOL FC120",
            "Intel Core i5-13400F",
            "ASRock B760M Pro RS/D4",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            "TP-LINK Archer T5E",
            new List<string>(),
            ssdList,
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act, Assert
        Assert.Throws<DevicesPerPortExceededException>(() => configurator.ConstructComputer());
    }

    [Fact]
    public void CpuNotMatchMotherboardAssembly()
    {
        // Arrange
        IList<string> hddList = new List<string>();
        hddList.Add("WD Blue");
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "DEEPCOOL FC120",
            "AMD Ryzen 5 5600X",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            hddList,
            new List<string>(),
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act, Assert
        Assert.Throws<ComponentCompatibleException>(() => configurator.ConstructComputer());
    }

    [Fact]
    public void VideoCardNotMatchComputerCaseAssembly()
    {
        // Arrange
        IList<string> hddList = new List<string>();
        hddList.Add("WD Blue");
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "AeroCool Cs-102",
            "DEEPCOOL FC120",
            "Intel Core i5-13400F",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            hddList,
            new List<string>(),
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act, Assert
        Assert.Throws<ComponentCompatibleException>(() => configurator.ConstructComputer());
    }

    [Fact]
    public void NoStorageAssembly()
    {
        // Arrange
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "DEEPCOOL FC120",
            "Intel Core i5-13400F",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            new List<string>(),
            new List<string>(),
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act, Assert
        Assert.Throws<StorageEmptyException>(() => configurator.ConstructComputer());
    }

    [Fact]
    public void NoRamAssembly()
    {
        // Arrange
        IList<string> hddList = new List<string>();
        hddList.Add("WD Blue");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "DEEPCOOL FC120",
            "Intel Core i5-13400F",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            hddList,
            new List<string>(),
            new List<string>(),
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act, Assert
        Assert.Throws<RamEmptyException>(() => configurator.ConstructComputer());
    }

    [Fact]
    public void FromAnotherAssemblyInvalidAssembly()
    {
        // Arrange
        IList<string> hddList = new List<string>();
        hddList.Add("WD Blue");
        IList<string> ramList = new List<string>();
        ramList.Add("Kingston FURY Beast Black");
        IConfigurator<Computer> configurator = new Configurator(
            "DEEPCOOL Wave V2",
            "DEEPCOOL FC120",
            "Intel Core i5-13400F",
            "MSI MAG Z690 TOMAHAWK WIFI",
            "Cougar STX 700W",
            "Palit GeForce RTX 3060 Ti Dual",
            string.Empty,
            hddList,
            new List<string>(),
            ramList,
            _computerDetailsAbstractFactory,
            new ComputerBuilder(_computerValidators));

        // Act
        IConfigurator<Computer> readyPcConfigurator = new ReadyPcConfigurator(configurator.ConstructComputer(), _computerDetailsAbstractFactory, new ComputerBuilder(_computerValidators));
        readyPcConfigurator.ReplaceWifiAdapter("TP-LINK Archer T5E");

        // Assert
        Assert.Throws<ComponentCompatibleException>(() => readyPcConfigurator.ConstructComputer());
    }
}