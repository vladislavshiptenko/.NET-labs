using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class VideoCard : IComponent
{
    public VideoCard(string name, MillimetersDimensions videoCardDimensions, PciEVersion videoCardPciEVersion, MegaHertzFrequency chipFrequency, Power videoCardPower)
    {
        Name = name;
        VideoCardDimensions = videoCardDimensions;
        VideoCardPciEVersion = videoCardPciEVersion;
        ChipFrequency = chipFrequency;
        VideoCardPower = videoCardPower;
    }

    public string Name { get; }
    public MillimetersDimensions VideoCardDimensions { get; }
    public PciEVersion VideoCardPciEVersion { get; }
    public MegaHertzFrequency ChipFrequency { get; }
    public Power VideoCardPower { get; }
    public void Direct(VideoCardBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddName(Name);
        builder.AddDimensions(VideoCardDimensions);
        builder.AddPciEVersion(VideoCardPciEVersion);
        builder.AddChipFrequency(ChipFrequency);
        builder.AddPower(VideoCardPower);
    }
}