using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCardAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class VideoCardBuilder
{
    private string? _name;
    private MillimetersDimensions? _videoCardDimensions;
    private PciEVersion _videoCardPciEVersion;
    private MegaHertzFrequency? _chipFrequency;
    private Power? _videoCardPower;

    public void AddName(string name)
    {
        _name = name;
    }

    public void AddDimensions(MillimetersDimensions videoCardDimensions)
    {
        _videoCardDimensions = videoCardDimensions;
    }

    public void AddPciEVersion(PciEVersion pciEVersion)
    {
        _videoCardPciEVersion = pciEVersion;
    }

    public void AddChipFrequency(MegaHertzFrequency chipFrequency)
    {
        _chipFrequency = chipFrequency;
    }

    public void AddPower(Power videoCardPower)
    {
        _videoCardPower = videoCardPower;
    }

    public VideoCard Build()
    {
        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_videoCardDimensions is null)
        {
            throw new BuildingStepException(nameof(_videoCardDimensions));
        }

        if (_chipFrequency is null)
        {
            throw new BuildingStepException(nameof(_chipFrequency));
        }

        if (_videoCardPower is null)
        {
            throw new BuildingStepException(nameof(_videoCardPower));
        }

        return new VideoCard(_name, _videoCardDimensions, _videoCardPciEVersion, _chipFrequency, _videoCardPower);
    }
}