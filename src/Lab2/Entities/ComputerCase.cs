using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : IComponent
{
    private IList<FormFactor> _supportingFormFactor;

    public ComputerCase(IList<FormFactor> supportingFormFactor, string name, MillimetersDimensions maxVideoCardDimensions, MillimetersDimensions computerCaseDimensions)
    {
        _supportingFormFactor = supportingFormFactor;
        Name = name;
        MaxVideoCardDimensions = maxVideoCardDimensions;
        ComputerCaseDimensions = computerCaseDimensions;
    }

    public string Name { get; }

    public MillimetersDimensions MaxVideoCardDimensions { get; }
    public MillimetersDimensions ComputerCaseDimensions { get; }

    public bool CompatibleWithVideoCard(VideoCard? videoCard)
    {
        if (videoCard is null)
        {
            return true;
        }

        return MaxVideoCardDimensions.Length >= videoCard.VideoCardDimensions.Length &&
               MaxVideoCardDimensions.Width >= videoCard.VideoCardDimensions.Width &&
               MaxVideoCardDimensions.Height >= videoCard.VideoCardDimensions.Height;
    }

    public bool CompatibleWithMotherboard(Motherboard motherboard)
    {
        if (motherboard is null)
        {
            throw new ArgumentNullException(nameof(motherboard));
        }

        return _supportingFormFactor.Any(sff => sff.Type == motherboard.MotherboardFormFactor.Type);
    }

    public void Direct(ComputerCaseBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.AddSupportingFormFactorList(_supportingFormFactor);
        builder.AddName(Name);
        builder.AddComputerCaseDimensions(ComputerCaseDimensions);
        builder.AddMaxVideoCardDimensions(MaxVideoCardDimensions);
    }
}