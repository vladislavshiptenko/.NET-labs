using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class ComputerCaseBuilder
{
    private MillimetersDimensions? _maxVideoCardDimensions;
    private MillimetersDimensions? _computerCaseDimensions;
    private IList<FormFactor> _supportingFormFactor = new List<FormFactor>();
    private string? _name;

    public void AddMaxVideoCardDimensions(MillimetersDimensions maxVideoCardDimensions)
    {
        _maxVideoCardDimensions = maxVideoCardDimensions;
    }

    public void AddComputerCaseDimensions(MillimetersDimensions computerCaseDimensions)
    {
        _computerCaseDimensions = computerCaseDimensions;
    }

    public void AddSupportingFormFactorList(IList<FormFactor> supportingFormFactor)
    {
        _supportingFormFactor = supportingFormFactor;
    }

    public void AddName(string name)
    {
        _name = name;
    }

    public ComputerCase Build()
    {
        if (_name is null)
        {
            throw new BuildingStepException(nameof(_name));
        }

        if (_supportingFormFactor.Count == 0)
        {
            throw new BuildingStepException(nameof(_supportingFormFactor));
        }

        if (_maxVideoCardDimensions is null)
        {
            throw new BuildingStepException(nameof(_maxVideoCardDimensions));
        }

        if (_computerCaseDimensions is null)
        {
            throw new BuildingStepException(nameof(_computerCaseDimensions));
        }

        return new ComputerCase(_supportingFormFactor, _name, _maxVideoCardDimensions, _computerCaseDimensions);
    }
}