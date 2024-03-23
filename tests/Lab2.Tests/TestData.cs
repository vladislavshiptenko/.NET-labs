using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BiosAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CpuAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.StoragesAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapterAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XmpAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class TestData
{
    public static ComputerDetailsAbstractFactory Components()
    {
        return new ComputerDetailsAbstractFactory(CpuFactory(), MotherboardFactory(), RamFactory(), WifiAdapterFactory(), ComputerCaseFactory(), CoolingSystemFactory(), PowerSupplyFactory(), VideoCardFactory(), HddFactory(), SsdFactory());
    }

    private static RepositoryBase<ComputerCase> ComputerCaseFactory()
    {
        RepositoryBase<ComputerCase> computerCaseRepository = new ComputerCaseRepository();
        var computerCaseBuilder = new ComputerCaseBuilder();

        // First computer case
        computerCaseBuilder.AddName("DEXP DC-302R");
        computerCaseBuilder.AddComputerCaseDimensions(new MillimetersDimensions(325, 175, 405));
        computerCaseBuilder.AddMaxVideoCardDimensions(new MillimetersDimensions(300, 150, 100));
        IList<FormFactor> supportingFormFactorList = new List<FormFactor>();
        supportingFormFactorList.Add(new FormFactor(FormFactorType.MicroAtx));
        supportingFormFactorList.Add(new FormFactor(FormFactorType.Atx));
        computerCaseBuilder.AddSupportingFormFactorList(supportingFormFactorList);
        computerCaseRepository.Add(computerCaseBuilder.Build());

        // Second computer case
        computerCaseBuilder.AddName("DEEPCOOL Wave V2");
        computerCaseBuilder.AddComputerCaseDimensions(new MillimetersDimensions(387, 175, 354));
        computerCaseBuilder.AddMaxVideoCardDimensions(new MillimetersDimensions(320, 150, 100));
        supportingFormFactorList = new List<FormFactor>();
        supportingFormFactorList.Add(new FormFactor(FormFactorType.MicroAtx));
        supportingFormFactorList.Add(new FormFactor(FormFactorType.MiniItx));
        supportingFormFactorList.Add(new FormFactor(FormFactorType.Atx));
        computerCaseBuilder.AddSupportingFormFactorList(supportingFormFactorList);
        computerCaseRepository.Add(computerCaseBuilder.Build());

        // Third computer case
        computerCaseBuilder.AddName("AeroCool Cs-102");
        computerCaseBuilder.AddComputerCaseDimensions(new MillimetersDimensions(345, 190, 372));
        computerCaseBuilder.AddMaxVideoCardDimensions(new MillimetersDimensions(240, 150, 100));
        supportingFormFactorList = new List<FormFactor>();
        supportingFormFactorList.Add(new FormFactor(FormFactorType.MicroAtx));
        supportingFormFactorList.Add(new FormFactor(FormFactorType.MiniItx));
        computerCaseBuilder.AddSupportingFormFactorList(supportingFormFactorList);
        computerCaseRepository.Add(computerCaseBuilder.Build());

        // Fourth computer case
        ComputerCase? component = computerCaseRepository.GetByName("DEEPCOOL Wave V2");
        component?.Direct(computerCaseBuilder);
        computerCaseBuilder.AddName("ARDOR GAMING Rare Minicase MS4 WG");
        supportingFormFactorList = new List<FormFactor>();
        supportingFormFactorList.Add(new FormFactor(FormFactorType.MicroAtx));
        supportingFormFactorList.Add(new FormFactor(FormFactorType.MiniItx));
        supportingFormFactorList.Add(new FormFactor(FormFactorType.Atx));
        computerCaseBuilder.AddSupportingFormFactorList(supportingFormFactorList);
        computerCaseRepository.Add(computerCaseBuilder.Build());

        return computerCaseRepository;
    }

    private static RepositoryBase<CoolingSystem> CoolingSystemFactory()
    {
        RepositoryBase<CoolingSystem> coolingSystemRepository = new CoolingSystemRepository();
        var coolingSystemBuilder = new CoolingSystemBuilder();

        // First cooling system
        coolingSystemBuilder.AddName("Aerocool Frost 12 PWM FRGB");
        coolingSystemBuilder.AddCoolingSystemDimensions(new MillimetersDimensions(120, 120, 25));
        coolingSystemBuilder.AddMaxTdp(new Tdp(28));
        IList<Socket> supportingSocket = new List<Socket>();
        supportingSocket.Add(Socket.Lga1156);
        supportingSocket.Add(Socket.Lga1700);
        supportingSocket.Add(Socket.Lga2066);
        coolingSystemBuilder.AddSupportingSocketList(supportingSocket);
        coolingSystemRepository.Add(coolingSystemBuilder.Build());

        // Second cooling system
        coolingSystemBuilder.AddName("DEEPCOOL FC120");
        coolingSystemBuilder.AddCoolingSystemDimensions(new MillimetersDimensions(120, 120, 25));
        coolingSystemBuilder.AddMaxTdp(new Tdp(102));
        supportingSocket = new List<Socket>();
        supportingSocket.Add(Socket.Lga1366);
        supportingSocket.Add(Socket.Lga2011);
        supportingSocket.Add(Socket.Lga20113);
        supportingSocket.Add(Socket.Lga1700);
        coolingSystemBuilder.AddSupportingSocketList(supportingSocket);
        coolingSystemRepository.Add(coolingSystemBuilder.Build());

        // Third cooling system
        coolingSystemBuilder.AddName("MSI MAX");
        coolingSystemBuilder.AddCoolingSystemDimensions(new MillimetersDimensions(120, 120, 25));
        coolingSystemBuilder.AddMaxTdp(new Tdp(40));
        supportingSocket = new List<Socket>();
        supportingSocket.Add(Socket.Lga2066);
        supportingSocket.Add(Socket.Lga1851);
        supportingSocket.Add(Socket.Lga1200);
        supportingSocket.Add(Socket.Am4);
        coolingSystemBuilder.AddSupportingSocketList(supportingSocket);
        coolingSystemRepository.Add(coolingSystemBuilder.Build());

        return coolingSystemRepository;
    }

    private static RepositoryBase<Cpu> CpuFactory()
    {
        RepositoryBase<Cpu> cpuRepository = new CpuRepository();
        var cpuBuilder = new CpuBuilder();

        IList<JedecVoltageMatching> supportingJedecVoltage = new List<JedecVoltageMatching>();
        supportingJedecVoltage.Add(new JedecVoltageMatching(new MegaHertzFrequency(3200), new Voltage(1.40)));
        supportingJedecVoltage.Add(new JedecVoltageMatching(new MegaHertzFrequency(3200), new Voltage(1.35)));

        // First cpu
        cpuBuilder.AddName("AMD Ryzen 5 5600X");
        cpuBuilder.AddCpuPower(new Power(65));
        cpuBuilder.AddCpuTdp(new Tdp(40));
        cpuBuilder.AddCpuSocket(Socket.Am4);
        cpuBuilder.AddCpuNumberCore(new NumberCore(6));
        cpuBuilder.AddCoreFrequency(new MegaHertzFrequency(3700000));
        cpuBuilder.AddHasIntegratedVideoCore(false);
        cpuBuilder.AddSupportingJedecVoltage(supportingJedecVoltage);
        cpuRepository.Add(cpuBuilder.Build());

        // Second cpu
        cpuBuilder.AddName("Intel Core i5-13400F");
        cpuBuilder.AddCpuPower(new Power(148));
        cpuBuilder.AddCpuTdp(new Tdp(60));
        cpuBuilder.AddCpuSocket(Socket.Lga1700);
        cpuBuilder.AddCpuNumberCore(new NumberCore(10));
        cpuBuilder.AddCoreFrequency(new MegaHertzFrequency(2500000));
        cpuBuilder.AddHasIntegratedVideoCore(false);
        cpuBuilder.AddSupportingJedecVoltage(supportingJedecVoltage);
        cpuRepository.Add(cpuBuilder.Build());

        // Third cpu
        cpuBuilder.AddName("Intel Core i7-13700KF");
        cpuBuilder.AddCpuPower(new Power(253));
        cpuBuilder.AddCpuTdp(new Tdp(100));
        cpuBuilder.AddCpuSocket(Socket.Lga1700);
        cpuBuilder.AddCpuNumberCore(new NumberCore(16));
        cpuBuilder.AddCoreFrequency(new MegaHertzFrequency(3400000));
        cpuBuilder.AddHasIntegratedVideoCore(false);
        cpuBuilder.AddSupportingJedecVoltage(supportingJedecVoltage);
        cpuRepository.Add(cpuBuilder.Build());

        return cpuRepository;
    }

    private static RepositoryBase<Motherboard> MotherboardFactory()
    {
        RepositoryBase<Motherboard> motherboardRepository = new MotherboardRepository();
        var motherboardBuilder = new MotherboardBuilder();
        RepositoryBase<Cpu> cpuRepository = CpuFactory();

        // First motherboard
        motherboardBuilder.AddName("GIGABYTE B550 AORUS ELITE V2");
        motherboardBuilder.AddMotherboardFormFactor(new FormFactor(FormFactorType.Atx));
        IList<Cpu> cpuList = new List<Cpu>();
        cpuList.Add(cpuRepository.GetByName("AMD Ryzen 5 5600X") ?? throw new ArgumentNullException(nameof(cpuRepository)));
        motherboardBuilder.AddBios(new Bios(cpuList, BiosType.Ami, new BiosVersion("4.0")));
        IList<MegaHertzFrequency> frequencies = new List<MegaHertzFrequency>();
        frequencies.Add(new MegaHertzFrequency(5600));
        frequencies.Add(new MegaHertzFrequency(5000));
        frequencies.Add(new MegaHertzFrequency(3200));
        motherboardBuilder.AddChipset(new Chipset(frequencies, "AMD B550", true, false));
        motherboardBuilder.AddDdrVersion(Ddr.V4);
        motherboardBuilder.AddMotherBoardSocket(Socket.Am4);
        motherboardBuilder.AddNumberRamSlots(new NumberRamSlots(4));
        motherboardBuilder.AddNumberSataSlots(new NumberSata(4));
        motherboardBuilder.AddNumberPciESlots(new NumberPciE(3));
        motherboardRepository.Add(motherboardBuilder.Build());

        // Second motherboard
        motherboardBuilder.AddName("MSI MAG Z690 TOMAHAWK WIFI");
        motherboardBuilder.AddMotherboardFormFactor(new FormFactor(FormFactorType.Atx));
        cpuList = new List<Cpu>();
        cpuList.Add(cpuRepository.GetByName("Intel Core i5-13400F") ?? throw new ArgumentNullException(nameof(cpuRepository)));
        cpuList.Add(cpuRepository.GetByName("Intel Core i7-13700KF") ?? throw new ArgumentNullException(nameof(cpuRepository)));
        motherboardBuilder.AddBios(new Bios(cpuList, BiosType.Intel, new BiosVersion("3.0")));
        motherboardBuilder.AddChipset(new Chipset(frequencies, "Intel Z690", false, true));
        motherboardBuilder.AddDdrVersion(Ddr.V5);
        motherboardBuilder.AddMotherBoardSocket(Socket.Lga1700);
        motherboardBuilder.AddNumberRamSlots(new NumberRamSlots(4));
        motherboardBuilder.AddNumberSataSlots(new NumberSata(6));
        motherboardBuilder.AddNumberPciESlots(new NumberPciE(3));
        motherboardRepository.Add(motherboardBuilder.Build());

        // Third motherboard
        motherboardBuilder.AddName("ASRock B760M Pro RS/D4");
        motherboardBuilder.AddMotherboardFormFactor(new FormFactor(FormFactorType.MicroAtx));
        cpuList = new List<Cpu>();
        cpuList.Add(cpuRepository.GetByName("Intel Core i5-13400F") ?? throw new ArgumentNullException(nameof(cpuRepository)));
        motherboardBuilder.AddBios(new Bios(cpuList, BiosType.Uefi, new BiosVersion("5.1")));
        motherboardBuilder.AddChipset(new Chipset(frequencies, "Intel B760", false, false));
        motherboardBuilder.AddDdrVersion(Ddr.V4);
        motherboardBuilder.AddMotherBoardSocket(Socket.Lga1700);
        motherboardBuilder.AddNumberRamSlots(new NumberRamSlots(4));
        motherboardBuilder.AddNumberSataSlots(new NumberSata(4));
        motherboardBuilder.AddNumberPciESlots(new NumberPciE(2));
        motherboardRepository.Add(motherboardBuilder.Build());

        return motherboardRepository;
    }

    private static RepositoryBase<PowerSupply> PowerSupplyFactory()
    {
        RepositoryBase<PowerSupply> powerSupplyRepository = new PowerSupplyRepository();
        var powerSupplyBuilder = new PowerSupplyBuilder();

        // First power supply
        powerSupplyBuilder.AddName("DEEPCOOL PF600");
        powerSupplyBuilder.AddMaxPower(new Power(600));
        powerSupplyRepository.Add(powerSupplyBuilder.Build());

        // Second power supply
        powerSupplyBuilder.AddName("Cougar STX 700W");
        powerSupplyBuilder.AddMaxPower(new Power(700));
        powerSupplyRepository.Add(powerSupplyBuilder.Build());

        // Third power supply
        powerSupplyBuilder.AddName("AeroCool VX PLUS 500W");
        powerSupplyBuilder.AddMaxPower(new Power(500));
        powerSupplyRepository.Add(powerSupplyBuilder.Build());

        // Fourth power supply
        powerSupplyBuilder.AddName("MONTECH CENTURY 850");
        powerSupplyBuilder.AddMaxPower(new Power(850));
        powerSupplyRepository.Add(powerSupplyBuilder.Build());

        // Fifth power supply
        powerSupplyBuilder.AddName("DEEPCOOL PK700D");
        powerSupplyBuilder.AddMaxPower(new Power(700));
        powerSupplyRepository.Add(powerSupplyBuilder.Build());

        return powerSupplyRepository;
    }

    private static RepositoryBase<Ram> RamFactory()
    {
        RepositoryBase<Ram> ramRepository = new RamRepository();
        var ramBuilder = new RamBuilder();

        // First ram
        ramBuilder.AddName("Kingston FURY Beast Black");
        ramBuilder.AddRamPower(new Power(20));
        ramBuilder.AddRamFormFactor(new FormFactor(FormFactorType.Atx));
        ramBuilder.AddRamMemoryCapacity(new NumberGigabytesMemory(8));
        ramBuilder.AddDdrVersion(Ddr.V4);
        IList<Xmp> supportingXmp = new List<Xmp>();
        supportingXmp.Add(new Xmp(new Timings(15, 17, 17, 25), new Voltage(1.35), new MegaHertzFrequency(3000)));
        supportingXmp.Add(new Xmp(new Timings(16, 18, 18, 28), new Voltage(1.40), new MegaHertzFrequency(3200)));
        ramBuilder.AddSupportingXmp(supportingXmp);
        IList<JedecVoltageMatching> supportingJedecVoltage = new List<JedecVoltageMatching>();
        supportingJedecVoltage.Add(new JedecVoltageMatching(new MegaHertzFrequency(3200), new Voltage(1.40)));
        ramBuilder.AddSupportingJedecVoltage(supportingJedecVoltage);
        ramRepository.Add(ramBuilder.Build());

        // Second ram
        ramBuilder.AddName("HP V10 RGB");
        ramBuilder.AddRamPower(new Power(30));
        ramBuilder.AddRamFormFactor(new FormFactor(FormFactorType.Atx));
        ramBuilder.AddRamMemoryCapacity(new NumberGigabytesMemory(8));
        ramBuilder.AddDdrVersion(Ddr.V4);
        supportingXmp = new List<Xmp>();
        supportingXmp.Add(new Xmp(new Timings(16, 20, 20, 38), new Voltage(1.35), new MegaHertzFrequency(3200)));
        ramBuilder.AddSupportingXmp(supportingXmp);
        supportingJedecVoltage = new List<JedecVoltageMatching>();
        supportingJedecVoltage.Add(new JedecVoltageMatching(new MegaHertzFrequency(3200), new Voltage(1.35)));
        ramBuilder.AddSupportingJedecVoltage(supportingJedecVoltage);
        ramRepository.Add(ramBuilder.Build());

        return ramRepository;
    }

    private static RepositoryBase<Hdd> HddFactory()
    {
        RepositoryBase<Hdd> hddRepository = new HddRepository();
        var hddBuilder = new HddBuilder();

        // First hdd
        hddBuilder.AddName("Seagate BarraCuda");
        hddBuilder.AddHddPower(new Power(4));
        hddBuilder.AddMemoryCapacity(new NumberGigabytesMemory(2000));
        hddBuilder.AddMaxSpindleSpeed(new SpindleSpeed(7200));
        hddRepository.Add(hddBuilder.Build());

        // Second hdd
        hddBuilder.AddName("WD Blue");
        hddBuilder.AddHddPower(new Power(7));
        hddBuilder.AddMemoryCapacity(new NumberGigabytesMemory(1000));
        hddBuilder.AddMaxSpindleSpeed(new SpindleSpeed(7200));
        hddRepository.Add(hddBuilder.Build());

        // Third hdd
        Hdd component = hddRepository.GetByName("WD Blue") ?? throw new ArgumentNullException(nameof(hddRepository));
        component.Direct(hddBuilder);
        hddBuilder.AddName("Toshiba DT01");
        hddRepository.Add(hddBuilder.Build());

        return hddRepository;
    }

    private static RepositoryBase<Ssd> SsdFactory()
    {
        RepositoryBase<Ssd> ssdRepository = new SsdRepository();
        var ssdBuilder = new SsdBuilder();

        // First ssd
        ssdBuilder.AddName("Kingston A400");
        ssdBuilder.AddMemoryCapacity(new NumberGigabytesMemory(480));
        ssdBuilder.AddSsdPower(new Power(2));
        ssdBuilder.AddSsdConnector(Connector.PciE);
        ssdBuilder.AddMaxEfficiency(new MegabytesPerSecondEfficiency(480));
        ssdRepository.Add(ssdBuilder.Build());

        // Second ssd
        ssdBuilder.AddName("Samsung 870 EVO");
        ssdBuilder.AddMemoryCapacity(new NumberGigabytesMemory(1000));
        ssdBuilder.AddSsdPower(new Power(4));
        ssdBuilder.AddSsdConnector(Connector.Sata);
        ssdBuilder.AddMaxEfficiency(new MegabytesPerSecondEfficiency(500));
        ssdRepository.Add(ssdBuilder.Build());

        // Third ssd
        ssdBuilder.AddName("DEXP C100");
        ssdBuilder.AddMemoryCapacity(new NumberGigabytesMemory(1024));
        ssdBuilder.AddSsdPower(new Power(5));
        ssdBuilder.AddSsdConnector(Connector.Sata);
        ssdBuilder.AddMaxEfficiency(new MegabytesPerSecondEfficiency(560));
        ssdRepository.Add(ssdBuilder.Build());

        return ssdRepository;
    }

    private static RepositoryBase<VideoCard> VideoCardFactory()
    {
        RepositoryBase<VideoCard> videoCardRepository = new VideoCardRepository();
        var videoCardBuilder = new VideoCardBuilder();

        // First video card
        videoCardBuilder.AddName("Palit GeForce RTX 3060 Ti Dual");
        videoCardBuilder.AddDimensions(new MillimetersDimensions(294, 118, 53));
        videoCardBuilder.AddPciEVersion(PciEVersion.V4);
        videoCardBuilder.AddChipFrequency(new MegaHertzFrequency(1410));
        videoCardBuilder.AddPower(new Power(225));
        videoCardRepository.Add(videoCardBuilder.Build());

        // Second video card
        videoCardBuilder.AddName("KFA2 GeForce GTX 1650 X Black");
        videoCardBuilder.AddDimensions(new MillimetersDimensions(200, 111, 33));
        videoCardBuilder.AddPciEVersion(PciEVersion.V3);
        videoCardBuilder.AddChipFrequency(new MegaHertzFrequency(1410));
        videoCardBuilder.AddPower(new Power(300));
        videoCardRepository.Add(videoCardBuilder.Build());

        return videoCardRepository;
    }

    private static RepositoryBase<WifiAdapter> WifiAdapterFactory()
    {
        RepositoryBase<WifiAdapter> wifiAdapterRepository = new WifiAdapterRepository();
        var wifiAdapterBuilder = new WifiAdapterBuilder();

        wifiAdapterBuilder.AddName("TP-LINK Archer T5E");
        wifiAdapterBuilder.AddAdapterWifiStandard(WifiStandard.Wifi5);
        wifiAdapterBuilder.AddAdapterPower(new Power(10));
        wifiAdapterBuilder.AddAdapterPciEVersion(PciEVersion.V4);
        wifiAdapterBuilder.AddHasBluetooth(true);
        wifiAdapterRepository.Add(wifiAdapterBuilder.Build());

        return wifiAdapterRepository;
    }
}