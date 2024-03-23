using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Configurators;

public interface IConfigurator<T>
{
    public void ReplaceMotherboard(string newMotherboardName);
    public void ReplaceCpu(string newCpuName);
    public void ReplaceCoolingSystem(string newCoolingSystemName);
    public void ReplaceVideoCard(string newVideoCardName);
    public void ReplaceWifiAdapter(string newWifiAdapterName);
    public void ReplacePowerSupply(string newPowerSupplyName);
    public void ReplaceComputerCase(string newComputerCaseName);
    public void ReplaceHddList(IList<string> newHddList);
    public void ReplaceSsdList(IList<string> newSsdList);
    public void ReplaceRamList(IList<string> newRamList);
    public T ConstructComputer();
}