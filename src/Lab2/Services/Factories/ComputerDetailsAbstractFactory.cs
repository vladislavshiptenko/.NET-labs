using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class ComputerDetailsAbstractFactory
{
    private readonly RepositoryBase<Cpu> _cpuRepository;
    private readonly RepositoryBase<Motherboard> _motherboardRepository;
    private readonly RepositoryBase<Ram> _ramRepository;
    private readonly RepositoryBase<WifiAdapter> _wifiAdapterRepository;
    private readonly RepositoryBase<ComputerCase> _computerCaseRepository;
    private readonly RepositoryBase<CoolingSystem> _coolingSystemRepository;
    private readonly RepositoryBase<PowerSupply> _powerSupplyRepository;
    private readonly RepositoryBase<VideoCard> _videoCardRepository;
    private readonly RepositoryBase<Hdd> _hddRepository;
    private readonly RepositoryBase<Ssd> _ssdRepository;

    public ComputerDetailsAbstractFactory(RepositoryBase<Cpu> cpuRepository, RepositoryBase<Motherboard> motherboardRepository, RepositoryBase<Ram> ramRepository, RepositoryBase<WifiAdapter> wifiAdapterRepository, RepositoryBase<ComputerCase> computerCaseRepository, RepositoryBase<CoolingSystem> coolingSystemRepository, RepositoryBase<PowerSupply> powerSupplyRepository, RepositoryBase<VideoCard> videoCardRepository, RepositoryBase<Hdd> hddRepository, RepositoryBase<Ssd> ssdRepository)
    {
        _cpuRepository = cpuRepository;
        _motherboardRepository = motherboardRepository;
        _ramRepository = ramRepository;
        _wifiAdapterRepository = wifiAdapterRepository;
        _computerCaseRepository = computerCaseRepository;
        _coolingSystemRepository = coolingSystemRepository;
        _powerSupplyRepository = powerSupplyRepository;
        _videoCardRepository = videoCardRepository;
        _hddRepository = hddRepository;
        _ssdRepository = ssdRepository;
    }

    public Cpu? GetCpuByName(string cpuName)
    {
        return _cpuRepository.GetByName(cpuName);
    }

    public Motherboard? GetMotherboardByName(string motherboardName)
    {
        return _motherboardRepository.GetByName(motherboardName);
    }

    public Ram? GetRamByName(string ramName)
    {
        return _ramRepository.GetByName(ramName);
    }

    public WifiAdapter? GetWifiAdapterByName(string wifiAdapterName)
    {
        return _wifiAdapterRepository.GetByName(wifiAdapterName);
    }

    public ComputerCase? GetComputerCaseByName(string computerCaseName)
    {
        return _computerCaseRepository.GetByName(computerCaseName);
    }

    public CoolingSystem? GetCoolingSystemByName(string coolingSystemName)
    {
        return _coolingSystemRepository.GetByName(coolingSystemName);
    }

    public PowerSupply? GetPowerSupplyByName(string powerSupplyName)
    {
        return _powerSupplyRepository.GetByName(powerSupplyName);
    }

    public VideoCard? GetVideoCardByName(string videoCardName)
    {
        return _videoCardRepository.GetByName(videoCardName);
    }

    public Hdd? GetHddByName(string hddName)
    {
        return _hddRepository.GetByName(hddName);
    }

    public Ssd? GetSsdByName(string ssdName)
    {
        return _ssdRepository.GetByName(ssdName);
    }
}