using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

public class FormFactor
{
    private IList<FormFactorDimensionsMatching> _dimensionsTable = new List<FormFactorDimensionsMatching>();

    public FormFactor(FormFactorType type)
    {
        Type = type;
        _dimensionsTable.Add(new FormFactorDimensionsMatching(FormFactorType.Eatx, new MillimetersDimensions(305, 330, 50)));
        _dimensionsTable.Add(new FormFactorDimensionsMatching(FormFactorType.Atx, new MillimetersDimensions(305, 244, 50)));
        _dimensionsTable.Add(new FormFactorDimensionsMatching(FormFactorType.MicroAtx, new MillimetersDimensions(244, 244, 50)));
        _dimensionsTable.Add(new FormFactorDimensionsMatching(FormFactorType.MiniItx, new MillimetersDimensions(170, 170, 50)));
    }

    public FormFactorType Type { get; }
}